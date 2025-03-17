using FluentNHibernate.Automapping;
using System.Drawing;
using YAFIT.Common.Helper;

namespace YAFIT.UI.UserControls
{
    public class ControlConstants
    {

        internal static Color[] COLOR_SCHEME { get { return _colorScheme ??= CreateColorScheme(); } }
        private static Color[]? _colorScheme;


        public static Color Formular1ColorGood(int id)
        {
            return id switch
            {
                0 => Color.FromArgb(255, 96, 36, 155),
                1 => Color.FromArgb(255, 49, 97, 168),
                _ => Color.FromArgb(255, 77, 115, 38),
            };
        }
        public static Color Formular1ColorBad(int id)
        {
            return id switch
            {
                0 => Color.FromArgb(255, 204, 184, 0),
                1 => Color.FromArgb(255, 204, 122, 0),
                _ => Color.FromArgb(255, 205, 51, 51),
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
