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
        public ICommand OnButtonDeleteKlasse { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den Löschen Button klickt
        /// </summary>
        public ICommand OnButtonDeleteAbteilung { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den Löschen Button klickt
        /// </summary>
        public ICommand OnButtonDeleteFach { get; private set; }
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
        public ICommand OnButtonNewKlasse { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den Neu Button klickt
        /// </summary>
        public ICommand OnButtonNewAbteilung { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den Neu Button klickt
        /// </summary>
        public ICommand OnButtonNewFach { get; private set; }
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
            OnButtonDeleteKlasse = new RelayCommand(DoButtonDeleteKlasse);
            OnButtonDeleteAbteilung = new RelayCommand(DoButtonDeleteAbteilung);
            OnButtonDeleteFach = new RelayCommand(DoButtonDeleteFach);
            OnButtonDeleteUser = new RelayCommand(DoButtonDeleteUser);
            OnButtonDeleteRegister = new RelayCommand(DoButtonDeleteRegister);
            OnButtonPasswordChange = new RelayCommand(DoButtonPasswordChange);
            OnButtonNewKlasse = new RelayCommand(DoButtonNewKlasse);
            OnButtonNewAbteilung = new RelayCommand(DoButtonNewAbteilung);
            OnButtonNewFach = new RelayCommand(DoButtonNewFach);
            OnButtonNewRegister = new RelayCommand(DoButtonNewRegister);
            OnButtonLogout = new RelayCommand(DoButtonLogout);

            OnLoad();
        }
        #endregion

        #region private methods

        #region button new

        #region button new klasse
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Neu Button klickt
        /// </summary>
        private void DoButtonNewKlasse()
        {
            MessageBox.Show("neue Klasse");
        }
        #endregion

        #region button new abteilung
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Neu Button klickt
        /// </summary>
        private void DoButtonNewAbteilung()
        {
            MessageBox.Show("neue Abteilung");
        }
        #endregion

        #region button new fach
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Neu Button klickt
        /// </summary>
        private void DoButtonNewFach()
        {
            MessageBox.Show("neues Fach");
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
            _registerList.Add(newRegister);
        }
        #endregion

        #endregion

        #region delete buttons

        #region button delete klasse
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Delete Button klickt
        /// </summary>
        private void DoButtonDeleteKlasse()
        {
            KlassenEntity klasse = GetSelectedKlasse();
            if (klasse == null) 
            {
                MessageBox.Show("Bitte erst eine Klasse auswählen!");
            }
            else
            {
                KlassenEntity.GetKlassenService().Delete(klasse);
            }
        }
        #endregion

        #region button delete fach
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Delete Button klickt
        /// </summary>
        private void DoButtonDeleteFach()
        {
            FachEntity fach = GetSelectedFach();
            if (fach == null)
            {
                MessageBox.Show("Bitte erst ein Fach auswählen!");
            }
            else
            {
                FachEntity.GetFachService().Delete(fach);
            }
        }
        #endregion

        #region button delete abteilung
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Delete Button klickt
        /// </summary>
        private void DoButtonDeleteAbteilung()
        {
            AbteilungEntity abteilung = GetSelectedAbteilung();
            if (abteilung == null)
            {
                MessageBox.Show("Bitte erst eine Abteilung auswählen!");
            }
            else
            {
                AbteilungEntity.GetAbteilungService().Delete(abteilung);
            }
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
            String standardPasswort = "BSL123";
            UserEntity user = GetSelectedUser();
            if (user != null)
            {
                MessageBox.Show("Bitte erst einen Benutzer auswählen!");
            }
            else
            {
                user.password = standardPasswort;
                UserEntity.GetUserService().Update(user);
                MessageBox.Show("Passwort wurde von " + user.Name + " wurde auf das Standartpasswort " + standardPasswort);
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
            _klasseList = KlassenEntity.GetKlassenService().GetAll();
            _abteilungList = AbteilungEntity.GetAbteilungService().GetAll();
            _fachList = FachEntity.GetFachService().GetAll();
        }
        #endregion

        #region getSelected

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

        #region getSelectedRegister
        /// <summary>
        /// Gibt die ausgewählte Klasse zurück
        /// </summary>
        /// <returns>Gibt die Klasse KlassenEntity zurück, wenn eines aus der Liste ausgewählt wurde, sonst NULL</returns>
        private KlassenEntity? GetSelectedKlasse()
        {
            if (_selectedKlasseIndex == -1)
            {
                return null;
            }
            return _klasseList[_selectedKlasseIndex];
        }
        #endregion

        #region getSelectedRegister
        /// <summary>
        /// Gibt die ausgewählte Abteilung zurück
        /// </summary>
        /// <returns>Gibt die Klasse AbteilungEntity zurück, wenn eines aus der Liste ausgewählt wurde, sonst NULL</returns>
        private AbteilungEntity? GetSelectedAbteilung()
        {
            if (_selectedAbteilungIndex == -1)
            {
                return null;
            }
            return _abteilungList[_selectedAbteilungIndex];
        }
        #endregion

        #region getSelectedRegister
        /// <summary>
        /// Gibt das ausgewählte Fach zurück
        /// </summary>
        /// <returns>Gibt die Klasse FachEntity zurück, wenn eines aus der Liste ausgewählt wurde, sonst NULL</returns>
        private FachEntity? GetSelectedFach()
        {
            if (_selectedFachIndex == -1)
            {
                return null;
            }
            return _fachList[_selectedFachIndex];
        }
        #endregion

        #endregion

        #endregion

        #region member variabls

        private IList<UserEntity> _userList = [];
        private IList<RegisterEntity> _registerList = [];
        private IList<KlassenEntity> _klasseList = [];
        private IList<AbteilungEntity> _abteilungList = [];
        private IList<FachEntity> _fachList = [];
        private int _selectedUserIndex = -1;
        private int _selectedRegisterIndex = -1;
        private int _selectedKlasseIndex = -1;
        private int _selectedAbteilungIndex = -1;
        private int _selectedFachIndex = -1;
        private readonly Random _random = new Random();

        #endregion
    }
}
