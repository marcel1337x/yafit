using MySqlX.XDevAPI.Common;
using System.Windows.Controls;

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
        }

        private void Update()
        {
            float one = (float)Math.Round(MaxResult / 100.0F,2);
            for(int i = 0; i < _resultsPercentage.Length; i++)
            {
                _resultsPercentage[i] = _results[i] * one;
            }
        }


        private float[] _resultsPercentage = [0,0,0,0,0];
        private int[] _results = [0, 0, 0, 0, 0];

        private string _text1 = string.Empty;
        private string _text2 = string.Empty;
    }
}
