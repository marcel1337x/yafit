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
            set { _results = value; }
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

        private int[] _results = [0, 0, 0, 0];

        private string _text1 = string.Empty;
        private string _text2 = string.Empty;
    }
}
