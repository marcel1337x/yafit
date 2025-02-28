using System.Windows;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;
using YAFIT.UI.ViewModels.Forms;
using YAFIT.UI.ViewModels;
using YAFIT.UI.Views.Forms.Formular1;
using YAFIT.UI.Views;
using YAFIT.UI.ViewModels.Forms.Formular1;

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

        public static void OpenTeacherWindow(UserEntity user)
        {
            ViewTeacherFormListing view = new ViewTeacherFormListing();
            ModelTeacherFormsListing model = new ModelTeacherFormsListing(view, user);
            view.DataContext = model;
            view.Show();
        }
        public static void OpenAdminWindow()
        {
            ViewAdmin view = new ViewAdmin();
            ModelAdminView model = new ModelAdminView(view);
            view.DataContext = model;
            view.Show();
        }

        public static void OpenSelectionWindow()
        {
            ViewFormsSelection window = new ViewFormsSelection();
            ModelFormsSelection selection = new ModelFormsSelection(window);
            window.DataContext = selection;
            window.Show();
        }

        public static void OpenFormular1(UmfrageEntity umfrage)
        {
            Formular1_1 view = new Formular1_1();
            WindowFormFormular1Model1 model = new WindowFormFormular1Model1(view, umfrage);
            view.DataContext = model;
            view.Show();
        }
        public static void OpenFormular1Results(UmfrageEntity umfrage)
        {
            Formular1Result view = new Formular1Result();
            WindowFormFormular1ResultModel model = new WindowFormFormular1ResultModel(view, umfrage);
            view.DataContext = model;
            view.Show();
        }

        public static void OpenFormular2()
        {
            OpenWindow<WindowFeedback2, CheckboxViewDartBoardView>();
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
