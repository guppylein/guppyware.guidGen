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
            Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 10;
            Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 10;
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
