using System;
using System.Windows.Forms;

namespace Guppyware.GuidGen
{
    public partial class GenerateGuid : Form
    {
        public GenerateGuid()
        {
            InitializeComponent();
        }

        private void GenerateGuid_Load(object sender, EventArgs e)
        {
            Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 10;
            Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 10;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit (which hides window from Alt + Tab)
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        public void ShowGuid(string guid)
        {
            lblGuidGenerated.Text = $"GUID \"{guid}\" generiert!";
            Show();

            if (timWaitTimer.Enabled)
                timWaitTimer.Enabled = false;

            timWaitTimer.Enabled = true;
        }

        private void timWaitTimer_Tick(object sender, EventArgs e)
        {
            timWaitTimer.Enabled = false;

            Hide();
        }
    }
}
