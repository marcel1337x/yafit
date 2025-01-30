using System.Windows;
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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WindowNavigation.OpenWindow<WindowMain, WindowMainModel>();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }
    }

}
