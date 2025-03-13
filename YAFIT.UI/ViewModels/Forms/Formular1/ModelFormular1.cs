using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;
using YAFIT.UI.UserControls;
using YAFIT.UI.Views.Forms.Formular1;

namespace YAFIT.UI.ViewModels.Forms.Formular1
{
    /// <summary>
    /// ViewModel für das 1. Formular
    /// </summary>
    internal class ModelFormular1 : BaseViewModel
    {
        #region commands
        /// <summary>
        /// Eine Eigenschaft, die den Befehl zum Senden des Ergebnisses enthält
        /// </summary>
        public ICommand OnSendResult { get; private set; }

        #endregion

        #region properties

        /// <summary>
        /// Eine Eigenschaft, die die Antworten für die Textboxen enthält
        /// </summary>
        public string[] TextBoxQuestions
        {
            get { return _textBoxQuestions; }
            set { SetProperty(nameof(TextBoxQuestions), ref _textBoxQuestions, value); }
        }
        #endregion

        #region constructor

        /// <summary>
        /// Erstellt ein neues ViewModel für das Hauptfenster
        /// </summary>
        /// <param name="window">Das dazugehörige View</param>
        public ModelFormular1(Window window, UmfrageEntity umfrage) : base(window)
        {
            _umfrage = umfrage;
            OnLoad();
            OnSendResult = new RelayCommand(DoSendResult);
        }

        #endregion

        #region private methods

        #region send result

        /// <summary>
        /// Sendet das Ergebnis
        /// </summary>
        private void DoSendResult()
        {
            if (_view is ViewFormular1 formular == false)
            {
                return;
            }
            
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

            form.Umfrage_Id = _umfrage.Id;

            // Speichern in der Datenbank
            Formular1Entity.GetFormular1Service().Insert(form);


            Debug.WriteLine(string.Join("\n", results));
            CloseView();
        }
        #endregion

        #region get button results

        /// <summary>
        /// Gibt das Ergebnis der Knöpfe als Byte-Array zurück
        /// </summary>
        /// <returns>Gibt ein Byte[] zurück</returns>
        private byte[] GetButtonsResults()
        {
            if (_view is ViewFormular1 formular == false)
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
        #endregion

        #region onload

        /// <summary>
        /// Wird aufgerufen, wenn das Fenster geladen wird
        /// </summary>
        private void OnLoad()
        {
            if (_view is ViewFormular1 formular == false)
            {
                return;
            }

            //Fragen Gruppe 1
            {
                StackPanel stackPanel = formular.EntryGroup1;
                stackPanel.Children.Clear();
                for (int i = 0; i < _presetGroup1.Length; i++)
                {
                    FormEntryTextCheckboxDouble formEntryTextCheckBox = new()
                    {
                        Text1 = _presetGroup1[i][0],
                        Text2 = _presetGroup1[i][1]
                    };
                    stackPanel.Children.Add(formEntryTextCheckBox);
                }
            }
            //Fragen Gruppe 2
            {
                StackPanel stackPanel = formular.EntryGroup2;
                stackPanel.Children.Clear();
                for (int i = 0; i < _presetGroup2.Length; i++)
                {
                    FormEntryTextCheckboxSingle formEntryTextCheckBox = new()
                    {
                        Text1 = _presetGroup2[i]
                    };
                    stackPanel.Children.Add(formEntryTextCheckBox);
                }
            }

            //Fragen Gruppe 3
            {
                StackPanel stackPanel = formular.EntryGroup3;
                stackPanel.Children.Clear();
                for (int i = 0; i < _presetGroup3.Length; i++)
                {
                    FormEntryTextCheckboxSingle formEntryTextCheckBox = new()
                    {
                        Text1 = _presetGroup3[i]
                    };
                    stackPanel.Children.Add(formEntryTextCheckBox);
                }
            }
            //Fragen Gruppe 4
            {
                StackPanel stackPanel = formular.EntryGroup4;
                stackPanel.Children.Clear();
                for (int i = 0; i < _presetGroup4.Length; i++)
                {
                    FormEntryTextCheckboxSingle formEntryTextCheckBox = new()
                    {
                        Text1 = _presetGroup4[i]
                    };
                    stackPanel.Children.Add(formEntryTextCheckBox);
                }
            }
            formular.UpdateLayout();
        }

        #endregion

        #region button group result 
        /// <summary>
        /// Eine Hilfsmethode die das Ergebnis einer Gruppe
        /// aus den Klassen (FormEntryTextCheckboxSingle, FormEntryTextCheckboxDouble) zurückgibt
        /// </summary>
        /// <typeparam name="T">Generische Klassentyp</typeparam>
        /// <param name="stackPanel">Das Stackpanel</param>
        /// <returns>Gibt einen Byte[] zurück</returns>
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
        #endregion

        #endregion

        #region member variables

        private string[] _textBoxQuestions = [string.Empty, string.Empty, string.Empty];
        private readonly UmfrageEntity _umfrage;

        private static readonly string[][] _presetGroup1 = [
            ["Sie/Er ist...", "...ungeduldig"],
            ["","...sicher im Auftreten"],
            ["","...freundlich"],
            ["","...erregbar und aufbrausend"],
            ["","...tatkräftig, aktiv"],
            ["","...aufgeschlossen"]
        ];
        private static readonly string[] _presetGroup2 = [
            "... bevorzugt manche Schülerinnen oder Schüler.",
            "...nimmt die Schülerinnen und Schüler ernst.",
            "...ermutigt und lobt viel.",
            "...entscheidet immer allein. ",
            "...gesteht eigene Fehler ein."
        ];
        private static readonly string[] _presetGroup3 = [
            "Die Ziele des Unterrichts sind klar erkennbar.",
            "Der Lehrer redet zu viel.",
            "Der Lehrer schweift oft vom Thema ab.",
            "Die Fragen und Beiträge der Schülerinnen und Schüler werden ernstgenommen.",
            "Die Sprache des Lehrers ist gutverständlich.",
            "Der Lehrer achtet auf Ruhe und Disziplin im Unterricht.",
            "Der Unterricht ist abwechslungsreich.",
            "Unterrichtsmaterialien sind ansprechend und gut verständlich gestaltet.",
            "Der Stoff wird ausreichend wiederholt und geübt."
        ];

        private static readonly string[] _presetGroup4 = [
            "Die Themen der Schulaufgaben werden rechtzeitig vorher bekannt gegeben.",
            "Der Schwierigkeitsgrad der Leistungsnachweise entspricht dem der Unterrichtsinhalte.",
            "Die Bewertungen sind nachvollziehbar und verständlich."
        ];


        #endregion
    }
}
