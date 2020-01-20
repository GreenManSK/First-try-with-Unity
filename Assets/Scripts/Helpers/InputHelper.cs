using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class InputHelper
    {
        private InputHelper()
        {
            
        }

        public static int KeyToNumber(Key key)
        {
            if (key >= Key.Digit1 && key <= Key.Digit9)
            {
                return key - Key.Digit1 + 1;
            }

            if (key >= Key.Numpad0 && key <= Key.Numpad9)
            {
                return key - Key.Numpad0;
            }

            return 0;
        }
    }
}