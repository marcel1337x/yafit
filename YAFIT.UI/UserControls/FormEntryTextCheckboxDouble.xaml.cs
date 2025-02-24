﻿using System.Windows.Controls;

namespace YAFIT.UI.UserControls
{
    /// <summary>
    /// Interaktionslogik für FormEntryTextCheckbox.xaml
    /// </summary>
    public partial class FormEntryTextCheckboxDouble : UserControl
    {

        private static int _idCounter = 0;

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

        public FormEntryTextCheckboxDouble()
        {
            InitializeComponent();
            DataContext = this;
        }

        public int? GetSelection()
        {
            if(_selects.All(x => x == false) == true)
            {
                return null;
            }
            int index = Array.FindIndex(_selects, x => x == true);
            return index == -1 ? null : (index+1);
        }


        private bool[] _selects = [false, false, false, false];
        private string _id = "DoubleGroup" + _idCounter++;
        private string _text1 = string.Empty;
        private string _text2 = string.Empty;
        /* DEBUG
        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine("SELECT; " + string.Join(", ",Selection));
        }
        */
    }
}
