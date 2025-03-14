using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;
using YAFIT.UI.UserControls;
using YAFIT.UI.Views;
using YAFIT.UI.Views.Forms.Formular1;

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
            if (_view is WindowFeedback2 formular == false)
            {
                return;
            }

            //Fragen Gruppe 1
            {
                StackPanel stackPanel = formular.EntryGroup1;
                stackPanel.Children.Clear();
                
                    FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
                    {
                        
                    };
                    stackPanel.Children.Add(formEntryTextCheckBox);
                
            }
            //Fragen Gruppe 2
            {
                StackPanel stackPanel = formular.EntryGroup2;
                stackPanel.Children.Clear();

                FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
                {

                };
                stackPanel.Children.Add(formEntryTextCheckBox);

            }
            //Fragen Gruppe 3
            {
                StackPanel stackPanel = formular.EntryGroup3;
                stackPanel.Children.Clear();

                FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
                {

                };
                stackPanel.Children.Add(formEntryTextCheckBox);

            }
            //Fragen Gruppe 4
            {
                StackPanel stackPanel = formular.EntryGroup4;
                stackPanel.Children.Clear();

                FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
                {

                };
                stackPanel.Children.Add(formEntryTextCheckBox);

            }
            //Fragen Gruppe 5
            {
                StackPanel stackPanel = formular.EntryGroup5;
                stackPanel.Children.Clear();

                FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
                {

                };
                stackPanel.Children.Add(formEntryTextCheckBox);

            }
            //Fragen Gruppe 6
            {
                StackPanel stackPanel = formular.EntryGroup6;
                stackPanel.Children.Clear();

                FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
                {

                };
                stackPanel.Children.Add(formEntryTextCheckBox);

            }
            //Fragen Gruppe 7
            {
                StackPanel stackPanel = formular.EntryGroup7;
                stackPanel.Children.Clear();

                FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
                {

                };
                stackPanel.Children.Add(formEntryTextCheckBox);

            }
            //Fragen Gruppe 8
            {
                StackPanel stackPanel = formular.EntryGroup8;
                stackPanel.Children.Clear();

                FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
                {

                };
                stackPanel.Children.Add(formEntryTextCheckBox);

            }


            formular.UpdateLayout();
        }

        /// <summary>
        /// Sendet das Ergebnis
        /// </summary>
        private void DoSendResult()
        {
            byte[] results = GetButtonsResults();
            Formular2Entity form = new Formular2Entity();

            form.Question1 = (int)results[0];
            form.Question2 = (int)results[1];
            form.Question3 = (int)results[2];
            form.Question4 = (int)results[3];
            form.Question5 = (int)results[4];
            form.Question6 = (int)results[5];
            form.Question7 = (int)results[6];
            form.Question8 = (int)results[7];
            
            // Textfelder hinzufügen
            form.Text = TextBoxQuestions[0];
            

            form.Umfrage_Id = _umfrage.Id;

            // Speichern in der Datenbank
            Formular2Entity.GetFormular2Service().Insert(form);
            Debug.WriteLine(string.Join(", ",form.Question8,form.Text));
            CloseView(); 
        }
        /// <summary>
        /// Gibt das Ergebnis der Knöpfe als Byte-Array zurück
        /// </summary>
        /// <returns>Gibt ein Byte[] zurück</returns>
        private byte[] GetButtonsResults()
        {
            if (_view is WindowFeedback2 formular == false)
            {
                return [];
            }
            StackPanel group1 = formular.EntryGroup1;
            StackPanel group2 = formular.EntryGroup2;
            StackPanel group3 = formular.EntryGroup3;
            StackPanel group4 = formular.EntryGroup4;
            StackPanel group5 = formular.EntryGroup5;
            StackPanel group6 = formular.EntryGroup6;
            StackPanel group7 = formular.EntryGroup7;
            StackPanel group8 = formular.EntryGroup8;

            return
            [
                .. GetGroupResultOf<FormEntryLineRadiobuttonSingle>(group1),
                .. GetGroupResultOf<FormEntryLineRadiobuttonSingle>(group2),
                .. GetGroupResultOf<FormEntryLineRadiobuttonSingle>(group3),
                .. GetGroupResultOf<FormEntryLineRadiobuttonSingle>(group4),
                .. GetGroupResultOf<FormEntryLineRadiobuttonSingle>(group5),
                .. GetGroupResultOf<FormEntryLineRadiobuttonSingle>(group6),
                .. GetGroupResultOf<FormEntryLineRadiobuttonSingle>(group7),
                .. GetGroupResultOf<FormEntryLineRadiobuttonSingle>(group8),
            ];
        }
        private static byte[] GetGroupResultOf<T>(StackPanel stackPanel)
        {
            foreach (var entry in stackPanel.Children)
            {
                if(entry is FormEntryLineRadiobuttonSingle formEntry == false)
                {
                    continue;
                }
                MethodInfo? methodInfo = formEntry.GetType().GetMethod("GetSelection");
                if (methodInfo == null)
                {
                    continue;
                }

                object? value = methodInfo.Invoke(formEntry, null);
                return [(byte)((int?)value ?? 0)];
            }
            return [0];
            
        }
        private readonly UmfrageEntity _umfrage;
        private string[] _textBoxQuestions = [string.Empty];
    }

}
