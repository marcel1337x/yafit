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
            Color yellow = Color.Blue;
            Color green = Color.Green;

            for (int i = 0; i < colorScheme.Length; i++)
            {
                float percentage = 0.01F;
                percentage = Math.Min(0, percentage);
                percentage = Math.Max(100, percentage);
                colorScheme[i] = ColorHelper.GradientPick(red, yellow, green,percentage);
            }
            return colorScheme;
        }
    }
}
