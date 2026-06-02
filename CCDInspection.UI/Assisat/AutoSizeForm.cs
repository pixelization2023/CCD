using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCDInspection.UI.Assisat
{
    public class AutoSizeForm
    {
        //(1).声明结构,只记录窗体和其控件的初始位置和大小。
        public struct controlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
        }
        //(2).声明 1个对象
        //注意这里不能使用控件列表记录 List nCtrl;，因为控件的关联性，记录的始终是当前的大小。
        //      public List oldCtrl= new List();//这里将西文的大于小于号都过滤掉了，只能改为中文的，使用中要改回西文
        public List<controlRect> oldCtrl = new List<controlRect>();
        int ctrlNo = 0;//1;
        //(3). 创建两个函数
        //(3.1)记录窗体和其控件的初始位置和大小,
        public void controllInitializeSize(Control mForm)
        {
            controlRect cR;
            cR.Left = mForm.Left; cR.Top = mForm.Top; cR.Width = mForm.Width; cR.Height = mForm.Height;
            oldCtrl.Add(cR);//第一个为"窗体本身",只加入一次即可
            AddControl(mForm);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
                              //this.WindowState = (System.Windows.Forms.FormWindowState)(2);//记录完控件的初始位置和大小后，再最大化
                              //0 - Normalize , 1 - Minimize,2- Maximize
        }
        private void AddControl(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {  //**放在这里，是先记录控件的子控件，后记录控件本身
               //if (c.Controls.Count > 0)
               //    AddControl(c);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
                controlRect objCtrl;
                objCtrl.Left = c.Left; objCtrl.Top = c.Top; objCtrl.Width = c.Width; objCtrl.Height = c.Height;
                oldCtrl.Add(objCtrl);
                //**放在这里，是先记录控件本身，后记录控件的子控件
                if (c.Controls.Count > 0)
                    AddControl(c);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
            }
        }
        //(3.2)控件自适应大小（需先调用 controllInitializeSize 记录初始尺寸）
        public void controlAutoSize(Control mForm)
        {
            if (oldCtrl.Count == 0) return;

            float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;
            float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;
            ctrlNo = 1;
            AutoScaleControl(mForm, wScale, hScale);
        }
        private void AutoScaleControl(Control ctl, float wScale, float hScale)
        {
            int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
            //int ctrlNo = 1;//第1个是窗体自身的 Left,Top,Width,Height，所以窗体控件从ctrlNo=1开始
            foreach (Control c in ctl.Controls)
            { //**放在这里，是先缩放控件的子控件，后缩放控件本身
              //if (c.Controls.Count > 0)
              //   AutoScaleControl(c, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
                ctrLeft0 = oldCtrl[ctrlNo].Left;
                ctrTop0 = oldCtrl[ctrlNo].Top;
                ctrWidth0 = oldCtrl[ctrlNo].Width;
                ctrHeight0 = oldCtrl[ctrlNo].Height;
                //c.Left = (int)((ctrLeft0 - wLeft0) * wScale) + wLeft1;//新旧控件之间的线性比例
                //c.Top = (int)((ctrTop0 - wTop0) * h) + wTop1;
                c.Left = (int)((ctrLeft0) * wScale);//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1
                c.Top = (int)((ctrTop0) * hScale);//
                c.Width = (int)(ctrWidth0 * wScale);//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);
                c.Height = (int)(ctrHeight0 * hScale);//
                ctrlNo++;//累加序号
                //**放在这里，是先缩放控件本身，后缩放控件的子控件
                if (c.Controls.Count > 0)
                    AutoScaleControl(c, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
            }

            // 处理 DataGridView 的列自适应（在 foreach 外面，只执行一次）
            if (ctl is DataGridView)
            {
                DataGridView dgv = ctl as DataGridView;
                Cursor.Current = Cursors.WaitCursor;

                int widths = 0;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                    widths += dgv.Columns[i].Width;
                }

                if (widths >= ctl.Size.Width)
                {
                    // 内容超出宽度 → 每列按内容显示，冻结列保持不动
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (!col.Frozen)
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    }
                }
                else
                {
                    // 内容少于宽度 → 非冻结列填满剩余空间
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (!col.Frozen)
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            }


        }
    }
