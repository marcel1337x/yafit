using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Classes;
using YAFIT.UI.Views;

namespace YAFIT.UI.ViewModels
{
    public class WindowMainModel : BaseViewModel
    {

        public ICommand OnFeedbackCodeEnter { get; private set; }
        public ICommand OnAccountLogin { get; private set; }
        public ICommand OnAccountRegister { get; private set; }


        //@TODO Entfernen nach 1 Sprint
        private List<Authentication> authentications = new List<Authentication>();

        private string _userName = "";
        public string LoginUname { get { return _userName; }  set { SetProperty("LoginUname", ref _userName, value); } }

        public WindowMainModel(Window window) : base(window) {
            WindowCaption = "YAFIT - Yet Another Feeback Information Tool";
            OnFeedbackCodeEnter = new RelayCommand(DoFeedbackCodeEnter);
            OnAccountLogin = new RelayCommand(DoAccountLogin);
            OnAccountRegister = new RelayCommand(DoAccountRegister);

            WindowMain? windowMain = _view as WindowMain;
            if (windowMain != null)
            {
                windowMain.PWBox.KeyDown += OnPasswordEnterEvent;
            }
        }

        private void DoFeedbackCodeEnter()
        {
            MessageBox.Show("Feedback");
        }

        private void OnPasswordEnterEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DoAccountLogin();
            }
        }

        private void DoAccountRegister()
        {
            //@TODO Datenbank anbinden & besser machen
            WindowMain? windowMain = _view as WindowMain;
            //Authentication auth = new Authentication(LoginUname, windowMain.PWBox.Password);

            //authentications.Add(auth);

            MessageBox.Show("Account "+LoginUname+" registriert!");
            DoAccountLogin();
        }
        private void DoAccountLogin()
        {
            WindowMain? windowMain = _view as WindowMain;
            //Authentication auth = new Authentication(LoginUname, windowMain.PWBox.Password);

            //if (auth.doLogin())
            //{

                //@TODO Differenzieren zwischen Admin und Lehrer
            //}
            //else
            //{
            //    MessageBox.Show("Login Fehlerhaft");
            //}
            Debug.WriteLine(LoginUname);
            //Debug.WriteLine(windowMain.PWBox.Password);
        }
    }
}
