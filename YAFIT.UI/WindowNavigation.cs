using System.Windows;
using YAFIT.Common.UI.ViewModel;
using YAFIT.UI.ViewModels.Forms;
using YAFIT.UI.ViewModels;
using YAFIT.UI.Views.Forms.Formular1;
using YAFIT.UI.Views;

namespace YAFIT.UI
{
    public class WindowNavigation
    {

        /// <summary>
        /// Generic Typen Variante um ein Fenster zu öffnen
        /// </summary>
        /// <typeparam name="TView">Das View / Window</typeparam>
        /// <typeparam name="TModel">Die Model Klasse als Datenkontext</typeparam>
        /// <exception cref="Exception">Wirft einen Fehler aus, wenn das Fenster oder Model nicht erstellt werden konnte.</exception>
        public static void OpenWindow<TView, TModel>() where TView : Window where TModel : BaseViewModel
        {
            TView? window = (TView?)Activator.CreateInstance(typeof(TView));
            TModel? model = (TModel?)Activator.CreateInstance(typeof(TModel), window);
            if (window is null || model is null)
            {
                throw new Exception($"Window or Model is null! [Window: {window is null}, Model: {model is null}]");
            }
            window.DataContext = model;
            window.Show();
        }


        public static void OpenLoginWindow()
        {
            OpenWindow<WindowMain, WindowMainModel>();
        }

        public static void OpenTeacherWindow()
        {

        }
        public static void OpenAdminWindow()
        {

        }

        public static void OpenFormular1()
        {

            OpenWindow<Formular1_1, WindowFormFormular1Model1>();
        }
        public static void OpenWindowFeedback2()
        {
            //Start Window
            WindowFeedback2 selec = new WindowFeedback2();
            CheckboxViewDartBoardView model = new CheckboxViewDartBoardView(selec);
            selec.DataContext = model;
            selec.Show();
        }
    }
}
