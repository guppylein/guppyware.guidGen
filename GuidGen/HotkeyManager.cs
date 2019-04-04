using System;
using System.Windows.Forms;

namespace GuidGen
{
    public sealed class HotkeyManager : NativeWindow, IDisposable
    {
        public event EventHandler<EventArgs> GlobalHotKeyPressed;

        public HotkeyManager()
        {
            CreateHandle(new CreateParams());
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                if (m.WParam.ToInt32() == 567)
                {
                    GlobalHotKeyPressed?.Invoke(this, new EventArgs());
                    //MessageBox.Show("HotKey ID: 567 has been pressed");
                }
            }
            base.WndProc(ref m);
        }

        public void Dispose()
        {
            DestroyHandle();
        }
    }
}