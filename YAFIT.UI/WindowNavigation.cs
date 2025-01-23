using System.Windows.Input;
using YAFIT.UI.ViewModels;
using YAFIT.UI.Views;

namespace YAFIT.UI
{
    public class WindowNavigation
    {

        public static void OpenWindowMain()
        {

            //Start Window
            WindowMain main = new WindowMain();
            WindowMainModel model = new WindowMainModel(main);
            main.DataContext = model;
            main.Show();
        }
      
        public static void OpenSelectionList()
        {

            //Start Window
            WindowFeedbackListing main = new Views.WindowFeedbackListing();
            WindowFeedbackListingModel model = new WindowFeedbackListingModel(main);
            main.DataContext = model;
            main.Show();
        }
        public static void OpenWindowSelection()
        {
            //Start Window
            SelectionView selec = new SelectionView();
            SelectionViewModel model = new SelectionViewModel(selec);
            selec.DataContext = model;
            selec.Show();
        }
        
        public static void OpenWindowFeedback1()
        {
            //Start Window
            windowfeedback selec = new windowfeedback();
            checkBoxView model = new checkBoxView(selec);
            selec.DataContext = model;
            selec.Show();
        }
    }
}
