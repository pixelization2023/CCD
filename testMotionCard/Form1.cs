using cszmcaux;
using System;
using System.Threading;
using System.Windows.Forms;

namespace testMotionCard
{
    public partial class Form1 : Form
    {
        private IntPtr _handle = IntPtr.Zero;
        private int _axisIndex = 0;
        private System.Windows.Forms.Timer _timer;

        // 控件
        private TextBox txtIP;
        private Button btnConnect, btnDisconnect, btnEnable, btnDisable, btnHome, btnClearAlarm, btnStop;
        private Button btnJogFwd, btnJogRev;
        private Label lblStatus, lblPos, lblAxisStatus;
        private TextBox txtSpeed;

        public Form1()
        {
            InitializeComponent();
            this.Text = "ZMC 运动控制测试";
            this.Size = new System.Drawing.Size(500, 400);

            int y = 20;
            // IP
            AddLabel("IP地址:", 20, y + 3, 60); txtIP = AddTextBox("192.168.0.11", 80, y, 120);
            btnConnect = AddButton("连接", 210, y, 80, OnConnect);
            btnDisconnect = AddButton("断开", 295, y, 80, OnDisconnect);
            y += 35;
            // 使能
            btnEnable = AddButton("使能", 20, y, 80, OnEnable);
            btnDisable = AddButton("去使能", 105, y, 80, OnDisable);
            btnClearAlarm = AddButton("清报警", 190, y, 80, OnClearAlarm);
            y += 35;
            // 回零模式（控制器回零 Single_Datum）
            AddLabel("回零模式:", 20, y + 3, 60);
            var cmbHomeMode = new ComboBox { Location = new System.Drawing.Point(80, y), Width = 70 };
            cmbHomeMode.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "8", "9", "14" });
            cmbHomeMode.SelectedIndex = 8; // default 14
            cmbHomeMode.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbHomeMode);
            btnHome = AddButton("回零", 160, y, 120, (s, e) =>
            {
                int mode = int.Parse(cmbHomeMode.SelectedItem.ToString());
                float speed = float.TryParse(txtSpeed.Text, out var v) ? v : 20f;
                zmcaux.ZAux_Direct_SetSpeed(_handle, _axisIndex, speed);
                zmcaux.ZAux_Direct_SetCreep(_handle, _axisIndex, speed / 4);
                zmcaux.ZAux_Direct_SetParam(_handle, "AXIS_STOPREASON", _axisIndex, 0);
                int ret = zmcaux.ZAux_Direct_Single_Datum(_handle, _axisIndex, mode);
                lblStatus.Text = $"控制器回零 mode={mode} ret={ret}";
            });
            y += 35;
            // 速度
            AddLabel("速度:", 20, y + 3, 40); txtSpeed = AddTextBox("20", 60, y, 60);
            y += 35;
            // 点动
            btnJogFwd = AddButton("正向▶", 20, y, 100, null);
            btnJogRev = AddButton("◀负向", 130, y, 100, null);
            btnStop = AddButton("停止", 240, y, 80, OnStop);
            // MouseDown/MouseUp for Jog
            btnJogFwd.MouseDown += (s, e) => Jog(1);
            btnJogFwd.MouseUp += (s, e) => StopAxis();
            btnJogRev.MouseDown += (s, e) => Jog(-1);
            btnJogRev.MouseUp += (s, e) => StopAxis();

            y += 40;
            // 位置模式
            AddLabel("目标:", 20, y + 3, 40); var txtTarget = AddTextBox("0", 60, y, 60);
            var btnMoveAbs = AddButton("绝对移动到目标", 130, y, 120, (s, e) => MoveAbs(txtTarget));
            y += 35;
            AddLabel("距离:", 20, y + 3, 40); var txtDistance = AddTextBox("10", 60, y, 60);
            var btnMoveRelP = AddButton("相对正移", 130, y, 80, (s, e) => MoveRel(txtDistance, 1));
            var btnMoveRelN = AddButton("相对负移", 215, y, 80, (s, e) => MoveRel(txtDistance, -1));
            y += 40;
            // 状态
            lblStatus = AddLabel("状态: 未连接", 20, y, 450); y += 25;
            lblPos = AddLabel("位置: --", 20, y, 450); y += 25;
            lblAxisStatus = AddLabel("AXISSTATUS: --", 20, y, 450);
            this.ClientSize = new System.Drawing.Size(500, y + 60);

            // 定时器刷新
            _timer = new System.Windows.Forms.Timer { Interval = 200 };
            _timer.Tick += OnTimerTick;
            _timer.Start();

            btnDisconnect.Enabled = false;
            SetMotionButtons(false);
        }

        // ===== 控件工厂 =====
        private Label AddLabel(string text, int x, int y, int w) { var l = new Label { Text = text, Location = new System.Drawing.Point(x, y), Width = w }; this.Controls.Add(l); return l; }
        private TextBox AddTextBox(string text, int x, int y, int w) { var t = new TextBox { Text = text, Location = new System.Drawing.Point(x, y), Width = w }; this.Controls.Add(t); return t; }
        private Button AddButton(string text, int x, int y, int w, EventHandler click) { var b = new Button { Text = text, Location = new System.Drawing.Point(x, y), Width = w, Height = 28 }; if (click != null) b.Click += click; this.Controls.Add(b); return b; }

        private void SetMotionButtons(bool enabled) { btnJogFwd.Enabled = btnJogRev.Enabled = btnHome.Enabled = btnEnable.Enabled = btnDisable.Enabled = enabled; }

        // ===== 连接 =====
        private void OnConnect(object s, EventArgs e)
        {
            int ret = zmcaux.ZAux_FastOpen(2, txtIP.Text, 1000, out _handle);
            if (ret == 0 && _handle != IntPtr.Zero)
            {
                lblStatus.Text = "状态: 已连接";
                btnConnect.Enabled = false; btnDisconnect.Enabled = true;
                SetMotionButtons(true);
            }
            else { lblStatus.Text = "状态: 连接失败 ret=" + ret; _handle = IntPtr.Zero; }
        }

        private void OnDisconnect(object s, EventArgs e)
        {
            if (_handle != IntPtr.Zero) { zmcaux.ZAux_Close(_handle); _handle = IntPtr.Zero; }
            lblStatus.Text = "状态: 未连接";
            btnConnect.Enabled = true; btnDisconnect.Enabled = false;
            SetMotionButtons(false);
        }

        // ===== 使能 =====
        private void OnEnable(object s, EventArgs e) { zmcaux.ZAux_Direct_SetAxisEnable(_handle, _axisIndex, 1); }
        private void OnDisable(object s, EventArgs e) { zmcaux.ZAux_Direct_SetAxisEnable(_handle, _axisIndex, 0); }
        private void OnClearAlarm(object s, EventArgs e) { zmcaux.ZAux_Direct_SetParam(_handle, "AXIS_STOPREASON", _axisIndex, 0); zmcaux.ZAux_BusCmd_DriveClear(_handle, (uint)_axisIndex, 0); zmcaux.ZAux_Direct_SetAxisEnable(_handle, _axisIndex, 1); }

        // ===== 点动 =====
        private void Jog(int dir)
        {
            float speed = float.TryParse(txtSpeed.Text, out var v) ? v : 20f;
            zmcaux.ZAux_Direct_SetSpeed(_handle, _axisIndex, speed);
            zmcaux.ZAux_Direct_Single_Vmove(_handle, _axisIndex, dir);
        }
        private void StopAxis() { zmcaux.ZAux_Direct_Single_Cancel(_handle, _axisIndex, 2); }
        private void OnStop(object s, EventArgs e) { StopAxis(); }

        // ===== 位置模式 =====
        private void MoveAbs(TextBox txt)
        {
            float target = float.TryParse(txt.Text, out var v) ? v : 0;
            float speed = float.TryParse(txtSpeed.Text, out var s) ? s : 20f;
            zmcaux.ZAux_Direct_SetSpeed(_handle, _axisIndex, speed);
            zmcaux.ZAux_Direct_Single_MoveAbs(_handle, _axisIndex, target);
        }
        private void MoveRel(TextBox txt, int dir)
        {
            float dist = float.TryParse(txt.Text, out var v) ? v : 10f;
            float speed = float.TryParse(txtSpeed.Text, out var s) ? s : 20f;
            zmcaux.ZAux_Direct_SetSpeed(_handle, _axisIndex, speed);
            zmcaux.ZAux_Direct_Single_Move(_handle, _axisIndex, dir * dist);
        }

        // ===== 定时刷新 =====
        private void OnTimerTick(object s, EventArgs e)
        {
            if (_handle == IntPtr.Zero) return;
            float dpos = 0, mpos = 0, axisStatus = 0;
            int idle = 0, enable = 0;
            zmcaux.ZAux_Direct_GetDpos(_handle, _axisIndex, ref dpos);
            zmcaux.ZAux_Direct_GetMpos(_handle, _axisIndex, ref mpos);
            zmcaux.ZAux_Direct_GetParam(_handle, "AXISSTATUS", _axisIndex, ref axisStatus);
            zmcaux.ZAux_Direct_GetIfIdle(_handle, _axisIndex, ref idle);
            zmcaux.ZAux_Direct_GetAxisEnable(_handle, _axisIndex, ref enable);

            int st = (int)axisStatus;
            string stText = enable == 0 ? "未使能" :
                (st & 0x0200) != 0 ? "运动中" : (st & 0x0010) != 0 ? "正限位" : (st & 0x0020) != 0 ? "负限位" : (st & 0x0040) != 0 ? "报警" : "就绪";

            this.Invoke(new Action(() =>
            {
                lblPos.Text = $"DPOS={dpos:F2}  MPOS={mpos:F2}  空闲={idle}  使能={enable}";
                lblAxisStatus.Text = $"AXISSTATUS={st} ({stText})";
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e) { OnDisconnect(null, null); base.OnFormClosing(e); }
    }
}
