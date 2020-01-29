using UnityEngine;

namespace Constants
{
    public class Colors
    {
        public static readonly Color Orange = GetColor("#d47564");
        public static readonly Color Yellow = GetColor("#e8c498");
        public static readonly Color White = GetColor("#ecece0");
        public static readonly Color Turquoise = GetColor("#4fa4a5");
        public static readonly Color Green = GetColor("#aad395");
        public static readonly Color Black = GetColor("#3b324a");
        public static readonly Color Blue = GetColor("#5c6182");
        
        private Colors()
        {
        }

        private static Color GetColor(string hex)
        {
            Color color;
            ColorUtility.TryParseHtmlString(hex, out color);
            return color;
        }
    }
}