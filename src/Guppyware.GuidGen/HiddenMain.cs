using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guppyware.GuidGen.Data;
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

            LoadWellKnownGuids();
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private void LoadWellKnownGuids()
        {
            var guidLoader = new GuidLoader();
            guidLoader.Load();

            var wellKnownGuids = guidLoader.WellKnownGuids;
            foreach(var wellKnownGuid in wellKnownGuids)
            {
                var subItem = new ToolStripMenuItem(wellKnownGuid.Name);
                subItem.Tag = wellKnownGuid.Id;
                subItem.Click += SubItem_Click;
                mnuWellKnownGuids.DropDownItems.Add(subItem);
            }
        }

        private void SubItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }

            var guid = Guid.Parse(item.Tag.ToString());
            Clipboard.SetText(guid.ToString());

            if (GuidGeneratedForm == null)
                GuidGeneratedForm = new GenerateGuid();

            GuidGeneratedForm.ShowGuid(guid.ToString());
        }

        private void GenerateGuid()
        {
            if (timWaitTimer.Enabled)
                timWaitTimer.Enabled = false;

            notifyIcon.Icon = Resources.guidgen_highlighted;
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

            notifyIcon.Icon = Resources.guidgen;
        }
    }
}