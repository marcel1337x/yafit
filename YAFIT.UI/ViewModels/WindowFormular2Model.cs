using System.Windows;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Data;
using YAFIT.Databases.Entities;

namespace YAFIT.UI.ViewModels
{

    internal class WindowFormular2Model : BaseViewModel
    {
        public string[] TextBoxQuestions
        {
            get { return _textBoxQuestions; }
            set { SetProperty(nameof(TextBoxQuestions), ref _textBoxQuestions, value); }
        }

        

        public DartboardCheckbox Nachvollziehbar { get => nachvollziehbar; set => nachvollziehbar = value; }
        public DartboardCheckbox Hintergrundwissen { get => hintergrundwissen; set => hintergrundwissen = value; }
        public DartboardCheckbox Lernklima { get => lernklima; set => lernklima = value; }
        public DartboardCheckbox Vielfältig { get => vielfältig; set => vielfältig = value; }
        public DartboardCheckbox Lerneviel { get => lerneviel; set => lerneviel = value; }
        public DartboardCheckbox Interesse { get => interesse; set => interesse = value; }
        public DartboardCheckbox Vorbereitet { get => vorbereitet; set => vorbereitet = value; }
        public DartboardCheckbox Folgen { get => folgen; set => folgen = value; }

        public WindowFormular2Model(Window window) : base(window)
        {
            

        }

        private string[] _textBoxQuestions = [string.Empty, string.Empty, string.Empty];
        private readonly UmfrageEntity _umfrage;
        private DartboardCheckbox nachvollziehbar = new DartboardCheckbox();

        private DartboardCheckbox hintergrundwissen = new DartboardCheckbox();
        private DartboardCheckbox lernklima = new DartboardCheckbox();
        private DartboardCheckbox vielfältig = new DartboardCheckbox();
        private DartboardCheckbox lerneviel = new DartboardCheckbox();
        private DartboardCheckbox interesse = new DartboardCheckbox();
        private DartboardCheckbox vorbereitet = new DartboardCheckbox();
        private DartboardCheckbox folgen = new DartboardCheckbox();
    }

}
