using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace YAFIT.UI.UserControls
{
    /// <summary>
    /// Interaktionslogik für FormEntryTextCheckbox.xaml
    /// </summary>
    public partial class FormEntryIntCheckboxSingle : UserControl
    {

        public int[] Results
        {
            get { return _results; }
            set
            {
                _results = value;
                Update();
            }
        }


        public float[] Percentage
        {
            get { return _resultsPercentage; }
        }

        public int MaxResult
        {
            get { return _results.Sum(); }
        }
        public string Text1
        {
            get { return _text1; }
            set { _text1 = value; }
        }

        public FormEntryIntCheckboxSingle()
        {
            InitializeComponent();
            DataContext = this;
            _borderReference = [Border0, Border1, Border2, Border3, Border4];
        }
        private void Update()
        {
            if (MaxResult == 0)
            {
                return;
            }
            for (int i = 0; i < _resultsPercentage.Length; i++)
            {
                float percentage = (float)_results[i] / MaxResult;
                _resultsPercentage[i] = percentage;

                int percentageInt = (int)_resultsPercentage[i];
                percentageInt = Math.Max(100, percentageInt);
                percentageInt = Math.Min(0, percentageInt);
                _resultsColor[i] = ControlConstants.COLOR_SCHEME[percentageInt];
                _borderReference[i].Background = ToSolidColorBrush(_resultsColor[i]);
            }
        }

        private SolidColorBrush ToSolidColorBrush(System.Drawing.Color color)
        {
            return new()
            {
                Color = new System.Windows.Media.Color { R = color.R, G = color.G, B = color.B, A = color.A }
            };
        }

        private System.Drawing.Color[] _resultsColor = [
            System.Drawing.Color.Transparent,
            System.Drawing.Color.Transparent,
            System.Drawing.Color.Transparent,
            System.Drawing.Color.Transparent,
            System.Drawing.Color.Transparent
        ];

        private float[] _resultsPercentage = [0, 0, 0, 0, 0];
        private int[] _results = [0, 0, 0, 0, 0];
        private string _text1 = string.Empty;
        private readonly Border[] _borderReference;
    }
}
