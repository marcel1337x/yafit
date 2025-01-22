﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace YAFIT.UI.Views
{
    /// <summary>
    /// Interaktionslogik für SelectionView.xaml
    /// </summary>
    public partial class SelectionView : Window
    {
        private String currentFormular = "";
        public SelectionView()
        {
            InitializeComponent();
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                currentFormular = radioButton.Content.ToString();
            }
        }

    }
}
