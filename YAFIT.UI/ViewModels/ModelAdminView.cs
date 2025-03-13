using System.Windows;
using System.Windows.Input;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;

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
        /// <summary>
        /// Die Liste der bestehenden Klassen
        /// </summary>
        public IList<KlassenEntity> KlassenList
        {
            get { return _klassenList; }
            set { SetProperty("KlassenList", ref _klassenList, value); }
        }
        /// <summary>
        /// Die Liste der bestehenden Registrierungsschlüssel
        /// </summary>
        public IList<AbteilungEntity> AbteilungList
        {
            get { return _abteilungList; }
            set { SetProperty("AbteilungList", ref _abteilungList, value); }
        }
        /// <summary>
        /// Die Liste der bestehenden Registrierungsschlüssel
        /// </summary>
        public IList<FachEntity> FachList
        {
            get { return _fachList; }
            set { SetProperty("FachList", ref _fachList, value); }
        }
        public string NewKlasse
        {
            get { return _newKlasse; }
            set { SetProperty("NewKlasse", ref _newKlasse, value); }
        }
        public string NewAbteilung
        {
            get { return _newAbteilung; }
            set { SetProperty("NewAbteilung", ref _newAbteilung, value); }
        }
        public string NewFach
        {
            get { return _newFach; }
            set { SetProperty("NewFach", ref _newFach, value); }
        }
        public string NewPasswort
        {
            get { return _newPasswort; }
            set { SetProperty("NewPasswort", ref _newPasswort, value); }
        }
        public int SelectedUserIndex { get { return _selectedUserIndex; } set { SetProperty("SelectedUserIndex", ref _selectedUserIndex, value); } }
        public int SelectedRegisterIndex { get { return _selectedRegisterIndex; } set { SetProperty("SelectedRegisterIndex", ref _selectedRegisterIndex, value); } }
        public int SelectedFachIndex { get { return _selectedFachIndex; } set { SetProperty("SelectedFachIndex", ref _selectedFachIndex, value); } }
        public int SelectedAbteilungIndex { get { return _selectedAbteilungIndex; } set { SetProperty("SelectedAbteilungIndex", ref _selectedAbteilungIndex, value); } }
        public int SelectedKlassenIndex { get { return _selectedKlassenIndex; } set { SetProperty("SelectedKlassenIndex", ref _selectedKlassenIndex, value); } }

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
            WindowCaption = "Verwaltung - Lehrer, Klassen, ...";
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

            LoadAll();
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
            if (string.IsNullOrEmpty(_newKlasse) == true)
            {
                MessageBox.Show("Bitte erst den Namen der Klasse eingeben!");
            }
            else
            {
                KlassenEntity klasse = new KlassenEntity();
                klasse.Name = _newKlasse;
                KlassenEntity.GetKlassenService().Insert(klasse);
                LoadKlasse();
                OnPropertyChanged(nameof(KlassenList));
                MessageBox.Show("neue Klasse: " + _newKlasse);
            }           
            _newKlasse = "";
        }
        #endregion

        #region button new abteilung
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Neu Button klickt
        /// </summary>
        private void DoButtonNewAbteilung()
        {
            if (string.IsNullOrEmpty(_newAbteilung) == true)
            {
                MessageBox.Show("Bitte erst den Namen der Abteilung eingeben!");
            }
            else
            {
                AbteilungEntity abteilung = new AbteilungEntity();
                abteilung.Name = _newAbteilung;
                AbteilungEntity.GetAbteilungService().Insert(abteilung);
                LoadAbteilung();
                OnPropertyChanged(nameof(AbteilungList));
                MessageBox.Show("neue Abteilung: " + _newAbteilung);
            }
            _newAbteilung = "";
        }
        #endregion

        #region button new fach
        /// <summary>
        /// Wird ausgeführt, wenn man auf den Neu Button klickt
        /// </summary>
        private void DoButtonNewFach()
        {
            if (string.IsNullOrEmpty(_newFach) == true)
            {
                MessageBox.Show("Bitte erst den Namen des Fachs eingeben!");
            }
            else
            {
                FachEntity fach = new FachEntity();
                fach.Name = _newFach;
                FachEntity.GetFachService().Insert(fach);
                LoadFach();
                OnPropertyChanged(nameof(FachList));
                MessageBox.Show("neues Fach: " + _newFach);
            }
            _newFach = "";
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
            LoadRegister();
            OnPropertyChanged(nameof(RegisterList));
            MessageBox.Show("neuer Registrierungsschlüssel: " + key);
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
                String klassenName = klasse.Name;
                KlassenEntity.GetKlassenService().Delete(klasse);
                LoadKlasse();
                SelectedKlassenIndex = -1;
                OnPropertyChanged(nameof(KlassenList));
                OnPropertyChanged(nameof(SelectedKlassenIndex));
                MessageBox.Show("Die Klasse " + klassenName + " wurde erfolgreich gelöscht!");
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
                String fachName = fach.Name;
                FachEntity.GetFachService().Delete(fach);
                LoadFach();
                SelectedFachIndex = -1;
                OnPropertyChanged(nameof(FachList));
                OnPropertyChanged(nameof(SelectedFachIndex));
                MessageBox.Show("Das Fach " + fachName + " wurde erfolgreich gelöscht!");
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
                String abteilungsName = abteilung.Name;
                AbteilungEntity.GetAbteilungService().Delete(abteilung);
                LoadAbteilung();
                SelectedAbteilungIndex = -1;
                OnPropertyChanged(nameof(AbteilungList));
                OnPropertyChanged(nameof(SelectedAbteilungIndex));
                MessageBox.Show("Die Abteilung " + abteilungsName + " wurde erfolgreich gelöscht!");
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
                String userName = user.Name;
                IList<UmfrageEntity> umfragen = UmfrageEntity.GetUmfrageService().GetAllByCriteria(x => x.User_Id == user.Id);
                if (umfragen.Count != 0)
                {
                    foreach (UmfrageEntity um in umfragen)
                    {
                        UmfrageEntity.GetUmfrageService().Delete(um);
                    }
                }
                UserEntity.GetUserService().Delete(user);
                LoadUser();
                SelectedUserIndex = -1;
                OnPropertyChanged(nameof(UserList));
                OnPropertyChanged(nameof(SelectedUserIndex));
                MessageBox.Show("Der Benutzer " + userName + " wurde erfolgreich gelöscht!");
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
                LoadRegister();
                SelectedRegisterIndex = -1;
                OnPropertyChanged(nameof(RegisterList));
                OnPropertyChanged(nameof(SelectedRegisterIndex));
                MessageBox.Show("Der Registrierungsschlüssel wurde erfolgreich gelöscht!");
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
            UserEntity? user = GetSelectedUser();
            if (user == null)
            {
                MessageBox.Show("Bitte erst einen Benutzer auswählen!");
            }
            else
            {
                if (string.IsNullOrEmpty(NewPasswort))
                {
                    MessageBox.Show("Bitte erst ein neues Passwort eingeben!");
                }
                else
                {
                    user.Password = _newPasswort;
                    UserEntity.GetUserService().Update(user);
                    MessageBox.Show("Passwort wurde von " + user.Name + " wurde auf " + _newPasswort + " geändert!");
                }
            }
            _newPasswort = "";
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

        #region load
        #region loadAll
        /// <summary>
        /// Holt alle vorhandenen Lehrer, Registrierungsschlüssel, Klassen, Fächer und Abteilungen aus der Datenbank
        /// </summary>
        private void LoadAll()
        {
            _userList = UserEntity.GetUserService().GetAll();
            _registerList = RegisterEntity.GetRegisterService().GetAll();
            _klassenList = KlassenEntity.GetKlassenService().GetAll();
            _abteilungList = AbteilungEntity.GetAbteilungService().GetAll();
            _fachList = FachEntity.GetFachService().GetAll();
        }
        #endregion

        #region loadUser
        /// <summary>
        /// Holt alle vorhandenen Lehrer aus der Datenbank
        /// </summary>
        private void LoadUser() 
        {
            _userList.Clear();
            _userList = UserEntity.GetUserService().GetAll();
            OnPropertyChanged("UserList");
        }
        #endregion
        #region loadRegister
        /// <summary>
        /// Holt alle vorhandenen Registrierungsschlüssel aus der Datenbank
        /// </summary>
        private void LoadRegister()
        {
            _registerList.Clear();
            _registerList = RegisterEntity.GetRegisterService().GetAll();
            OnPropertyChanged("RegisterList");
        }
        #endregion
        #region loadKlasse
        /// <summary>
        /// Holt alle vorhandenen Klassen aus der Datenbank
        /// </summary>
        private void LoadKlasse()
        {
            _klassenList.Clear();
            _klassenList = KlassenEntity.GetKlassenService().GetAll();
            OnPropertyChanged("KlassenList");
        }
        #endregion
        #region loadAbteilung
        /// <summary>
        /// Holt alle vorhandenen Abteilungen aus der Datenbank
        /// </summary>
        private void LoadAbteilung()
        {
            _abteilungList.Clear();
            _abteilungList = AbteilungEntity.GetAbteilungService().GetAll();
            OnPropertyChanged("AbteilungList");
        }
        #endregion
        #region loadFach
        /// <summary>
        /// Holt alle vorhandenen Fächer aus der Datenbank
        /// </summary>
        private void LoadFach()
        {
            _fachList.Clear();
            _fachList = FachEntity.GetFachService().GetAll();
            OnPropertyChanged("FachList");
        }
        #endregion
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
            if (_selectedKlassenIndex == -1)
            {
                return null;
            }
            return _klassenList[_selectedKlassenIndex];
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

        private String _newKlasse = string.Empty;
        private String _newAbteilung = string.Empty;
        private String _newFach = string.Empty;
        private String _newPasswort = string.Empty;

        private IList<UserEntity> _userList = [];
        private IList<RegisterEntity> _registerList = [];
        private IList<KlassenEntity> _klassenList = [];
        private IList<AbteilungEntity> _abteilungList = [];
        private IList<FachEntity> _fachList = [];

        private int _selectedUserIndex = -1;
        private int _selectedRegisterIndex = -1;
        private int _selectedKlassenIndex = -1;
        private int _selectedAbteilungIndex = -1;
        private int _selectedFachIndex = -1;

        private readonly Random _random = new Random();

        #endregion
    }
}
