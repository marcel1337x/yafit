using System.Diagnostics;
using System.Security;
using System.Security.Authentication;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YAFIT.Databases.Classes;
using YAFIT.UI.Resources;
using YAFIT.UI.Views;

namespace YAFIT.UI.ViewModels
{
    public class WindowMainModel : BaseViewModel
    {

        public ICommand OnFeedbackCodeEnter { get; private set; }
        public ICommand OnAccountLogin { get; private set; }
        private string _userName = "";
        public string LoginUname { get { return _userName; }  set { SetProperty("LoginUname", ref _userName, value); } }

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
            WindowMain? windowMain = _view as WindowMain;
            Authentication auth = new Authentication(LoginUname, windowMain.PWBox.Password);
            if (auth.doLogin())
            {
                MessageBox.Show("Login");
            }
            else
            {
                MessageBox.Show("Login Fehlerhaft");
            }
            Debug.WriteLine(LoginUname);
            Debug.WriteLine(windowMain.PWBox.Password);
        }
    }
}
