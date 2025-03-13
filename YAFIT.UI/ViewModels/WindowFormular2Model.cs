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


        public WindowFormular2Model(Window window) : base(window)
        {
            
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
            //{
            //    StackPanel stackPanel = formular.EntryGroup3;
            //    stackPanel.Children.Clear();

            //    FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
            //    {

            //    };
            //    stackPanel.Children.Add(formEntryTextCheckBox);

            //}
            //Fragen Gruppe 4
            //{
            //    StackPanel stackPanel = formular.EntryGroup4;
            //    stackPanel.Children.Clear();

            //    FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
            //    {

            //    };
            //    stackPanel.Children.Add(formEntryTextCheckBox);

            //}
            //Fragen Gruppe 5
            //{
            //    StackPanel stackPanel = formular.EntryGroup5;
            //    stackPanel.Children.Clear();

            //    FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
            //    {

            //    };
            //    stackPanel.Children.Add(formEntryTextCheckBox);

            //}
            //Fragen Gruppe 6
            //{
            //    StackPanel stackPanel = formular.EntryGroup6;
            //    stackPanel.Children.Clear();

            //    FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
            //    {

            //    };
            //    stackPanel.Children.Add(formEntryTextCheckBox);

            //}
            //Fragen Gruppe 7
            //{
            //    StackPanel stackPanel = formular.EntryGroup7;
            //    stackPanel.Children.Clear();

            //    FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
            //    {

            //    };
            //    stackPanel.Children.Add(formEntryTextCheckBox);

            //}
            //Fragen Gruppe 8
        //    {
        //        StackPanel stackPanel = formular.EntryGroup8;
        //        stackPanel.Children.Clear();

        //        FormEntryLineRadiobuttonSingle formEntryTextCheckBox = new()
        //        {

        //        };
        //        stackPanel.Children.Add(formEntryTextCheckBox);

        //    }


           formular.UpdateLayout();
        }

        /// <summary>
        /// Sendet das Ergebnis
        /// </summary>
        private void DoSendResult()
        {
            
            CloseView();
        }

        private byte[] GetButtonsResults()
        {
            return [];
        }
        private readonly UmfrageEntity _umfrage;
    }

}
