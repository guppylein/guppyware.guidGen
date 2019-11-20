﻿//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;
//using System.Windows.Input;
//using System.Windows.Interop;

//namespace GuidGen
//{
//    /// <summary>
//    /// Event Args for the event that is fired after the hot key has been pressed.
//    /// </summary>
//    public class KeyPressedEventArgs : EventArgs
//    {
//        private ModifierKeys _modifier;
//        private Keys _key;

//        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
//        {
//            _modifier = modifier;
//            _key = key;
//        }

//        public ModifierKeys Modifier
//        {
//            get { return _modifier; }
//        }

//        public Keys Key
//        {
//            get { return _key; }
//        }
//    }

//    /// <summary>
//    /// The enumeration of possible modifiers.
//    /// </summary>
//    [Flags]
//    public enum ModifierKeys : uint
//    {
//        Alt = 1,
//        Control = 2,
//        Shift = 4,
//        Win = 8
//    }


//    // https://stackoverflow.com/questions/48935/how-can-i-register-a-global-hot-key-to-say-ctrlshiftletter-using-wpf-and-ne
//    public class HotKey : IDisposable
//    {
//        private static Dictionary<int, HotKey> _dictHotKeyToCalBackProc;

//        [DllImport("user32.dll")]
//        private static extern bool RegisterHotKey(IntPtr hWnd, int id, UInt32 fsModifiers, UInt32 vlc);

//        [DllImport("user32.dll")]
//        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

//        public const int WmHotKey = 0x0312;

//        private bool _disposed = false;

//        public Key Key { get; private set; }
//        public KeyModifier KeyModifiers { get; private set; }
//        public Action<HotKey> Action { get; private set; }
//        public int Id { get; set; }

//        // ******************************************************************
//        public HotKey(Key k, KeyModifier keyModifiers, Action<HotKey> action, bool register = true)
//        {
//            Key = k;
//            KeyModifiers = keyModifiers;
//            Action = action;
//            if (register)
//            {
//                Register();
//            }
//        }

//        // ******************************************************************
//        public bool Register()
//        {
//            int virtualKeyCode = KeyInterop.VirtualKeyFromKey(Key);
//            Id = virtualKeyCode + ((int)KeyModifiers * 0x10000);
//            bool result = RegisterHotKey(IntPtr.Zero, Id, (UInt32)KeyModifiers, (UInt32)virtualKeyCode);

//            if (_dictHotKeyToCalBackProc == null)
//            {
//                _dictHotKeyToCalBackProc = new Dictionary<int, HotKey>();
//                ComponentDispatcher.ThreadFilterMessage += new ThreadMessageEventHandler(ComponentDispatcherThreadFilterMessage);
//            }

//            _dictHotKeyToCalBackProc.Add(Id, this);

//            Debug.Print(result.ToString() + ", " + Id + ", " + virtualKeyCode);
//            return result;
//        }

//        // ******************************************************************
//        public void Unregister()
//        {
//            HotKey hotKey;
//            if (_dictHotKeyToCalBackProc.TryGetValue(Id, out hotKey))
//            {
//                UnregisterHotKey(IntPtr.Zero, Id);
//            }
//        }

//        // ******************************************************************
//        private static void ComponentDispatcherThreadFilterMessage(ref MSG msg, ref bool handled)
//        {
//            if (!handled)
//            {
//                if (msg.message == WmHotKey)
//                {
//                    HotKey hotKey;

//                    if (_dictHotKeyToCalBackProc.TryGetValue((int)msg.wParam, out hotKey))
//                    {
//                        if (hotKey.Action != null)
//                        {
//                            hotKey.Action.Invoke(hotKey);
//                        }
//                        handled = true;
//                    }
//                }
//            }
//        }

//        // ******************************************************************
//        // Implement IDisposable.
//        // Do not make this method virtual.
//        // A derived class should not be able to override this method.
//        public void Dispose()
//        {
//            Dispose(true);
//            // This object will be cleaned up by the Dispose method.
//            // Therefore, you should call GC.SupressFinalize to
//            // take this object off the finalization queue
//            // and prevent finalization code for this object
//            // from executing a second time.
//            GC.SuppressFinalize(this);
//        }

//        // ******************************************************************
//        // Dispose(bool disposing) executes in two distinct scenarios.
//        // If disposing equals true, the method has been called directly
//        // or indirectly by a user's code. Managed and unmanaged resources
//        // can be _disposed.
//        // If disposing equals false, the method has been called by the
//        // runtime from inside the finalizer and you should not reference
//        // other objects. Only unmanaged resources can be _disposed.
//        protected virtual void Dispose(bool disposing)
//        {
//            // Check to see if Dispose has already been called.
//            if (!this._disposed)
//            {
//                // If disposing equals true, dispose all managed
//                // and unmanaged resources.
//                if (disposing)
//                {
//                    // Dispose managed resources.
//                    Unregister();
//                }

//                // Note disposing has been done.
//                _disposed = true;
//            }
//        }
//    }

//    // ******************************************************************
//    [Flags]
//    public enum KeyModifier
//    {
//        None = 0x0000,
//        Alt = 0x0001,
//        Ctrl = 0x0002,
//        NoRepeat = 0x4000,
//        Shift = 0x0004,
//        Win = 0x0008
//    }

//    // ******************************************************************
//}