﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using YAFIT.Common.Enums;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;
using YAFIT.Databases.Services;

namespace YAFIT.UI.ViewModels
{
    /// <summary>
    /// Die ViewModel für die Auswahl der Feedbackformulare
    /// </summary>
    public class ModelFormsSelection : BaseViewModel
    {
        #region commands
        /// <summary>
        /// Der Befehl, der ausgeführt wird, wenn man auf Schlüssel generieren klickt
        /// </summary>
        public ICommand OnGenKey { get; private set; }

        #endregion

        #region properties

        public string[] Klassenliste
        {
            get { return klassen.Select(x => x.Name).ToArray(); }
        }
        public int KlassenIndex
        {
            get { return klassenIndex; }
            set { SetProperty("KlassenIndex", ref klassenIndex, value); }
        }

        public string[] Faecherliste
        {
            get { return faecher.Select(x => x.Name).ToArray(); }
        }
        public int FaecherIndex
        {
            get { return fachIndex; }
            set { SetProperty("FaecherIndex", ref fachIndex, value); }
        }


        public string[] Abteilungsliste
        {
            get { return abteilungen.Select(x => x.Name).ToArray(); }
        }

        public int Abteilungsindex
        {
            get { return fachIndex; }
            set { SetProperty("Abteilungsindex", ref abteilungenIndex, value); }
        }

        public string CustomCode
        {
            get { return _customCode; }
            set { SetProperty("CustomCode", ref _customCode, value); }
        }

        /// <summary>
        /// Gibt an, welcher Button ausgewählt ist anhand des Indices
        /// </summary>
        public bool[] SelectionButton
        {
            get { return _selectedButton; }
            set { _selectedButton = value; }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Erstellt ein neues ViewModel für das Hauptfenster
        /// </summary>
        /// <param name="window">Das dazugehörige View</param>
        public ModelFormsSelection(Window window) : base(window)
        {
            WindowCaption = "YAFIT - Feedbackauswahl";
            OnGenKey = new RelayCommand(DoGenKey);
            
            klassen = KlassenEntity.GetKlassenService().GetAll();
            faecher = FachEntity.GetFachService().GetAll();
            abteilungen = AbteilungEntity.GetAbteilungService().GetAll();

        }

        #endregion

        #region public methods
        /// <summary>
        /// Gibt das ausgewählte Formular als FeedbackFormType zurück,
        /// 0 = Unknown, 1 = FeedbackFormType1, 2 = FeedbackFormType2
        /// </summary>
        /// <returns>Gibt FeedbackFormType(Enum) zurück</returns>
        public FeedbackFormType GetSelectedForm()
        {
            int index = Array.IndexOf(_selectedButton, true);
            if (index == -1)
            {
                return FeedbackFormType.Unknown;
            }
            return (FeedbackFormType)(index + 1);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Wird ausgeführt wenn man den Knopf Schlüssel generieren klickt
        /// </summary>
        private void DoGenKey()
        {
            if(string.IsNullOrEmpty(_customCode) == true)
            {
                CustomCode = _random.Next(10_000_000, 99_999_999).ToString().PadLeft(8, '0'); 
            }
            if(ValidateCode() == false)
            {
                MessageBox.Show("Code existiert bereits!");
                return;
            }

            CloseView();
        }

        private bool ValidateCode()
        {
            if(string.IsNullOrEmpty(_customCode) == true)
            {
                return false;
            }
            //@TODO Database Search for CustomCode/
            return true;
        }
        

        

        #endregion

        #region member variables

        private bool[] _selectedButton = [true, false];

        private string _customCode = string.Empty;
        private readonly Random _random = new Random();
        
        
        public IList<KlassenEntity> klassen = new List<KlassenEntity>();
        private int klassenIndex = -1;
        public IList<FachEntity> faecher = new List<FachEntity>();
        private int fachIndex = -1;
        private IList<AbteilungEntity> abteilungen = new List<AbteilungEntity>();
        private int abteilungenIndex = -1;
        #endregion
    }
}