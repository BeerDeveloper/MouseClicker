using System.Runtime.InteropServices;

namespace MouseClicker.cs
{
    public class MouseHandler
    {
        #region ClickMouse
        [DllImport("user32.dll",
           CharSet = CharSet.Auto,
           CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(long dwFlags,
                                      long dx,
                                      long dy,
                                      long cButtons,
                                      long dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public void Click(Point pt)
        {
            Cursor.Position = pt;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, pt.X, pt.Y, 0, 0);
        }
        #endregion

        #region GetLeftMouseClick
        [DllImport("user32.dll")]
        private static extern bool GetAsyncKeyState(UInt16 virtualKeyCode);

        private const int VK_LBUTTON = 0x01;

        bool pressed;
        bool released;

        public bool GetLeftMousePressed()
        {
            pressed = false;

            if (GetAsyncKeyState(VK_LBUTTON) == true && released)
            {
                pressed = true;
                released = false;
            }
            else if (GetAsyncKeyState(VK_LBUTTON) == false)
            {
                released = true;
                pressed = false;
            }

            return pressed;
        }
        #endregion

        public MouseHandler()
        {
            pressed = false;
            released = true;
        }

        public Point GetCursorPosition()
        {
            return Cursor.Position;
        }
    }
}
