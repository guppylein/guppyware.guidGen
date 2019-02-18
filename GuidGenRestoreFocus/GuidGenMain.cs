using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuidGen
{
    public partial class GuidGenMain : Form
    {
        //KeyboardHook hook = new KeyboardHook();

        public GuidGenMain()
        {
            InitializeComponent();

            //// register the event that is fired after the key press.
            //hook.KeyPressed +=
            //    new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            //// register the control + alt + F12 combination as hot key.
            //hook.RegisterHotKey(GuidGen.ModifierKeys.Control | GuidGen.ModifierKeys.Alt,
            //    Keys.F12);


        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int MOD_CONTROL = 0x0002;
        const int MOD_SHIFT = 0x0004;
        const int WM_HOTKEY = 0x0312;

        private void GuidGenMain_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, 1, MOD_CONTROL + MOD_SHIFT, (int)Keys.L);
        }

        private void GuidGenMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 1);
        }

        //void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        //{
        //    // show the keys pressed in a label.
        //    label1.Text = e.Modifier.ToString() + " + " + e.Key.ToString();
        //}

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY /*&& (int)m.WParam == 1*/)
                MessageBox.Show("Hotkey X erhalten.");
            //if (m.Msg == WM_HOTKEY && (int)m.WParam == 2)
            //    MessageBox.Show("Hotkey Y erhalten.");
            base.WndProc(ref m);
        }

    }
}
