using System.Windows;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;
using YAFIT.UI.ViewModels;
using YAFIT.UI.ViewModels.Forms.Formular1;
using YAFIT.UI.ViewModels.Forms.Formular2;
using YAFIT.UI.ViewModels.Forms.Formular3;
using YAFIT.UI.Views;
using YAFIT.UI.Views.Forms.Formular1;
using YAFIT.UI.Views.Forms.Formular2;
using YAFIT.UI.Views.Forms.Formular3;

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
            ViewMain view = new ViewMain();
            ModelMain model = new ModelMain(view);
            view.DataContext = model;
            view.Show();
        }

        public static void OpenTeacherWindow(UserEntity user)
        {
            ViewTeacher view = new ViewTeacher();
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
            ViewFormular1 view = new ViewFormular1();
            ModelFormular1 model = new ModelFormular1(view, umfrage);
            view.DataContext = model;
            view.Show();
        }

        public static void OpenFormular1Results(UmfrageEntity umfrage)
        {
            ViewFormular1Result view = new ViewFormular1Result();
            ModelFormular1Result model = new ModelFormular1Result(view, umfrage);
            view.DataContext = model;
            view.Show();
        }

        public static void OpenFormular2(UmfrageEntity umfrage)
        {
            
            ViewFormular2 view = new ViewFormular2();
            ModelFormular2 model = new ModelFormular2(view,umfrage);
            view.DataContext = model;
            view.Show();
        }
        public static void OpenFormular2Results(UmfrageEntity umfrage)
        {
            ViewFormular2Result view = new ViewFormular2Result();
            ModelFormular2Result model = new ModelFormular2Result(view, umfrage);
            view.DataContext = model;
            view.Show();
        }

        public static void OpenFormular3(UmfrageEntity umfrage)
        {
            ViewFormular3 view = new ViewFormular3();
            WindowFormFormular3Model model = new WindowFormFormular3Model(view, umfrage);
            view.DataContext = model;
            view.Show();
        }
        public static void OpenFormular3Results(UmfrageEntity umfrage)
        {
            ViewFormular3Result view = new ViewFormular3Result();
            ModelFormular3Result model = new ModelFormular3Result(view, umfrage);
            view.DataContext = model;
            view.Show();
        }
    }
}
