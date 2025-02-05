using System.Windows;
using System.Windows.Input;
using YAFIT.Common.Enums;
using YAFIT.Common.UI.ViewModel;

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
            CloseView();
        }

        #endregion

        #region member variables

        private bool[] _selectedButton = [true, false];

        #endregion
    }
}