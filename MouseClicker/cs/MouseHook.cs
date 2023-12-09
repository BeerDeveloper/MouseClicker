using System.Runtime.InteropServices;

namespace MouseClicker.cs
{
    public class MouseHook
    {
        private object coordinatesMutex;
        private object mutex;

        #region STATES
        private Point _mouseCoordinates;
        public Point mouseCoordinates
        {
            get
            {
                lock(coordinatesMutex)
                {
                    return _mouseCoordinates;
                }
            }
        }

        private bool _leftClickPressed;
        public bool leftClickPressed
        {
            get
            {
                lock (mutex)
                {
                    return _leftClickPressed;
                }
            }
        }

        private bool _rightClickPressed;
        public bool rightClickPressed
        {
            get
            {
                lock (mutex)
                {
                    return _rightClickPressed;
                }
            }
        }

        private bool _middleClickPressed;
        public bool middleClickPressed
        {
            get
            {
                lock (mutex)
                {
                    return _middleClickPressed;
                }
            }
        }
        #endregion

        #region DEFINING CONSTANTS
        private const Int32 WM_MOUSEMOVE = 0x0200;

        private const Int32 WM_LBUTTONDOWN = 0x0201;
        private const Int32 WM_LBUTTONUP = 0x0202;
        private const Int32 WM_LBUTTONDBLCLK = 0x0203;
        private const Int32 WM_RBUTTONDOWN = 0x0204;
        private const Int32 WM_RBUTTONUP = 0x0205;
        private const Int32 WM_RBUTTONDBLCLK = 0x0206;
        private const Int32 WM_MBUTTONDOWN = 0x0207;
        private const Int32 WM_MBUTTONUP = 0x0208;
        private const Int32 WM_MBUTTONDBLCLK = 0x0209;

        private const Int32 WM_MOUSEWHEEL = 0x020A;

        private const Int32 WM_XBUTTONDOWN = 0x020B;
        private const Int32 WM_XBUTTONUP = 0x020C;
        private const Int32 WM_XBUTTONDBLCLK = 0x020D;
        #endregion

        public bool hooked { get; private set; } = false;

        #region DLL
        [Serializable]
        public struct MSG
        {
            public IntPtr hwnd;

            public IntPtr lParam;

            public int message;

            public int pt_x;

            public int pt_y;

            public int time;

            public IntPtr wParam;
        }

        //public delegate IntPtr HookDelegate(
        //    Int32 Code, IntPtr wParam, IntPtr lParam);
        private delegate IntPtr HookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hHook, Int32 nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        private static extern IntPtr UnhookWindowsHookEx(IntPtr hHook);

        [DllImport("User32.dll")]
        private static extern IntPtr SetWindowsHookEx(Int32 idHook, HookDelegate lpfn, IntPtr hmod, Int32 dwThreadId);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);

        [DllImport("user32.dll")]
        public static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll")]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        private HookDelegate mouseDelegate;
        private IntPtr mouseHandle;

        private const Int32 WH_MOUSE_LL = 14;
        #endregion

        public MouseHook()
        {
            mutex = new object();
            coordinatesMutex = new object();
            _mouseCoordinates = new Point();
            mouseDelegate = MouseHookDelegate;
        }

        public void setHook(bool on)
        {
            if (hooked == on) return;
            if (on)
            {
                IntPtr user32HandlePtr = GetModuleHandle("user32");
                if (user32HandlePtr == 0)
                    return;
                mouseHandle = SetWindowsHookEx(WH_MOUSE_LL, mouseDelegate, user32HandlePtr, 0);
                if (mouseHandle != IntPtr.Zero) hooked = true;
            }
            else
            {
                UnhookWindowsHookEx(mouseHandle);
                hooked = false;
            }
        }

        private IntPtr MouseHookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam)
        {
            //VK_LBUTTON    0x01 Left mouse button
            //VK_RBUTTON    0x02 Right mouse button
            //VK_MBUTTON    0x04 Middle mouse button
            //VK_XBUTTON1   0x05 X1 mouse button
            //VK_XBUTTON2   0x06 X2 mouse button
            // see https://msdn.microsoft.com/en-us/library/windows/desktop/ms644970(v=vs.85).aspx

            //mouseData:
            //If the message is WM_MOUSEWHEEL, the high-order word of this member is the wheel delta.The low-order word is reserved.
            //    A positive value indicates that the wheel was rotated forward, away from the user;
            //    a negative value indicates that the wheel was rotated backward, toward the user. 
            //    One wheel click is defined as WHEEL_DELTA, which is 120.(0x78 or 0xFF88)
            //If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, or WM_NCXBUTTONDBLCLK, 
            //    the high - order word specifies which X button was pressed or released, 
            //    and the low - order word is reserved.This value can be one or more of the following values.Otherwise, mouseData is not used.
            //XBUTTON1  = 0x0001 The first X button was pressed or released.
            //XBUTTON2  = 0x0002  The second X button was pressed or released.

            MSLLHOOKSTRUCT lparam = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
            int command = (int)wParam;
            if (Code <= 0 || command == WM_LBUTTONDBLCLK || command == WM_RBUTTONDBLCLK)
                return CallNextHookEx(mouseHandle, Code, wParam, lParam);

            Console.WriteLine(command);

            if (command == WM_MOUSEMOVE)
            {
                lock(coordinatesMutex)
                {
                    _mouseCoordinates.X = lparam.pt.X;
                    _mouseCoordinates.Y = lparam.pt.Y;
                }
            }

            if (command == WM_LBUTTONDOWN)
            {
                lock (mutex)
                {
                    _leftClickPressed = true;
                }
            }
            else if (command == WM_LBUTTONUP)
            {
                lock (mutex)
                {
                    _leftClickPressed = false;
                }
            }
            else if (command == WM_RBUTTONDOWN)
            {
                lock (mutex)
                {
                    _rightClickPressed = true;
                }
            }
            else if (command == WM_RBUTTONUP)
            {
                _rightClickPressed = false;
            }
            else if (command == WM_MBUTTONDOWN)
            {
                lock (mutex)
                {
                    _middleClickPressed = true;
                }
            }
            else if (command == WM_MBUTTONUP)
            {
                lock (mutex)
                {
                    _middleClickPressed = false;
                }
            }
            else if (command == WM_MOUSEWHEEL)
            {
                //int wheelvalue = (Int16)(lparam.mouseData >> 16) < 0 ? -120 : 120; // Forward = 120, Backward = -120
            }

            return CallNextHookEx(mouseHandle, Code, wParam, lParam);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public Point pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
    }
}
