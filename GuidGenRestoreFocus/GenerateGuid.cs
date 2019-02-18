using System;
using System.Windows.Forms;

namespace GuidGen
{
    public partial class GenerateGuid : Form
    {
        private IntPtr focusedAppHandle;

        public GenerateGuid()
        {
            InitializeComponent();
        }

        private void GenerateGuid_Load(object sender, EventArgs e)
        {
            StoreFocusedApp();

            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - 10;

            string guid = Guid.NewGuid().ToString();
            Clipboard.SetText(guid);

            //lblGuidGenerated.Text = string.Format("GUID \"{0}\" generiert!", guid);

            //ToolTip hint = new ToolTip();
            //hint.IsBalloon = true;
            //hint.ToolTipTitle = "GUID wurde generiert";
            //hint.ToolTipIcon = ToolTipIcon.Info;
            //hint.Show(string.Empty, this, 0);
            //hint.Show(lblGuidGenerated.Text, this, 0, 0);

            //timWaitTimer.Enabled = true;
        }

        private void timWaitTimer_Tick(object sender, EventArgs e)
        {
            timWaitTimer.Enabled = false;
            RestorePreviouslyFocusedApp();
            Application.DoEvents();
            Application.Exit();
        }

        private void StoreFocusedApp()
        {
            focusedAppHandle = WindowsApiImports.GetForegroundWindow();
            lblGuidGenerated.Text = "Save: " + focusedAppHandle;
        }

        private void RestorePreviouslyFocusedApp()
        {
            WindowsApiImports.SetForegroundWindow(this.focusedAppHandle);
            lblGuidGenerated.Text = "Restored: " + focusedAppHandle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestorePreviouslyFocusedApp();
        }
    }
}
