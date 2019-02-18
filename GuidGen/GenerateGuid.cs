using System;
using System.Windows.Forms;

namespace GuidGen
{
    public partial class GenerateGuid : Form
    {
        public GenerateGuid()
        {
            InitializeComponent();
        }

        private void GenerateGuid_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - 10;

            string guid = Guid.NewGuid().ToString();
            Clipboard.SetText(guid);

            lblGuidGenerated.Text = $"GUID \"{guid}\" generiert!";

            //ToolTip hint = new ToolTip();
            //hint.IsBalloon = true;
            //hint.ToolTipTitle = "GUID wurde generiert";
            //hint.ToolTipIcon = ToolTipIcon.Info;
            //hint.Show(string.Empty, this, 0);
            //hint.Show(lblGuidGenerated.Text, this, 0, 0);

            timWaitTimer.Enabled = true;
        }

        private void timWaitTimer_Tick(object sender, EventArgs e)
        {
            timWaitTimer.Enabled = false;

            Application.Exit();
        }

    }
}
