using System.Windows;
using System.Windows.Input;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;
using YAFIT.UI.UserControls;
using YAFIT.UI.Views;

namespace YAFIT.UI.ViewModels
{

    internal class WindowFormular2Model : BaseViewModel
    {
        public ICommand OnSendResult { get; private set; }

        /// <summary>
        /// Eine Eigenschaft, die die Antworten für die Textboxen enthält
        /// </summary>
        public string[] TextBoxQuestions
        {
            get { return _textBoxQuestions; }
            set { SetProperty(nameof(TextBoxQuestions), ref _textBoxQuestions, value); }
        }


        public WindowFormular2Model(Window window, UmfrageEntity umfrage) : base(window)
        {
            _umfrage = umfrage;
            OnLoad();
            OnSendResult = new RelayCommand(DoSendResult);

        }

        private void OnLoad()
        {
            if (_view is ViewFormular2 formular == false)
            {
                return;
            }

        }

        /// <summary>
        /// Sendet das Ergebnis
        /// </summary>
        private void DoSendResult()
        {
            if (_view is ViewFormular2 formular == false)
            {
                return;
            }

            Formular2Entity form = new Formular2Entity();

            Formular2HexaForm hexaForm = formular.HexaCanvas;
            int[] results = hexaForm.GetResults();

            form.Question1 = results[0];
            form.Question2 = results[1];
            form.Question3 = results[2];
            form.Question4 = results[3];
            form.Question5 = results[4];
            form.Question6 = results[5];
            form.Question7 = results[6];
            form.Question8 = results[7];

            // Textfelder hinzufügen
            form.Text = TextBoxQuestions[0];
            form.Umfrage_Id = _umfrage.Id;

            // Speichern in der Datenbank
            Formular2Entity.GetFormular2Service().Insert(form);
            CloseView();
        }

        private readonly UmfrageEntity _umfrage;
        private string[] _textBoxQuestions = [string.Empty];
    }

}
