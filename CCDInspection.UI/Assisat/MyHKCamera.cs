
//using MvCamCtrl.NET;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCDInspection.UI.Assisat
{
    public partial class MyHKCamera : MyBaseCamera
    {
        #region 定义
        //图像获取回调
        MyCamera.cbOutputExdelegate ImageCallback;
        //断线重连回调
        MyCamera.cbExceptiondelegate pCallBackFunc;
        MyCamera.MV_CC_DEVICE_INFO tempDevice = new MyCamera.MV_CC_DEVICE_INFO();
        private MyCamera m_pCamera = null;//海康相机
        #endregion
        #region dispose resource
        public void Dispose()
        {
            Dispose(true);// 释放托管和非托管资源
            GC.SuppressFinalize(this);//将对象从垃圾回收器链表中移除， 从而在垃圾回收器工作时，只释放托管资源，而不执行此对象的析构函数
        }
        //参数为true表示释放所有资源，只能由使用者调用
        //参数为false表示释放非托管资源，只能由垃圾回收器自动调用
        //如果子类有自己的非托管资源，可以重载这个函数，添加自己的非托管资源的释放
        //但是要记住，重载此函数必须保证调用基类的版本，以保证基类的资源正常释放
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)// 如果资源未释放 这个判断主要用了防止对象被多次释放
            {
                if (disposing)
                {
                    // Release managed resources 释放托管资源

                    GC.Collect();
                }

                // Release unmanaged resources 释放非托管资源  
                if (m_pCamera != null)
                {
                    StopConnect();
                    m_pCamera = null;
                }

                m_disposed = true;// 标识此对象已释放
            }
        }
        ~MyHKCamera()//由垃圾回收器调用，释放非托管资源
        {
            Dispose(false);// 释放非托管资源
        }
        private bool m_disposed;
        #endregion

        public MyHKCamera(MyCameraInfo cameraInfo) : base(cameraInfo)
        {
            pCallBackFunc = new MyCamera.cbExceptiondelegate(cbExceptiondelegate);
        }

        private int InitCamera()
        {
            int nRet = m_pCamera.MV_CC_RegisterExceptionCallBack_NET(pCallBackFunc, IntPtr.Zero);
            GC.KeepAlive(pCallBackFunc);
            if (MyCamera.MV_OK != nRet)
            {
                return nRet;
            }

            // ch:标志位置位true | en:Set position bit true
            //m_bGrabbing = true;
            //m_hReceiveThread = new Thread(ReceiveThreadProcess);
            //m_hReceiveThread.Start();

            // ch:开始采集 | en:Start Grabbing
            nRet = m_pCamera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                //m_bGrabbing = false;
                //m_hReceiveThread.Join();
                CameraInfo.IsConnected = false;
                return nRet;
            }
            else
            {
                CameraInfo.IsConnected = true;
            }

            return MyCamera.MV_OK;
        }

        private void DeInitCamera()
        {
            // ch:标志位设为false | en:Set flag bit false
            //m_bGrabbing = false;
            //m_hReceiveThread.Join();
            CameraInfo.IsConnected = false;

            // ch:停止采集 | en:Stop Grabbing
            m_pCamera.MV_CC_StopGrabbing_NET();

            // ch:关闭设备 | en:Close Device
            m_pCamera.MV_CC_CloseDevice_NET();
            m_pCamera.MV_CC_DestroyDevice_NET();

        }

        // 断线重连回调函数 | en:Callback function
        private void cbExceptiondelegate(uint nMsgType, IntPtr pUser)
        {
            if (nMsgType == MyCamera.MV_EXCEPTION_DEV_DISCONNECT)
            {
                DeInitCamera();

                // ch:获取选择的设备信息 | en:Get Used Device Info
                //MyCamera.MV_CC_DEVICE_INFO device =
                //    (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[cbDeviceList.SelectedIndex],
                //                                                  typeof(MyCamera.MV_CC_DEVICE_INFO));

                // ch:打开设备 | en:Open Device
                while (true)
                {
                    int nRet = m_pCamera.MV_CC_CreateDevice_NET(ref tempDevice);
                    if (MyCamera.MV_OK != nRet)
                    {
                        Thread.Sleep(5);
                        continue;
                    }

                    nRet = m_pCamera.MV_CC_OpenDevice_NET();
                    if (MyCamera.MV_OK != nRet)
                    {
                        Thread.Sleep(5);
                        m_pCamera.MV_CC_DestroyDevice_NET();
                        continue;
                    }
                    else
                    {
                        nRet = InitCamera();
                        if (MyCamera.MV_OK != nRet)
                        {
                            Thread.Sleep(5);
                            m_pCamera.MV_CC_DestroyDevice_NET();
                            continue;
                        }
                        break;
                    }
                }
            }
        }


        //图像获取回调
        private void ImageCallbackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            Bitmap bitmap = null;
            int nRet = MyCamera.MV_OK;
            IntPtr pImageBuf = IntPtr.Zero;
            int nImageBufSize = 0;

            IntPtr pTemp= IntPtr.Zero;
            try
            {

                if (IsColorPixelFormat(pFrameInfo.enPixelType))
                {
                    if (pFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                    {
                        pTemp = pData;
                    }
                    else
                    {
                        if (IntPtr.Zero == pImageBuf || nImageBufSize < (pFrameInfo.nWidth * pFrameInfo.nHeight * 3))
                        {
                            if (pImageBuf != IntPtr.Zero)
                            {
                                Marshal.FreeHGlobal(pImageBuf);
                                pImageBuf = IntPtr.Zero;
                            }

                            pImageBuf = Marshal.AllocHGlobal((int)pFrameInfo.nWidth * pFrameInfo.nHeight * 3);
                            if (IntPtr.Zero == pImageBuf)
                            {
                                return;
                            }
                            nImageBufSize = pFrameInfo.nWidth * pFrameInfo.nHeight * 3;
                        }

                        MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                        stPixelConvertParam.pSrcData = pData;//源数据
                        stPixelConvertParam.nWidth = pFrameInfo.nWidth;//图像宽度
                        stPixelConvertParam.nHeight = pFrameInfo.nHeight;//图像高度
                        stPixelConvertParam.enSrcPixelType = pFrameInfo.enPixelType;//源数据的格式
                        stPixelConvertParam.nSrcDataLen = pFrameInfo.nFrameLen;

                        stPixelConvertParam.nDstBufferSize = (uint)nImageBufSize;
                        stPixelConvertParam.pDstBuffer = pImageBuf;//转换后的数据
                        stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        nRet = m_pCamera.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
                        if (MyCamera.MV_OK != nRet)
                        {
                            return;
                        }
                        pTemp = pImageBuf;
                    }

                    // 创建RGB位图
                    bitmap = new Bitmap((int)pFrameInfo.nWidth, (int)pFrameInfo.nHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bitmap.PixelFormat);
                    int bufferSize = (int)pFrameInfo.nWidth * (int)pFrameInfo.nHeight * 3;
                    byte[] buffer = new byte[bufferSize];
                    Marshal.Copy(pTemp, buffer, 0, bufferSize);
                    Marshal.Copy(buffer, 0, bmpData.Scan0, bufferSize);
                    bitmap.UnlockBits(bmpData);
                }
                else if (IsMonoPixelFormat(pFrameInfo.enPixelType))
                {
                    if (pFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
                    {
                        pTemp = pData;
                    }
                    else
                    {
                        if (IntPtr.Zero == pImageBuf || nImageBufSize < (pFrameInfo.nWidth * pFrameInfo.nHeight))
                        {
                            if (pImageBuf != IntPtr.Zero)
                            {
                                Marshal.FreeHGlobal(pImageBuf);
                                pImageBuf = IntPtr.Zero;
                            }

                            pImageBuf = Marshal.AllocHGlobal((int)pFrameInfo.nWidth * pFrameInfo.nHeight);
                            if (IntPtr.Zero == pImageBuf)
                            {
                                return;
                            }
                            nImageBufSize = pFrameInfo.nWidth * pFrameInfo.nHeight;
                        }

                        MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                        stPixelConvertParam.pSrcData = pData;//源数据
                        stPixelConvertParam.nWidth = pFrameInfo.nWidth;//图像宽度
                        stPixelConvertParam.nHeight = pFrameInfo.nHeight;//图像高度
                        stPixelConvertParam.enSrcPixelType = pFrameInfo.enPixelType;//源数据的格式
                        stPixelConvertParam.nSrcDataLen = pFrameInfo.nFrameLen;

                        stPixelConvertParam.nDstBufferSize = (uint)nImageBufSize;
                        stPixelConvertParam.pDstBuffer = pImageBuf;//转换后的数据
                        stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
                        nRet = m_pCamera.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
                        if (MyCamera.MV_OK != nRet)
                        {
                            return;
                        }
                        pTemp = pImageBuf;
                    }
                    // 创建灰度位图
                    bitmap = new Bitmap((int)pFrameInfo.nWidth, (int)pFrameInfo.nHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                    System.Drawing.Imaging.ColorPalette palette = bitmap.Palette;
                    for (int i = 0; i < 256; i++)
                    {
                        palette.Entries[i] = Color.FromArgb(i, i, i);
                    }
                    bitmap.Palette = palette;
                    System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bitmap.PixelFormat);
                    int bufferSize = (int)pFrameInfo.nWidth * (int)pFrameInfo.nHeight;
                    byte[] buffer = new byte[bufferSize];
                    Marshal.Copy(pTemp, buffer, 0, bufferSize);
                    Marshal.Copy(buffer, 0, bmpData.Scan0, bufferSize);
                    bitmap.UnlockBits(bmpData);
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // 先传递原始图像数据给VM（避免Bitmap转换）
                if (pTemp != IntPtr.Zero)
                {
                    SetRawImage(pTemp, (int)pFrameInfo.nWidth, (int)pFrameInfo.nHeight, (int)pFrameInfo.enPixelType);
                }
                
                SetBitmap(bitmap);
                if (pImageBuf != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pImageBuf);
                    pImageBuf = IntPtr.Zero;
                }
            }

        }

        // ch:显示错误信息 | en:Show error message
        private void ShowErrorMsg(string csMessage, int nErrorNum)
        {
            string errorMsg;
            if (nErrorNum == 0)
            {
                errorMsg = csMessage;
            }
            else
            {
                errorMsg = csMessage + ": Error =" + String.Format("{0:X}", nErrorNum);
            }

            switch (nErrorNum)
            {
                case MyCamera.MV_E_HANDLE: errorMsg += " Error or invalid handle "; break;
                case MyCamera.MV_E_SUPPORT: errorMsg += " Not supported function "; break;
                case MyCamera.MV_E_BUFOVER: errorMsg += " Cache is full "; break;
                case MyCamera.MV_E_CALLORDER: errorMsg += " Function calling order error "; break;
                case MyCamera.MV_E_PARAMETER: errorMsg += " Incorrect parameter "; break;
                case MyCamera.MV_E_RESOURCE: errorMsg += " Applying resource failed "; break;
                case MyCamera.MV_E_NODATA: errorMsg += " No data "; break;
                case MyCamera.MV_E_PRECONDITION: errorMsg += " Precondition error, or running environment changed "; break;
                case MyCamera.MV_E_VERSION: errorMsg += " Version mismatches "; break;
                case MyCamera.MV_E_NOENOUGH_BUF: errorMsg += " Insufficient memory "; break;
                case MyCamera.MV_E_UNKNOW: errorMsg += " Unknown error "; break;
                case MyCamera.MV_E_GC_GENERIC: errorMsg += " General error "; break;
                case MyCamera.MV_E_GC_ACCESS: errorMsg += " Node accessing condition error "; break;
                case MyCamera.MV_E_ACCESS_DENIED: errorMsg += " No permission "; break;
                case MyCamera.MV_E_BUSY: errorMsg += " Device is busy, or network disconnected "; break;
                case MyCamera.MV_E_NETER: errorMsg += " Network error "; break;
            }

            MessageBox.Show(errorMsg, "PROMPT");
        }
        // 判断是否为灰度像素格式
        private bool IsMonoPixelFormat(MyCamera.MvGvspPixelType enType)
        {
            switch (enType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;
                default:
                    return false;
            }
        }
        // 判断是否为彩色像素格式
        private bool IsColorPixelFormat(MyCamera.MvGvspPixelType enType)
        {
            switch (enType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGBA8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BGRA8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                    return true;
                default:
                    return false;
            }
        }

        public Int32 ConvertToRGB(object obj, IntPtr pSrc, ushort nHeight, ushort nWidth, MyCamera.MvGvspPixelType nPixelType, IntPtr pDst)
        {
            if (IntPtr.Zero == pSrc || IntPtr.Zero == pDst)
            {
                return MyCamera.MV_E_PARAMETER;
            }

            int nRet = MyCamera.MV_OK;
            MyCamera m_pCamera = obj as MyCamera;
            MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

            stPixelConvertParam.pSrcData = pSrc;//源数据
            if (IntPtr.Zero == stPixelConvertParam.pSrcData)
            {
                return -1;
            }

            stPixelConvertParam.nWidth = nWidth;//图像宽度
            stPixelConvertParam.nHeight = nHeight;//图像高度
            stPixelConvertParam.enSrcPixelType = nPixelType;//源数据的格式
            stPixelConvertParam.nSrcDataLen = (uint)(nWidth * nHeight * ((((uint)nPixelType) >> 16) & 0x00ff) >> 3);

            stPixelConvertParam.nDstBufferSize = (uint)(nWidth * nHeight * ((((uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed) >> 16) & 0x00ff) >> 3);
            stPixelConvertParam.pDstBuffer = pDst;//转换后的数据
            stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
            stPixelConvertParam.nDstBufferSize = (uint)nWidth * nHeight * 3;

            nRet = m_pCamera.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
            if (MyCamera.MV_OK != nRet)
            {
                return -1;
            }

            return MyCamera.MV_OK;
        }

        public Int32 ConvertToMono8(object obj, IntPtr pInData, IntPtr pOutData, ushort nHeight, ushort nWidth, MyCamera.MvGvspPixelType nPixelType)
        {
            if (IntPtr.Zero == pInData || IntPtr.Zero == pOutData)
            {
                return MyCamera.MV_E_PARAMETER;
            }

            int nRet = MyCamera.MV_OK;
            MyCamera m_pCamera = obj as MyCamera;
            MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

            stPixelConvertParam.pSrcData = pInData;//源数据
            if (IntPtr.Zero == stPixelConvertParam.pSrcData)
            {
                return -1;
            }

            stPixelConvertParam.nWidth = nWidth;//图像宽度
            stPixelConvertParam.nHeight = nHeight;//图像高度
            stPixelConvertParam.enSrcPixelType = nPixelType;//源数据的格式
            stPixelConvertParam.nSrcDataLen = (uint)(nWidth * nHeight * ((((uint)nPixelType) >> 16) & 0x00ff) >> 3);

            stPixelConvertParam.nDstBufferSize = (uint)(nWidth * nHeight * ((((uint)MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed) >> 16) & 0x00ff) >> 3);
            stPixelConvertParam.pDstBuffer = pOutData;//转换后的数据
            stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
            stPixelConvertParam.nDstBufferSize = (uint)(nWidth * nHeight * 3);

            nRet = m_pCamera.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
            if (MyCamera.MV_OK != nRet)
            {
                return -1;
            }

            return nRet;
        }

        //打开相机连接
        protected override bool StartConnect()
        {

            #region 第一步 查找所有设备

            MyCamera.MV_CC_DEVICE_INFO_LIST cameraList = new MyCamera.MV_CC_DEVICE_INFO_LIST();

            int nRet;
            // ch: 创建设备列表 en:Create Device List
            System.GC.Collect();
            nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref cameraList);
            if (0 != nRet)
            {
                ShowErrorMsg("Enumerate devices fail!", 0);
                return false;
            }

            #endregion


            #region 第二步 打开设备,注册回调

            DisConnect();//先关闭

            if (cameraList.nDeviceNum == 0)
            {
                //ShowErrorMsg("No device, please select", 0);
                return false;
            }

            // ch:打开设备 | en:Open device
            if (null == m_pCamera)
            {
                m_pCamera = new MyCamera();
                if (null == m_pCamera)
                {
                    return false;
                }
            }

            nRet = -1;


            bool isOK = false;
            for (int i = 0; i < cameraList.nDeviceNum; i++)
            {
                tempDevice = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(cameraList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                if (tempDevice.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(tempDevice.SpecialInfo.stGigEInfo, 0);
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

                    if (gigeInfo.chSerialNumber == CameraInfo.SerialNumber)
                    {
                        nRet = m_pCamera.MV_CC_CreateDevice_NET(ref tempDevice);
                        if (MyCamera.MV_OK != nRet)
                        {
                            return false;
                        }
                        isOK = true;
                        break;
                    }
                }
                else if (tempDevice.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(tempDevice.SpecialInfo.stUsb3VInfo, 0);
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    if (usbInfo.chSerialNumber == CameraInfo.SerialNumber)
                    {
                        nRet = m_pCamera.MV_CC_CreateDevice_NET(ref tempDevice);
                        if (MyCamera.MV_OK != nRet)
                        {
                            return false;
                        }
                        isOK = true;
                        break;
                    }
                }

            }

            if (isOK == true)
            {
                nRet = m_pCamera.MV_CC_CreateDevice_NET(ref tempDevice);
                if (MyCamera.MV_OK != nRet)
                {
                    return false;
                }

                nRet = m_pCamera.MV_CC_OpenDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    m_pCamera.MV_CC_DestroyDevice_NET();
                    ShowErrorMsg("Device open fail!", nRet);
                    return false;
                }

                // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
                if (tempDevice.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    int nPacketSize = m_pCamera.MV_CC_GetOptimalPacketSize_NET();
                    if (nPacketSize > 0)
                    {
                        nRet = m_pCamera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                        if (nRet != MyCamera.MV_OK)
                        {
                            Console.WriteLine("Warning: Set Packet Size failed {0:x8}", nRet);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Warning: Get Packet Size failed {0:x8}", nPacketSize);
                    }
                }
                // ch:注册回调函数 | en:Register image callback
                ImageCallback = new MyCamera.cbOutputExdelegate(ImageCallbackFunc);
                nRet = m_pCamera.MV_CC_RegisterImageCallBackEx_NET(ImageCallback, IntPtr.Zero);
                GC.KeepAlive(ImageCallback);
                if (MyCamera.MV_OK != nRet)
                {
                    Console.WriteLine("Register image callback failed!");
                    return false;
                }

                // ch:开始采集 | en:Start Grabbing
                nRet = m_pCamera.MV_CC_StartGrabbing_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Trigger Fail!", nRet);
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }

            #endregion

        }

        // 关闭相机连接
        protected override bool StopConnect()
        {
            CameraInfo.IsConnected = false;//
            if (m_pCamera != null)
            {
                // ch:关闭设备 | en:Close Device
                int nRet;

                nRet = m_pCamera.MV_CC_CloseDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    return false;
                }

                nRet = m_pCamera.MV_CC_DestroyDevice_NET();//销毁设备
                if (MyCamera.MV_OK != nRet)
                {
                    return false;
                }
            }


            return true;
        }

        public override void UpDateCameraInfo(MyCameraInfo cameraInfo)
        {
            #region 设置触发模式
            //触发模式

            if (m_pCamera == null)
            {
                return;
            }

            int nRet = 0;
            switch (cameraInfo.TrigerModel)
            {
                case MyTriger.Continue://连续采集
                    {
                        nRet += m_pCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
                    }
                    break;
                case MyTriger.Software://软件触发
                    {
                        nRet += m_pCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                        nRet += m_pCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);

                    }

                    break;
                case MyTriger.External://外部触发
                    {
                        nRet += m_pCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                        nRet += m_pCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
                    }
                    break;
                default:
                    break;
            }

            if (nRet != MyCamera.MV_OK)
            {
                //  EV_LOG(evLogLevel::Warn, QString("海康相机: %1 采集模式切换失败").arg(info.CameraIdent));
                ShowErrorMsg("Set Exposure Time Fail!", nRet);
            }
            #endregion

            #region 设置曝光和增益
            //ExposureTime
            //设置曝光时间
            nRet += m_pCamera.MV_CC_SetFloatValue_NET("ExposureTime", cameraInfo.ExposeTime);
            if (nRet != MyCamera.MV_OK)
            {
                //ShowErrorMsg("Set Exposure Time Fail!", nRet);
            }
            //gain
            //设置增益
            m_pCamera.MV_CC_SetEnumValue_NET("GainAuto", 0);//关闭自动增益
            nRet += m_pCamera.MV_CC_SetFloatValue_NET("Gain", cameraInfo.Gain);
            if (nRet != MyCamera.MV_OK)
            {
                //ShowErrorMsg("Set Gain Fail!", nRet);
            }
            #endregion


            #region 设置Gama
            //nRet += m_pCamera.MV_CC_SetGammaSelector_NET(1);
            //nRet += m_pCamera.MV_CC_SetBoolValue_NET("GammaEnable", cameraInfo.Gamable);
            //if (nRet != MyCamera.MV_OK)
            //{
            //    ShowErrorMsg("Set GamaEnable Fail!", nRet);
            //}
            //nRet += m_pCamera.MV_CC_SetFloatValue_NET("Gamma", cameraInfo.Gama);
            //if (nRet != MyCamera.MV_OK)
            //{
            //    ShowErrorMsg("Set Gama Fail!", nRet);
            //}
            #endregion

        }

        // 触发软件采集
        protected override bool TriggerSoftware()
        {
            // ch:触发命令 | en:Trigger command
            int nRet = m_pCamera.MV_CC_SetCommandValue_NET("TriggerSoftware");
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg("Trigger Fail!", nRet);
                return false;
            }
            return true;
        }
    }
}
