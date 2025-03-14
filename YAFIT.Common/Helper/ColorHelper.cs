using System.Drawing;

namespace YAFIT.Common.Helper
{
    public class ColorHelper
    {
        public static Color GradientPick(Color startColor, Color endColor, float percentage)
        {
            int r = (int)(startColor.R + (endColor.R - startColor.R) * percentage);
            int g = (int)(startColor.G + (endColor.G - startColor.G) * percentage);
            int b = (int)(startColor.B + (endColor.B - startColor.B) * percentage);

            return Color.FromArgb(r, g, b);
        }
        public static Color GradientPick(Color startColor,Color middleColor, Color endColor, float percentage)
        {
            if (percentage <= 50)
            {
                float adjustedPercentage = percentage / 50f;
                return GradientPick(startColor, middleColor, adjustedPercentage);
            }
            else
            {
                // Prozentsatz im Bereich von Mittelfarbe zu Endfarbe
                float adjustedPercentage = (percentage - 50) / 50f;
                return GradientPick(middleColor, endColor, adjustedPercentage);
            }
        }
    }
}
