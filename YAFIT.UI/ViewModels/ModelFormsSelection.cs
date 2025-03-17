using System.Windows;
using System.Windows.Input;
using YAFIT.Common.Enums;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;

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


        public IList<KlassenEntity> KlassenList
        {
            get { return _klassen; }
        }

        public IList<FachEntity> FaecherList
        {
            get { return _faecher; }
        }
        public IList<AbteilungEntity> AbteilungsList
        {
            get { return _abteilungen; }
        }
        public int KlassenIndex
        {
            get { return _klassenIndex; }
            set { SetProperty("KlassenIndex", ref _klassenIndex, value); }
        }

        public int FaecherIndex
        {
            get { return _fachIndex; }
            set { SetProperty("FaecherIndex", ref _fachIndex, value); }
        }


        public int AbteilungsIndex
        {
            get { return _fachIndex; }
            set { SetProperty("AbteilungsIndex", ref _abteilungenIndex, value); }
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

            _klassen = KlassenEntity.GetKlassenService().GetAll();
            _faecher = FachEntity.GetFachService().GetAll();
            _abteilungen = AbteilungEntity.GetAbteilungService().GetAll();

            CustomCode = _random.Next(10_000_000, 99_999_999).ToString().PadLeft(8, '0');

        }

        #endregion

        #region public methods
        /// <summary>
        /// Gibt das ausgewählte Formular als FeedbackFormType zurück,
        /// 0 = Unknown, 1 = FeedbackFormType1, 2 = FeedbackFormType2, 3 = FeedbackFormType3
        /// </summary>
        /// <returns>Gibt FeedbackFormType(Enum) zurück</returns>
        public FeedbackFormType GetSelectedForm()
        {
            Console.Write("Button: " + _selectedButton);
            int index = Array.IndexOf(_selectedButton, true);
            Console.WriteLine("index: " + index);
            if (index == -1)
            {
                Console.WriteLine("Unkown");
                return FeedbackFormType.Unknown;
            }
            return (FeedbackFormType)(index + 1);
        }

        #endregion


        public bool ShouldSave()
        {
            return _save;
        }


        #region private methods

        /// <summary>
        /// Wird ausgeführt wenn man den Knopf Schlüssel generieren klickt
        /// </summary>
        private void DoGenKey()
        {
            if (Validate() == false)
            {
                MessageBox.Show("Code existiert bereits!");
                return;
            }
            _save = true;
            CloseView();
        }

        private bool Validate()
        {
            if (_abteilungenIndex == -1 ||
                _klassenIndex == -1 ||
                _fachIndex == -1)
            {
                return false;
            }
            if (string.IsNullOrEmpty(_customCode) == true)
            {
                return false;
            }
            return UmfrageEntity.GetUmfrageService().GetAllByCriteria(x => x.Schluessel == _customCode).Count == 0;
        }

        #endregion

        #region member variables

        private readonly Random _random = new Random();

        private bool[] _selectedButton = [true, false];
        private string _customCode = string.Empty;
        private IList<AbteilungEntity> _abteilungen = [];
        private IList<KlassenEntity> _klassen = [];
        private IList<FachEntity> _faecher = [];
        private int _abteilungenIndex = -1;
        private int _klassenIndex = -1;
        private int _fachIndex = -1;
        public bool _save = false;
        #endregion
    }
}