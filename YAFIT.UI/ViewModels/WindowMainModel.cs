using System.Windows;
using System.Windows.Input;
using YAFIT.UI.Resources;

namespace YAFIT.UI.ViewModels
{
    public class WindowMainModel : BaseViewModel
    {

        public ICommand OnFeedbackCodeEnter { get; private set; }
        public ICommand OnAccountLogin { get; private set; }

        public WindowMainModel(Window window) : base(window) {
            WindowCaption = "Yet Another Feeback Information Tool - YAFIT";
            OnFeedbackCodeEnter = new RelayCommand(DoFeedbackCodeEnter);
            OnAccountLogin = new RelayCommand(DoAccountLogin);
        }

        private void DoFeedbackCodeEnter()
        {
            MessageBox.Show("Feedback");
        }
        private void DoAccountLogin()
        {
            MessageBox.Show("Login");
        }
    }
}
