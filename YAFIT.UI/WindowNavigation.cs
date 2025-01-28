using System.Diagnostics;
using System.Windows;
using YAFIT.Common.UI.ViewModel;
using YAFIT.UI.ViewModels;
using YAFIT.UI.ViewModels.Forms;
using YAFIT.UI.Views;
using YAFIT.UI.Views.Forms.Formular1;

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
        /// <summary>
        /// Generic Typen Variante um ein Fenster zu öffnen
        /// </summary>
        /// <typeparam name="TView">Das View / Window</typeparam>
        /// <typeparam name="TModel">Die Model Klasse als Datenkontext</typeparam>
        /// <param name="modelResult">Gibt die erstellte Modelklasse zurück</param>
        /// <exception cref="Exception">Wirft einen Fehler aus, wenn das Fenster oder Model nicht erstellt werden konnte.</exception>
        public static void OpenWindow<TView, TModel>(out TModel modelResult) where TView : Window where TModel : BaseViewModel
        {
            TView? window = (TView?)Activator.CreateInstance(typeof(TView));
            TModel? model = (TModel?)Activator.CreateInstance(typeof(TModel), window);
            if (window is null || model is null)
            {
                throw new Exception($"Window or Model is null! [Window: {window is null}, Model: {model is null}]");
            }
            window.DataContext = model;
            window.Show();
            modelResult = model;
        }

        public static void OpenWindowMain()
        {

            //Start Window
            WindowMain window = new WindowMain();
            WindowMainModel model = new WindowMainModel(window);
            window.DataContext = model;
            window.Show();
        }

        public static void OpenSelectionList()
        {

            //Start Window
            WindowFormListing window = new WindowFormListing();
            WindowFormListingModel model = new WindowFormListingModel(window);
            window.DataContext = model;
            window.Show();
        }
        public static void OpenForm1()
        {

            //using (var session = SessionManager.Get().OpenStatelessSession())
            //{
            //    TestEntity test = new TestEntity();
            //    test.Name = "Tests";
            //    test.Email = "emuals";
            //
            //    session.Insert(test);
            //    test.Email = "323";
            //    session.Update(test);
            //}
            
            OpenWindow<Formular1_1, WindowFormFormular1Model1>();

            //Start Window
            //Formular1_1 window = new Formular1_1();
            //WindowFormFormular1Model1 model = new WindowFormFormular1Model1(window);
            //window.DataContext = model;
            //window.Show();
        }
        public static void OpenWindowSelection()
        {
            //Start Window
            SelectionView window = new SelectionView();
            SelectionViewModel model = new SelectionViewModel(window);
            window.DataContext = model;
            window.Show();
        }

        public static void OpenWindowFeedback1()
        {
            ////Start Window
            //windowfeedback window = new windowfeedback();
            //WindowFormFormular1Model model = new checkBoxView(window);
            //window.DataContext = model;
            //window.Show();
        }
    }
}
