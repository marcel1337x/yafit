using YAFIT.UI.ViewModels;
using YAFIT.UI.ViewModels.Forms;
using YAFIT.UI.Views;
using YAFIT.UI.Views.Forms;
using YAFIT.UI.Views.Forms.Formular1;

namespace YAFIT.UI
{
    public class WindowNavigation
    {


        public static void OpenWindow<TView, TModel>()
        {

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

            //Start Window
            Formular1_1 window = new Formular1_1();
            WindowFormFormular1Model1 model = new WindowFormFormular1Model1(window);
            window.DataContext = model;
            window.Show();
        }
        public static void OpenWindowSelection()
        {
            //Start Window
            SelectionView window = new SelectionView();
            SelectionViewModel model = new SelectionViewModel(window);
            window.DataContext = model;
            window.Show();
        }

        public static void OpenDebug()
        {
            //Start Window
            Debug selec = new Debug();
            //SelectionViewModel model = new SelectionViewModel(window);
            //window.DataContext = model;
            selec.Show();
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
