using System.Diagnostics;
using System.Security;
using System.Windows;
using System.Windows.Input;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases;
using YAFIT.Databases.Classes;
using YAFIT.Databases.Entities;
using YAFIT.UI.Views;

namespace YAFIT.UI.ViewModels
{
    /// <summary>
    /// Das ViewModel für das Hauptfenster
    /// </summary>
    public class WindowMainModel : BaseViewModel
    {
        #region commands
        /// <summary>
        /// Der Befehl, der ausgeführt wird, sobald man den Feedbackcode eingibt
        /// </summary>
        public ICommand OnFeedbackCodeEnter { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, soabald man sich einloggen möchte
        /// </summary>
        public ICommand OnAccountLogin { get; private set; }

        /// <summary>
        /// Der Befehl, der ausgeführt wird, soabald man sich registrieren möchte
        /// </summary>
        public ICommand OnAccountRegister { get; private set; }

        #endregion

        #region properties

        /// <summary>
        /// Der Benutzername, der eingegeben wurde
        /// </summary>
        public string LoginUname 
        { 
            get { return _userName; }  
            set { SetProperty("LoginUname", ref _userName, value); } 
        }

        /// <summary>
        /// Das Passwort, das eingegeben wurde
        /// </summary>
        public SecureString? SecurePassword
        {
            get
            {
                if(_view is WindowMain windowMain)
                {
                    return windowMain.PWBox.SecurePassword ?? null;
                }
                return null;
            }
        }

        #endregion

        #region constructor

        /// <summary>
        /// Erstellt ein neues ViewModel für das Hauptfenster
        /// </summary>
        /// <param name="window">Das dazugehörige View</param>
        public WindowMainModel(Window window) : base(window) {
            WindowCaption = "YAFIT - Yet Another Feeback Information Tool";
            OnFeedbackCodeEnter = new RelayCommand(DoFeedbackCodeEnter);
            OnAccountLogin = new RelayCommand(DoAccountLogin);
            OnAccountRegister = new RelayCommand(DoAccountRegister);

            if (_view is WindowMain windowMain)
            {
                windowMain.PWBox.KeyDown += OnPasswordEnterEvent;
            }

            using (var session = SessionManager.Instance.OpenStatelessSession());

        }

        #endregion

        #region private methods

        #region eventhandler
        /// <summary>
        /// Eventhandler, der ausgeführt wird, wenn man Enter im Passwortfeld drückt
        /// </summary>
        /// <param name="sender">Fenster</param>
        /// <param name="e">KeyEventArgs</param>
        private void OnPasswordEnterEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DoAccountLogin();
            }
        }

        #endregion

        #region feedback code
        /// <summary>
        /// Methode, die aufgerufen wird, wenn man auf Feedbackcode drückt
        /// </summary>
        private void DoFeedbackCodeEnter()
        {
            MessageBox.Show("Feedback");
        }

        #endregion

        #region account register
        /// <summary>
        /// Methode, die aufgerufen wird, wenn man auf Registrieren drückt
        /// </summary>
        private void DoAccountRegister()
        {
            //@TODO Datenbank anbinden & besser machen
            WindowMain? windowMain = _view as WindowMain;
            //Authentication auth = new Authentication(LoginUname, windowMain.PWBox.Password);

            //authentications.Add(auth);

            MessageBox.Show("Account " + LoginUname + " registriert!");
            DoAccountLogin();
        }
        #endregion

        #region account login
        /// <summary>
        /// Methode, die aufgerufen wird, wenn man auf Login drückt
        /// </summary>
        private void DoAccountLogin()
        {
            WindowNavigation.OpenTeacherWindow();
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
        #endregion

        #endregion

        #region protected methods

        protected override void CloseView()
        {
            if (_view is WindowMain windowMain)
            {
                windowMain.PWBox.KeyDown -= OnPasswordEnterEvent;
            }
            base.CloseView();
        }

        #endregion

        #region member variables

        //@TODO Entfernen nach 1 Sprint
        private List<Authentication> authentications = new List<Authentication>();
        private string _userName = string.Empty;

        #endregion
    }
}
