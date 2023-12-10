using System.Runtime.InteropServices;

namespace MouseClicker.cs
{
    public class MouseHandler
    {
        public MouseHandler()
        {
            pressed = false;
            released = true;
        }

        /// <summary>
        /// Returns the mouse cursor position as a <see cref="Point"/>
        /// </summary>
        /// <returns>
        /// A <see cref="Point"/> containing coordinates for the cursor position
        /// </returns>
        public Point GetCursorPosition()
        {
            return Cursor.Position;
        }

        #region ClickMouse
        [DllImport("user32.dll",
           CharSet = CharSet.Auto,
           CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(long dwFlags,
                                      long dx,
                                      long dy,
                                      long cButtons,
                                      long dwExtraInfo);

        //Identifier for left mouse click down
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        //Identifier for left mouse click up
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        /// <summary>
        /// Moves the mouse cursor to a specified location and simulates a left mouse click
        /// </summary>
        /// <param name="point">The point of the screen to which move the mouse cursor</param>
        public void Click(Point point)
        {
            Cursor.Position = point;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, point.X, point.Y, 0, 0);
        }
        #endregion

        #region GetLeftMouseClick
        [DllImport("user32.dll")]
        private static extern bool GetAsyncKeyState(UInt16 virtualKeyCode);

        //Identifier for left mouse button
        private const int VK_LBUTTON = 0x01;

        bool pressed;
        bool released;

        /// <summary>
        /// Checks if the left mouse button has been pressed since the last call of this function
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if left mouse button has been pressed, otherwise <see langword="false"/>
        /// </returns>
        public bool GetLeftMousePressed()
        {
            /*
            * A press/release mechanism is used as GetAsyncKeyState returns true 
            * for a specific key until another key is pressed. This allows to only register one
            * input rather than getting stuck on multiple ones
            * (Safety measure, as this function version seems to work well even without)
            */
            pressed = false;

            if (GetAsyncKeyState(VK_LBUTTON) == true && released)
            {
                //Only register pressed as true if the key has been released as well
                pressed = true;
                released = false;
            }
            else if (GetAsyncKeyState(VK_LBUTTON) == false)
            {
                //When the state results as false, count that key as released
                released = true;
                pressed = false;
            }

            return pressed;
        }
        #endregion
    }
}
