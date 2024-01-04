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

        //Identifier for the S key
        private const int S_Key = 0x53;

        bool pressed;
        bool released;

        /// <summary>
        /// Checks if the S keyboard key has been pressed since the last call of this function
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if S has been pressed, otherwise <see langword="false"/>
        /// </returns>
        public bool GetSKeyPressed()
        {
            /*
             * A press/release mechanism is used as GetAsyncKeyState returns true 
             * for a specific key until another key is pressed. This allows to only register one
             * input rather than getting stuck on multiple ones
             * (Safety measure, as this function version seems to work well even without)
             */
            pressed = false;

            if (GetAsyncKeyState(S_Key) == true && released)
            {
                //Only register pressed as true if the key has been released as well
                pressed = true;
                released = false;
            }
            else if (GetAsyncKeyState(S_Key) == false)
            {
                //When the state results as false, count that key as released
                released = true;
                pressed = false;
            }

            return pressed;
        }
    }
}
