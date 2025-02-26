using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using YAFIT.Common.Enums;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Data.Forms;
using YAFIT.Databases.Entities;
using YAFIT.Interfaces.Forms;
using YAFIT.UI.Views;

namespace YAFIT.UI.ViewModels
{
    /// <summary>
    /// Die ViewModel für die Übersicht der Feedback Listen eines Lehrers
    /// </summary>
    public class ModelTeacherFormsListing : BaseViewModel
    {

        #region commands
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den Löschen Button klickt
        /// </summary>
        public ICommand OnButtonDelete { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn der Öffnen Button geklickt wird oder man doppelklickt auf den Eintrag
        /// </summary>
        public ICommand OnButtonSelectOpen { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf den Neu Button klickt
        /// </summary>
        public ICommand OnButtonNew { get; private set; }
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man das Fenster schließt oder auf den Logout Button klickt
        /// </summary>
        public ICommand OnButtonLogout { get; private set; }

        #endregion

        #region properties

        /// <summary>
        /// Die Liste der erstellten Formulare
        /// </summary>
        public ObservableCollection<IForm> FeedbackForms 
        { 
            get { return _feedbackForms; }
            set { SetProperty("FeedbackForms", ref _feedbackForms, value); }
        }
        
        private UserEntity _user;

        /// <summary>
        /// Gibt den Index des ausgewählten Formulars an aus dem Datagrid
        /// </summary>
        public int SelectedIndex { get { return _selectedIndex; } set { SetProperty("SelectedIndex", ref _selectedIndex, value); } }
        #endregion

        #region constructor

        /// <summary>
        /// Erstellt ein neues ViewModel für das Hauptfenster
        /// </summary>
        /// <param name="window">Das dazugehörige View</param>
        public ModelTeacherFormsListing(Window window, UserEntity user) : base(window)
        {
            WindowCaption = "Feedback Listen";

            OnButtonDelete = new RelayCommand(DoButtonDelete);
            OnButtonSelectOpen = new RelayCommand(DoButtonSelectOpen);
            OnButtonNew = new RelayCommand(DoButtonNew);
            OnButtonLogout = new RelayCommand(DoButtonLogout);
            _user = user;

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
            ViewFormsSelection viewFormsSelection = new ViewFormsSelection();
            ModelFormsSelection modelFormsSelection = new ModelFormsSelection(viewFormsSelection);
            
            ShowChildView(viewFormsSelection, modelFormsSelection, true);

            UmfrageEntity umfrage = new UmfrageEntity();
            umfrage.User = _user;
            umfrage.ErstelltDatum = DateTime.Now;
            umfrage.Schluessel = modelFormsSelection.CustomCode;
            
            UmfrageEntity.GetUmfrageService().Insert(umfrage);
            OnLoad();
            
            OnPropertyChanged(nameof(FeedbackForms));
        }
        #endregion

        #region button select open
        /// <summary>
        /// Wird ausgeführt wenn man auf den Button bearbeiten klickt oder doppelklick im Eintrag macht
        /// </summary>
        private void DoButtonSelectOpen()
        {
            IForm? feedbackForm = GetSelectedFeedbackForm();
            if (feedbackForm == null)
            {
                //@TODO Nachricht
                return;
            }
            switch (feedbackForm.FormType)
            {
                case FeedbackFormType.First:
                    WindowNavigation.OpenFormular1();
                    break;
                case FeedbackFormType.Second:
                    WindowNavigation.OpenFormular2();
                    break;
            }
            //@TODO Open Window
        }

        #endregion

        #region button delete

        /// <summary>
        /// Wird ausgeführt, wenn man den Löschen Button klickt
        /// </summary>
        private void DoButtonDelete()
        {
            IForm? feedbackForm = GetSelectedFeedbackForm();
            if (feedbackForm == null)
            {
                //@TODO Nachricht
                return;
            }
            //@TODO REMOVE FROM DATABASE
            FeedbackForms.Remove(feedbackForm);
            SelectedIndex = -1;
            OnPropertyChanged(nameof(FeedbackForms));
            OnPropertyChanged(nameof(SelectedIndex));
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
        /// Wird ausgeführt, wenn das Fenster geladen wird
        /// </summary>
        private void OnLoad()
        {
            foreach (var form in FeedbackForms)
            {
                FeedbackForms.Remove(form);
            }
            IList<UmfrageEntity> umfragen = UmfrageEntity.GetUmfrageService().GetAllByCriteria(
                x => x.User.Id == _user.Id);
            foreach (UmfrageEntity umfrage in umfragen)
            {
                FeedbackForms.Add(new Form {FormType = FeedbackFormType.First, Code = umfrage.Schluessel, TimeStamp = umfrage.ErstelltDatum});
            }
        }

        #endregion

        #region get selected feedback form
        /// <summary>
        /// Gibt das ausgewählte Feedback Formular zurück
        /// </summary>
        /// <returns>Gibt die Klasse IForm zurück, wenn eines aus der Liste ausgewählt wurde, sonst NULL</returns>
        private IForm? GetSelectedFeedbackForm()
        {
            if (_selectedIndex == -1)
            {
                return null;
            }
            return _feedbackForms[_selectedIndex];
        }

        #endregion

        #endregion

        #region member variables

        private ObservableCollection<IForm> _feedbackForms = [];
        private int _selectedIndex = -1;

        #endregion
    }
}
