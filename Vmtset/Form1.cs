using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM.Core;

namespace Vmtset
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  async void btn_lod_Click(object sender, EventArgs e)

        {
            VmSolution.Load("D:\\Desktop\\output\\Debug\\VmSol\\母端\\深蓝-母端.sol");


        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_run_Click(object sender, EventArgs e)
        {

            try
            {
                //VmSolution.Instance.Run();
                VmProcedure vmProcedure = (VmProcedure)VmSolution.Instance["流程1"];
                vmProcedure.Run();
                vmRenderControl1.ModuleSource = vmProcedure;
                var  resint =vmProcedure.ModuResult.GetOutputInt("out0").pIntVal[0];
                if (resint==1)
                {
                    var out1 = vmProcedure.ModuResult.GetOutputString("out").astStringVal[0].strValue;//ok
                    txt_show.Text = $"out1={out1}";
                }
                else
                {
                    var str = "这里是NG文本";
                    txt_show.Text = $"out1={str}";
                }


                //var out0 = vmProcedure.ModuResult.GetOutputString("out0").astStringVal[0].strValue;//ng



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           

        }
    }
}
