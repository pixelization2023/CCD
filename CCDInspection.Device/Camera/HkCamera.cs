using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Enums;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core.Models;
using MvCamCtrl.NET;
using CCDInspection.Core;

namespace CCDInspection.Device.Camera
{
    /// <summary>
    /// 相机实习类
    /// </summary>
    public class HkCamera : ICamera
    {
        private MyCamera _camera;
        private MyCamera.cbOutputExdelegate _imageCallback;
        private MyCamera.cbExceptiondelegate _exceptionCallback;
        private MyCamera.MV_CC_DEVICE_INFO _deviceInfo;
        private readonly AutoResetEvent _imageSignal = new AutoResetEvent(false);
        private Bitmap _currentImage;
        private bool _disposed;

        public bool IsConnected { get; private set; }
        public CameraConfig Config { get; set; }
        public event Action<ImageCaptureResult> OnImageCaptured;

        public HkCamera(CameraConfig config) { Config = config; _exceptionCallback = new MyCamera.cbExceptiondelegate(OnException); }

        // === 兼容旧代码的同步方法（通过Task.Run避免UI线程死锁）===
        public bool Connect() { try { return Task.Run(() => ConnectAsync()).GetAwaiter().GetResult(); } catch { return false; } }
        public void Disconnect() { try { Task.Run(() => DisconnectAsync()).GetAwaiter().GetResult(); } catch { } }
        public bool Trigger(out Bitmap image) { image = null; try { var r = Task.Run(() => TriggerAsync()).GetAwaiter().GetResult(); image = r?.Image; return r?.Success == true; } catch { return false; } }

        public Task<bool> ConnectAsync(CancellationToken ct = default) => Task.Run(() =>
        {
            DisconnectCore();
            try
            {
                ct.ThrowIfCancellationRequested();
                var cameraList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
                GC.Collect();
                int ret = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref cameraList);
                if (ret != 0 || cameraList.nDeviceNum == 0) { LogService.Error("未找到相机设备"); return false; }
                _camera = new MyCamera(); bool found = false;
                for (int i = 0; i < cameraList.nDeviceNum; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    _deviceInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(cameraList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                    if (GetSerialNumber(_deviceInfo) != Config.SerialNumber) continue;
                    if (_camera.MV_CC_CreateDevice_NET(ref _deviceInfo) != 0) continue;
                    if (_camera.MV_CC_OpenDevice_NET() != 0) { _camera.MV_CC_DestroyDevice_NET(); continue; }
                    found = true; break;
                }
                if (!found) { LogService.Error("未找到相机 SN={Sn}", Config.SerialNumber); return false; }
                if (_deviceInfo.nTLayerType == MyCamera.MV_GIGE_DEVICE) { int ps = _camera.MV_CC_GetOptimalPacketSize_NET(); if (ps > 0) _camera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)ps); }
                _imageCallback = new MyCamera.cbOutputExdelegate(OnImageCallback);
                _camera.MV_CC_RegisterImageCallBackEx_NET(_imageCallback, IntPtr.Zero);
                if (_camera.MV_CC_StartGrabbing_NET() != 0) { LogService.Error("相机开始采集失败"); return false; }
                _camera.MV_CC_RegisterExceptionCallBack_NET(_exceptionCallback, IntPtr.Zero);
                ApplyConfig(); IsConnected = true;
                LogService.Information("相机连接成功 SN={Sn}", Config.SerialNumber); return true;
            }
            catch (OperationCanceledException) { LogService.Information("相机连接已取消"); return false; }
            catch (Exception ex) { LogService.Error(ex, "相机连接异常"); return false; }
        }, ct);

        public Task DisconnectAsync() => Task.Run(() => DisconnectCore());

        public Task<ImageCaptureResult> TriggerAsync(CancellationToken ct = default) => Task.Run(() =>
        {
            if (!IsConnected || _camera == null) return new ImageCaptureResult { Success = false, Error = "相机未连接" };
            ct.ThrowIfCancellationRequested();
            _imageSignal.Reset();
            if (_camera.MV_CC_SetCommandValue_NET("TriggerSoftware") != 0) return new ImageCaptureResult { Success = false, Error = "触发失败" };
            if (!_imageSignal.WaitOne(Config.Timeout)) return new ImageCaptureResult { Success = false, Error = "等待图像超时" };
            var r = new ImageCaptureResult { Success = true, Image = _currentImage };
            OnImageCaptured?.Invoke(r); return r;
        }, ct);

        private void DisconnectCore() { IsConnected = false; if (_camera != null) { try { _camera.MV_CC_StopGrabbing_NET(); _camera.MV_CC_CloseDevice_NET(); _camera.MV_CC_DestroyDevice_NET(); } catch { } _camera = null; } }

        public void ApplyConfig()
        {
            if (_camera == null || !IsConnected) return;
            switch (Config.TriggerMode) { case TriggerMode.Software: _camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON); _camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE); break; case TriggerMode.Hardware: _camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON); _camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0); break; case TriggerMode.Continuous: _camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF); break; }
            _camera.MV_CC_SetFloatValue_NET("ExposureTime", Config.ExposureTime); _camera.MV_CC_SetEnumValue_NET("GainAuto", 0); _camera.MV_CC_SetFloatValue_NET("Gain", Config.Gain);
        }

        private void OnImageCallback(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX frameInfo, IntPtr pUser)
        {
            try { int w = (int)frameInfo.nWidth, h = (int)frameInfo.nHeight; var bmp = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format24bppRgb); var bd = bmp.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.WriteOnly, bmp.PixelFormat); var bytes = new byte[bd.Stride * h]; Marshal.Copy(pData, bytes, 0, bytes.Length); Marshal.Copy(bytes, 0, bd.Scan0, bytes.Length); bmp.UnlockBits(bd); _currentImage = bmp; _imageSignal.Set(); OnImageCaptured?.Invoke(new ImageCaptureResult { Success = true, Image = bmp }); } catch { }
        }

        private void OnException(uint msgType, IntPtr pUser) { if (msgType == MyCamera.MV_EXCEPTION_DEV_DISCONNECT) { IsConnected = false; LogService.Warning("相机断线"); } }

        private string GetSerialNumber(MyCamera.MV_CC_DEVICE_INFO d) { try { if (d.nTLayerType == MyCamera.MV_GIGE_DEVICE) { var g = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(Marshal.UnsafeAddrOfPinnedArrayElement(d.SpecialInfo.stGigEInfo, 0), typeof(MyCamera.MV_GIGE_DEVICE_INFO)); return g.chSerialNumber; } else { var u = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(Marshal.UnsafeAddrOfPinnedArrayElement(d.SpecialInfo.stUsb3VInfo, 0), typeof(MyCamera.MV_USB3_DEVICE_INFO)); return u.chSerialNumber; } } catch { return ""; } }

        public void Dispose() { if (!_disposed) { DisconnectCore(); _imageSignal?.Dispose(); _currentImage?.Dispose(); _disposed = true; } }
    }
}
