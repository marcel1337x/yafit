using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YAFIT.UI.UserControls
{
    /// <summary>
    /// Interaktionslogik für FormEntryLineRadiobuttonSingle.xaml
    /// </summary>
    public partial class FormEntryLineRadiobuttonSingle : UserControl
    {
        

        private static int _idCounter = 0;

        

        public string RandomGroup
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool[] Selection
        {
            get { return _selects; }
            set { _selects = value; }
        }

        public FormEntryLineRadiobuttonSingle()
        {
            InitializeComponent();
            DataContext = this;
        }

        public int? GetSelection()
        {
            if (_selects.All(x => x == false) == true)
            {
                return null;
            }
            int index = Array.FindIndex(_selects, x => x == true);
            return index == -1 ? null : (index + 1);
        }


        private bool[] _selects = [false, false, false, false];
        private string _id = "SingleGroup" + _idCounter++;
        private string _text1 = string.Empty;

        /* DEBUG
        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine("SELECT; " + string.Join(", ",Selection));
        }
        */
    }
}