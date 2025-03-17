using System.Diagnostics;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace YAFIT.UI.UserControls
{
    /// <summary>
    /// Interaktionslogik für FormEntryTextCheckbox.xaml
    /// </summary>
    public partial class FormEntryIntCheckboxDouble : UserControl
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
        public string Text2
        {
            get { return _text2; }
            set { _text2 = value; }
        }

        public FormEntryIntCheckboxDouble()
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

                //int percentageInt = (int)(percentage * 100.0F);
                //
                //_resultsColor[i] = ControlConstants.COLOR_SCHEME[percentageInt];
                //_borderReference[i].Background = ToSolidColorBrush(_resultsColor[i]);
            }
            float halfPercentage = _resultsPercentage.All(x => x <= 0.1) == true ? 0.5F : _resultsPercentage.Max() / 2.0F;
            
            var ordered = _resultsPercentage
                .Select((x, i) => new { Index = i, Percentage = x })
                .GroupBy(x => x.Percentage >= halfPercentage)
                .OrderByDescending(x => x.Key)
                .ToArray();
            for (int i = 0; i < ordered.Count(); i++)
            {
                var order = ordered[i];


                int[] array = order.OrderByDescending(x => x.Percentage).Select(x => x.Index).ToArray();
                for(int x = 0; x < array.Length; x++) { 

                    System.Drawing.Color color = order.Key == true ? ControlConstants.Formular1ColorGood(x) : ControlConstants.Formular1ColorBad(x);
                    int indicies = array[x];
                    _resultsColor[indicies] = color;
                    _borderReference[indicies].Background = ToSolidColorBrush(_resultsColor[indicies]);
                }
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
        private string _text2 = string.Empty;
        private readonly Border[] _borderReference;
    }
}
