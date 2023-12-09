using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseClicker.cs
{
    public class KeyboardHandler
    {
        [DllImport("user32.dll")]
        private static extern bool GetAsyncKeyState(UInt16 virtualKeyCode);

        private const int S_Key = 0x53;

        bool pressed;
        bool released;

        public bool GetSKeyPressed()
        {
            pressed = false;

            if (GetAsyncKeyState(S_Key) == true && released)
            {
                pressed = true;
                released = false;
            }
            else if (GetAsyncKeyState(S_Key) == false)
            {
                released = true;
                pressed = false;
            }

            return pressed;
        }
    }
}
