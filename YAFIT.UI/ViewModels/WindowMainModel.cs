﻿using System.Diagnostics;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using YAFIT.Common.Extensions;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Classes;
using YAFIT.Databases.Entities;
using YAFIT.UI.ViewModels.Forms.Formular1;
using YAFIT.UI.Views;
using YAFIT.UI.Views.Forms.Formular1;

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

        /// <summary>
        /// Der Schlüssel, der eingegeben wurde
        /// </summary>
        public string FormularKey
        {
            get { return _formularKey; }
            set { SetProperty("FormularKey", ref _formularKey, value); }
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
            Regex _regex = new Regex("[^0-9]");
            if (!_regex.IsMatch(_formularKey)==false)
            {
                MessageBox.Show("Die Eingabe kann nur aus Zahlen bestehen!");
            }
            else
            {
                //soll später eine Serviceklasse aufrufen und darüber die Formular und Schlüssel holen
                if (_formularKey.Equals("11111111"))
                {
                    WindowNavigation.OpenWindow<Formular1_1, WindowFormFormular1Model1>();
                    WindowMain? windowMain = _view as WindowMain;
                    windowMain.Close();
                }
                else
                {
                    MessageBox.Show("Der eingegebene Schlüssel existiert nicht!");
                }
            }
            
            
        }

        #endregion

        #region account register
        /// <summary>
        /// Methode, die aufgerufen wird, wenn man auf Registrieren drückt
        /// </summary>
        private void DoAccountRegister()
        {
            if (string.IsNullOrEmpty(LoginUname) == true)
            {
                MessageBox.Show("Gebe einen Benutzernamen an um fortzufahren!");
                return;
            }
            if (string.IsNullOrEmpty(SecurePassword?.ConvertToPlainText() ?? "") == true)
            {
                MessageBox.Show("Gebe ein Passwort ein um fortzufahren!");
                return;
            }
            ViewRegisterCode view = new ();
            ModelRegisterCode model = new (view, this);
            ShowChildView(view, model);
            if (model.IsSuccessful == false)
            {
                MessageBox.Show("Registrierung ist fehlgeschlagen!");
                return;
            }
            DoAccountLogin();

        }
        #endregion

        #region account login
        /// <summary>
        /// Methode, die aufgerufen wird, wenn man auf Login drückt
        /// </summary>
        private void DoAccountLogin()
        {
            UserEntity? user = UserEntity.GetUserService().GetEntity(x => x.Name == _userName);
            if (user != null)
            {
                if (user.password == (SecurePassword?.ConvertToPlainText() ?? ""))
                {
                    MessageBox.Show("Login erfolgreich");
                    if (user.isAdmin == true)
                    {
                        MessageBox.Show("Benutzer hat Adminrechte");
                    } 
                    WindowNavigation.OpenTeacherWindow(user);
                }
                else
                {
                    MessageBox.Show("Passworteingabe ist falsch!");
                }
            }
            else
            {
                MessageBox.Show("Der Benutzer " + _userName + " konnte nicht gefunden werden!");
            }
            Debug.WriteLine(LoginUname);
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
        private string _formularKey = string.Empty;

        #endregion
    }
}
