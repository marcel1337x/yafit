﻿using System.Windows;
using YAFIT.UI;
using YAFIT.UI.ViewModels;
using YAFIT.UI.Views;

namespace YAFIT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Hier fängt die Anwendung an.
        /// Startet die Anwendung und öffnet das Hauptfenster
        /// </summary>
        /// <param name="sender">Fenster</param>
        /// <param name="e">StartupEventArgs</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WindowNavigation.OpenWindow<WindowMain, WindowMainModel>();
        }

        /// <summary>
        /// Hier wird das Event ausgeführt wenn die Anwendung beendet wird
        /// </summary>
        /// <param name="sender">Fenster</param>
        /// <param name="e">ExitEventArgs</param>
        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }
    }

}
