using System.Windows;
using YAFIT.Databases;
using YAFIT.UI;

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
            WindowNavigation.OpenFormular2Results(null);
            //if (SessionManager.Connect() == true)
            //{
            //    WindowNavigation.OpenLoginWindow();
            //}
        }

        /// <summary>
        /// Hier wird das Event ausgeführt wenn die Anwendung beendet wird
        /// </summary>
        /// <param name="sender">Fenster</param>
        /// <param name="e">ExitEventArgs</param>
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            SessionManager.Disconnect();
            Environment.Exit(0);
        }
    }

}
