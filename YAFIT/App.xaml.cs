﻿using System.Windows;
using YAFIT.UI;

namespace YAFIT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WindowNavigation.OpenForm1();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }
    }

}
