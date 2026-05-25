using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CCDInspection.UI.Assisat
{
    //触发模式
    public enum MyTriger
    {
        None,//未知
        Continue,//连续采集
        Software,//软件触发
        External,//硬件触发
    };
    [Serializable]
    public class MyCameraInfo
    {
        public bool Gamable = false;

        public float Gama = 0;

        public string SerialNumber = "";     //相机唯一识别码 eg:设备连接ID/设备有效识别的ID

        public int ExposeTime = 5000;                //曝光时间 单位us 默认360ms
        public int Gain = 0;                         //增益

        public MyTriger TrigerModel = MyTriger.Software;//触发模式

        public int Timeout = 5000;//超级超时默认5s

        public bool IsConnected = false;//是否已经连接

        public MyCameraInfo(string serialNumber)
        {
            SerialNumber = serialNumber;
        }
    }

    public abstract class MyBaseCamera
    {
        //将采集到的图片通过委托显示到UI
        public event Action<Bitmap> BitmapCallevent;

        //原始图像数据事件，用于直接传递给VM
        public event Action<IntPtr, int, int, int> RawImageCallevent;

        public MyCameraInfo CameraInfo { get; set; }
        public AutoResetEvent m_Sign = new AutoResetEvent(false);//信号
        private Bitmap  m_Bitmap = null;//返回的图像

        public MyBaseCamera(MyCameraInfo cameraInfo)
        {
            CameraInfo = cameraInfo;
        }
        //打开设备
        public bool Connect()
        {
            DisConnect();

            if (StartConnect())
            {
                UpDateCameraInfo(CameraInfo);//设置参数
                CameraInfo.IsConnected = true;//连接成功
                return true;
            }
            else
            {
                return false;
            }
        }

        //断开设备连接
        public bool DisConnect()
        {
            CameraInfo.IsConnected = false;
            return StopConnect();
        }
        public  bool TriggerSoftwareOnce()
        {
            return TriggerSoftware();
        }
        protected abstract bool StartConnect();//建立设备连接
        protected abstract bool StopConnect();//断开设备连接
        public abstract void UpDateCameraInfo(MyCameraInfo cameraInfo);//修改相机的参数
        protected abstract bool TriggerSoftware();//发送软触发命令
        protected void SetBitmap(Bitmap bitmap)//子类回调采集到图后
        {
            if (m_Bitmap != null)
            {
                m_Bitmap.Dispose();
            }
            m_Bitmap = bitmap;
            m_Sign.Set();//发送信号

            if (BitmapCallevent != null)
            {
                BitmapCallevent.Invoke(m_Bitmap);
            }
        }

        //传递原始图像数据给VM
        protected void SetRawImage(IntPtr pData, int width, int height, int pixelFormat)
        {
            RawImageCallevent?.Invoke(pData, width, height, pixelFormat);
        }

        public Bitmap GetBitmap()
        {
            //UpDateCameraInfo(CameraInfo);//设置参数
            switch (CameraInfo.TrigerModel)
            {

                case MyTriger.Continue:
                    //暂不支持
                    break;
                case MyTriger.Software://软触发
                    if (TriggerSoftware())
                    {
                        //触发拍照
                        bool flag = m_Sign.WaitOne(CameraInfo.Timeout);

                        if (flag == true)
                        {
                            return m_Bitmap;
                        }
                    }
                    break;
                case MyTriger.External://硬触发

                    bool flag1 = m_Sign.WaitOne();//硬触发一直等待

                    if (flag1 == true)
                    {
                        return m_Bitmap;
                    }
                    break;
                default:
                    break;
            }
            return null;
        }

        public virtual void SetOutIO(string ioName, bool state)
        {
        }
    }
}
