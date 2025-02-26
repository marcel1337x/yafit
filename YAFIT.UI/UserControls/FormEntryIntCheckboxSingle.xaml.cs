using System.Windows.Controls;

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
            set { _results = value; }
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
        }


        private int[] _results = [0,0,0,0];
        private string _text1 = string.Empty;
    }
}
