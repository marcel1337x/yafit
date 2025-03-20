using System.Drawing;
using YAFIT.Common.Helper;

namespace YAFIT.UI.UserControls
{
    public class ControlConstants
    {

        internal static Color[] COLOR_SCHEME { get { return _colorScheme ??= CreateColorScheme(); } }
        private static Color[]? _colorScheme;

        public static Color FormularColorScheme(int id)
        {
            return id switch
            {
                1 => Color.FromArgb(255, 0, 180, 0),
                //2 => Color.FromArgb(255, 0, 255, 0),
                2 => Color.FromArgb(255, 124, 255, 124),
                3 => Color.FromArgb(255, 255, 255, 128),
                4 => Color.FromArgb(255, 255, 91, 91),
                //6 => Color.FromArgb(255, 255, 4, 4),
                _ => Color.White
            };
        }

        public static Color Formular1ColorGood(int id)
        {
            return id switch
            {
                0 => Color.FromArgb(255, 0, 180, 0),
                1 => Color.FromArgb(255, 0, 255, 0),
                _ => Color.FromArgb(255, 124, 255, 124),
            };
        }
        public static Color Formular1ColorBad(int id)
        {
            return id switch
            {
                0 => Color.FromArgb(255, 255, 255, 128),
                1 => Color.FromArgb(255, 255, 91, 91),
                _ => Color.FromArgb(255, 255, 4, 4),
            };
        }
        private static Color[] CreateColorScheme()
        {
            Color[] colorScheme = new Color[101];

            Color red = Color.Red;
            Color yellow = Color.Yellow;
            Color green = Color.Green;

            for (int i = 0; i < colorScheme.Length; i++)
            {
                Color color = AddGray(ColorHelper.GradientPick(red, yellow, green, i), 30);
                colorScheme[i] = color;
            }
            return colorScheme;
        }


        internal static Color AddGray(Color color, int gray)
        {
            return Color.FromArgb(color.A,
                Math.Min(color.R + gray, 255),
                Math.Min(color.G + gray, 255),
                Math.Min(color.B + gray, 255));
        }
    }
}
