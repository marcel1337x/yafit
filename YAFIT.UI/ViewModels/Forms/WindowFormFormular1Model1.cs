using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YAFIT.Common.UI.ViewModel;
using YAFIT.UI.Resources.UserControls;
using YAFIT.UI.Views.Forms.Formular1;

namespace YAFIT.UI.ViewModels.Forms
{
    internal class WindowFormFormular1Model1 : BaseViewModel
    {

        public ICommand OnSendResult { get; private set; }

        public WindowFormFormular1Model1(Window window) : base(window)
        {
            OnLoad();
            OnSendResult = new RelayCommand(DoSendResult);
        }


        private void DoSendResult()
        {
            if (_view is Formular1_1 formular == false)
            {
                return;
            }
            byte[] results = GetButtonsResults();
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

            byte[] results = GetGroupResultOf<FormEntryTextCheckboxDouble>(group1)
                .Concat(GetGroupResultOf<FormEntryTextCheckboxSingle>(group2))
                .Concat(GetGroupResultOf<FormEntryTextCheckboxSingle>(group3))
                .Concat(GetGroupResultOf<FormEntryTextCheckboxSingle>(group4))
                .ToArray();
            return results;
        }

        #region onload

        private void OnLoad()
        {
            if (_view is Formular1_1 formular == false)
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

        private static byte[] GetGroupResultOf<T>(StackPanel stackPanel) 
        {
            byte[] results = new byte[stackPanel.Children.Count];
            for(int i = 0; i < results.Length; i++)
            {
                if(stackPanel.Children[i] is T formEntryTextCheckBox == false)
                {
                    results[i] = 0x00; // 0 = null / nicht ausgewählt
                    continue;
                }
                MethodInfo? methodInfo = formEntryTextCheckBox.GetType().GetMethod("GetSelection");
                if(methodInfo == null)
                {
                    results[i] = 0x00;
                    continue;
                }
                object? value = methodInfo.Invoke(formEntryTextCheckBox, null);
                results[i] = (byte)((int?)value ?? 0);
            }
            return results;
        }


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
    }
}
