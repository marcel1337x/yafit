using System.Drawing;
using YAFIT.Common.Helper;

namespace YAFIT.UI.UserControls
{
    public class ControlConstants
    {

        internal static Color[] COLOR_SCHEME { get { return _colorScheme ??= CreateColorScheme(); } }
        private static Color[]? _colorScheme;

        private static Color[] CreateColorScheme()
        {
            Color[] colorScheme = new Color[101];

            Color red = Color.Red;
            Color yellow = Color.Yellow;
            Color green = Color.Green;

            for (int i = 0; i < colorScheme.Length; i++)
            {
                colorScheme[i] = ColorHelper.GradientPick(red, yellow, green,i);
            }
            return colorScheme;
        }
    }
}
