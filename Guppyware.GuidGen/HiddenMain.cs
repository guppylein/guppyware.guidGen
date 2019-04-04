using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guppyware.GuidGen.Properties;

namespace Guppyware.GuidGen
{
    public partial class HiddenMain : Form
    {
        private readonly HotkeyManager hotkeyManager;
        protected GenerateGuid GuidGeneratedForm;

        public HiddenMain()
        {
            InitializeComponent();

            hotkeyManager = new HotkeyManager();
            hotkeyManager.GlobalHotKeyPressed += HotKeyManager_GlobalHotKeyPressed;

            RegisterHotKey(hotkeyManager.Handle, 567, Constants.CTRL + Constants.ALT, (int) Keys.PrintScreen);
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private void GenerateGuid()
        {
            if (timWaitTimer.Enabled)
                timWaitTimer.Enabled = false;

            notifyIcon.Icon = Resources.hashtag_highlighted;
            timWaitTimer.Enabled = true;

            var guid = GuidGenerator.Generate();

            if (GuidGeneratedForm == null)
                GuidGeneratedForm = new GenerateGuid();

            GuidGeneratedForm.ShowGuid(guid);
        }

        private void HotKeyManager_GlobalHotKeyPressed(object sender, EventArgs e)
        {
            GenerateGuid();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            UnregisterHotKey(hotkeyManager.Handle, 567);

            Close();
            Environment.Exit(0);
        }

        private void mnuGenerateGuid_Click(object sender, EventArgs e)
        {
            GenerateGuid();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GenerateGuid();
        }

        private void timWaitTimer_Tick(object sender, EventArgs e)
        {
            timWaitTimer.Enabled = false;

            notifyIcon.Icon = Resources.hashtag;
        }
    }
}