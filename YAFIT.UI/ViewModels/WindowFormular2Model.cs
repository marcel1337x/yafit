using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Data;
using YAFIT.Databases.Entities;
using YAFIT.UI.UserControls;
using YAFIT.UI.Views.Forms.Formular1;

namespace YAFIT.UI.ViewModels
{

    internal class WindowFormular2Model : BaseViewModel
    {
        public ICommand OnSendResult { get; private set; }
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



        public WindowFormular2Model(Window window, UmfrageEntity umfrage) : base(window)
        {
            _umfrage = umfrage;

        }

        /// <summary>
        /// Sendet das Ergebnis
        /// </summary>
        private void DoSendResult()
        {
            

            byte[] results = GetButtonsResults();
            Formular1Entity form = new Formular1Entity();

            form.VerhaltenLehrer0 = (int)results[0];
            form.VerhaltenLehrer1 = (int)results[1];
            form.VerhaltenLehrer2 = (int)results[2];
            form.VerhaltenLehrer3 = (int)results[3];
            form.VerhaltenLehrer4 = (int)results[4];
            form.VerhaltenLehrer5 = (int)results[5];
            form.DieLehrer0 = (int)results[6];
            form.DieLehrer1 = (int)results[7];
            form.DieLehrer2 = (int)results[8];
            form.DieLehrer3 = (int)results[9];
            form.DieLehrer4 = (int)results[10];
            form.Unterricht0 = (int)results[11];
            form.Unterricht1 = (int)results[12];
            form.Unterricht2 = (int)results[13];
            form.Unterricht3 = (int)results[14];
            form.Unterricht4 = (int)results[15];
            form.Unterricht5 = (int)results[16];
            form.Unterricht6 = (int)results[17];
            form.Unterricht7 = (int)results[18];
            form.Unterricht8 = (int)results[19];
            form.Bewertung0 = (int)results[20];
            form.Bewertung1 = (int)results[21];
            form.Bewertung2 = (int)results[22];

            // Textfelder hinzufügen
            form.Text0 = TextBoxQuestions[0];
            form.Text1 = TextBoxQuestions[1];
            form.Text2 = TextBoxQuestions[2];

            form.Umfrage = _umfrage;

            // Speichern in der Datenbank
            Formular1Entity.GetFormular1Service().Insert(form);


            Debug.WriteLine(string.Join("\n", results));
            CloseView();
        }

        private byte[] GetButtonsResults()
        {
            if (_view is Formular1_1 formular == false)
            {
                return [];
            }
            StackPanel group1 = formular.EntryGroup1;
            StackPanel group2 = formular.EntryGroup2;
            StackPanel group3 = formular.EntryGroup3;
            StackPanel group4 = formular.EntryGroup4;

            return
            [
                .. GetGroupResultOf<FormEntryTextCheckboxDouble>(group1),
                .. GetGroupResultOf<FormEntryTextCheckboxSingle>(group2),
                .. GetGroupResultOf<FormEntryTextCheckboxSingle>(group3),
                .. GetGroupResultOf<FormEntryTextCheckboxSingle>(group4),
            ];
        }

        private static byte[] GetGroupResultOf<T>(StackPanel stackPanel)
        {
            byte[] results = new byte[stackPanel.Children.Count];
            for (int i = 0; i < results.Length; i++)
            {
                if (stackPanel.Children[i] is T formEntryTextCheckBox == false)
                {
                    results[i] = 0x00; // 0 = null / nicht ausgewählt
                    continue;
                }
                MethodInfo? methodInfo = formEntryTextCheckBox.GetType().GetMethod("GetSelection");
                if (methodInfo == null)
                {
                    results[i] = 0x00;
                    continue;
                }
                object? value = methodInfo.Invoke(formEntryTextCheckBox, null);
                results[i] = (byte)((int?)value ?? 0);
            }
            return results;
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
