using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YAFIT.Common.Enums;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Data.Forms;
using YAFIT.Databases.Entities;
using YAFIT.Interfaces.Forms;
using YAFIT.UI.Views;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace YAFIT.UI.ViewModels
{
    internal class ModelAdminView : BaseViewModel
    {

        #region properties
        
        /// <summary>
        /// Die Liste der bestehenden Benutzer
        /// </summary>
        public IList<UserEntity> UserList {
            get { return _userList; }
            set { SetProperty("UserList", ref _userList, value); } 
        }

        /// <summary>
        /// Die Liste der bestehenden Registrierungsschlüssel
        /// </summary>
        public IList<RegisterEntity> RegisterList
        {
            get { return _registerList; }
            set { SetProperty("RegisterList", ref _registerList, value); }
        }
        public int SelectedUserIndex { get { return _selectedUserIndex; } set { SetProperty("SelectedUserIndex", ref _selectedUserIndex, value); } }
        public int SelectedRegisterIndex { get { return _selectedRegisterIndex; } set { SetProperty("SelectedRegisterIndex", ref _selectedRegisterIndex, value); } }

        #endregion

        #region commands
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den Löschen Button klickt
        /// </summary>
        public ICommand OnButtonDelete { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den User Löschen Button klickt
        /// </summary>
        public ICommand OnButtonDeleteUser { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den Registrierung Löschen Button klickt
        /// </summary>
        public ICommand OnButtonDeleteRegister { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn der Öffnen Button geklickt wird oder man doppelklickt auf den Eintrag
        /// </summary>
        public ICommand OnButtonPasswordChange { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den Neu Button klickt
        /// </summary>
        public ICommand OnButtonNew { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den Neue Registrierung Button klickt
        /// </summary>
        public ICommand OnButtonNewRegister { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man das Fenster schließt oder auf den Logout Button klickt
        /// </summary>
        public ICommand OnButtonLogout { get; private set; }

        #endregion

        #region constructor
        /// <summary>
        /// Erstellt ein neues ViewModel für das Hauptfenster
        /// </summary>
        /// <param name="window">Das dazugehörige View</param>
        public ModelAdminView(Window window) : base(window)
        {
            WindowCaption = "Lehrer Übersicht";
            OnButtonDelete = new RelayCommand(DoButtonDelete);
            OnButtonDeleteUser = new RelayCommand(DoButtonDeleteUser);
            OnButtonDeleteRegister = new RelayCommand(DoButtonDeleteRegister);
            OnButtonPasswordChange = new RelayCommand(DoButtonPasswordChange);
            OnButtonNew = new RelayCommand(DoButtonNew);
            OnButtonNewRegister = new RelayCommand(DoButtonNewRegister);
            OnButtonLogout = new RelayCommand(DoButtonLogout);

            OnLoad();
        }
        #endregion

        #region private methods

        #region button new
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Neu Button klickt
        /// </summary>
        private void DoButtonNew()
        {
            // neue Fächer, Abteilungen & Klassen
        }
        #endregion

        #region button new register
        /// <summary>
        /// Wird ausgeführt, wenn man auf den NeuerRegistrierungs Button klickt
        /// </summary>
        private void DoButtonNewRegister()
        {
            string key = _random.Next(10_000_000, 99_999_999).ToString().PadLeft(8, '0');
            while (RegisterEntity.GetRegisterService().GetEntity(registertabelleneintrag => registertabelleneintrag.Code == key) != null)
            {
                key = _random.Next(10_000_000, 99_999_999).ToString().PadLeft(8, '0');
            }
            RegisterEntity newRegister = new RegisterEntity();
            newRegister.Code = key;
            RegisterEntity.GetRegisterService().Insert(newRegister);
        }
        #endregion

        #region delete buttons

        #region button delete
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Delete Button klickt
        /// </summary>
        private void DoButtonDelete()
        {
            // löschen von Fächern, Abteilungen & Klassen
        }
        #endregion

        #region button delete user
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Delete Button klickt
        /// </summary>
        private void DoButtonDeleteUser()
        {
            UserEntity user = GetSelectedUser();
            if (user == null)
            {
                MessageBox.Show("Bitte erst einen Benutzer auswählen!");
            }
            else
            {
                UserEntity.GetUserService().Delete(user);
            }
        }
        #endregion

        #region button delete register 
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Delete Button klickt
        /// </summary>
        private void DoButtonDeleteRegister()
        {
            RegisterEntity register = GetSelectedRegister();
            if (register == null)
            {
                MessageBox.Show("Bitte erst einen Registrierungsschlüssel auswählen!");
            }
            {
                RegisterEntity.GetRegisterService().Delete(register);
            }
        }
        #endregion
        
        #endregion

        #region button passwordChange
        /// <summary>
        /// Wird ausgeführt, wenn man auf den PasswordChange Button klickt
        /// </summary>
        private void DoButtonPasswordChange()
        {
            UserEntity user = GetSelectedUser();
            if (user != null)
            {
                MessageBox.Show("Bitte erst einen Benutzer auswählen!");
            }
            else
            {
                user.password = "BSL123";
                UserEntity.GetUserService().Update(user);
            }
        }
        #endregion

        #region button logout
        /// <summary>
        /// Wird ausgeführt, wenn man den Logout Button klickt
        /// </summary>
        private void DoButtonLogout()
        {
            CloseView();
        }
        #endregion

        #region onload
        /// <summary>
        /// Holt alle vorhandenen Lehrer und Registrierungsschlüssel aus der Datenbank
        /// </summary>
        private void OnLoad()
        {
            _userList = UserEntity.GetUserService().GetAll();
            _registerList = RegisterEntity.GetRegisterService().GetAll();
            
        }
        #endregion

        #region getSelectedUser
        /// <summary>
        /// Gibt den ausgewählten Benutzer zurück
        /// </summary>
        /// <returns>Gibt die Klasse UserEntity zurück, wenn eines aus der Liste ausgewählt wurde, sonst NULL</returns>
        private UserEntity? GetSelectedUser()
        {
            if (_selectedUserIndex == -1)
            {
                return null;
            }
            return _userList[_selectedUserIndex];
        }
        #endregion

        #region getSelectedRegister
        /// <summary>
        /// Gibt den ausgewählten Registrierungsschlüssel zurück
        /// </summary>
        /// <returns>Gibt die Klasse RegisterEntity zurück, wenn eines aus der Liste ausgewählt wurde, sonst NULL</returns>
        private RegisterEntity? GetSelectedRegister()
        {
            if (_selectedRegisterIndex == -1)
            {
                return null;    
            }
            return _registerList[_selectedRegisterIndex];
        }
        #endregion

        #endregion

        #region member variabls

        private IList<UserEntity> _userList = [];
        private IList<RegisterEntity> _registerList = [];
        private int _selectedUserIndex = -1;
        private int _selectedRegisterIndex = -1;
        private readonly Random _random = new Random();

        #endregion
    }
}
