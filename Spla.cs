using System;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace EN2NGui
{
    internal partial class Spla : Form
    {
        public Cursor tcursor;
        private Timer UpdateCursor;
        internal Spla()
        {
            InitializeComponent();
            BackgroundImage = MiscData.spl;
            Text = StringRes.GetString(StringRes.StringT.Hello);
            LStats.Text = StringRes.GetString(StringRes.StringT.Init);
            Ebutton.Text = ">>" + StringRes.GetString(StringRes.StringT.Exit);
            Cbutton.Text = "*" + StringRes.GetString(StringRes.StringT.ContE);
            tcursor = Cursor;
        }

        internal void UpdateLabel(string s)
        {
            if (LStats.InvokeRequired)
            {
                Action<string> actionDelegate = (x) => { LStats.Text = x; };
                LStats.Invoke(actionDelegate, s);
            }
            else
            {
                LStats.Text = s;
            }
        }

        internal void UpdateButton(bool b)
        {
            if (Ebutton.InvokeRequired)
            {
                Action<bool> actionDelegate = (x) => { Ebutton.Visible = x; Ebutton.Enabled = x; };
                Ebutton.Invoke(actionDelegate, b);
            }
            else
            {
                Ebutton.Visible = b;
                Ebutton.Enabled = b;
            }
        }

        internal void UpdateCButton(bool b)
        {
            if (Cbutton.InvokeRequired)
            {
                Action<bool> actionDelegate = (x) => { Cbutton.Visible = x; Cbutton.Enabled = x; };
                Cbutton.Invoke(actionDelegate, b);
            }
            else
            {
                Cbutton.Visible = b;
                Cbutton.Enabled = b;
            }
        }

        private void UpdateCursorF(object sender, EventArgs e)
        {
            if (Cursor != tcursor)
                Cursor = tcursor;
        }
        private void Spla_Shown(object sender, EventArgs e)
        {
            Thread T = new Thread(InitTh.getInstance(this).Do);
            T.Start();
            UpdateCursor = new Timer();
            UpdateCursor.Tick += new EventHandler(UpdateCursorF);
            UpdateCursor.Interval = 1200;
            UpdateCursor.Start();
        }

        private void Ebutton_Click(object sender, EventArgs e)
        {
            MiscData.isSplashExitAbornomal = true;
            UpdateCursor.Stop();
            Application.Exit();
        }

        private void Spla_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateCursor.Stop();
        }

        private void Cbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal new void Close()
        {
            if (InvokeRequired)
            {
                Action act = new Action(base.Close);
                Invoke(act);
            }
            else
            {
                base.Close();
            }
        }
    }
}
