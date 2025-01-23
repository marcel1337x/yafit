using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Xps;
using YAFIT.Common;
using YAFIT.Data;
using YAFIT.UI.Resources;
using YAFIT.UI.Views;

namespace YAFIT.UI.ViewModels
{
    public class WindowFeedbackListingModel : BaseViewModel
    {
        public ICommand OnButtonDelete { get; private set; }
        public ICommand OnButtonSelectOpen { get; private set; }
        public ICommand OnButtonNew { get; private set; }
        public ICommand OnButtonLogout { get; private set; }

        public List<FeedbackForm> FeedbackForms { get { return _feedbackForms; } set { SetProperty("FeedbackForms", ref _feedbackForms, value); } }
        public int SelectedIndex { get { return _selectedIndex; } set { SetProperty("SelectedIndex", ref _selectedIndex, value); } }

        public WindowFeedbackListingModel(Window window) : base(window)
        {
            WindowCaption = "Feedback Listen";

            OnButtonDelete = new RelayCommand(DoButtonDelete);
            OnButtonSelectOpen = new RelayCommand(DoButtonSelectOpen);
            OnButtonNew = new RelayCommand(DoButtonNew);
            OnButtonLogout = new RelayCommand(DoButtonLogout);
            OnLoad();
        }


        private void DoButtonNew()
        {
            SelectionView selec = new SelectionView();
            SelectionViewModel model = new SelectionViewModel(selec);
            ShowChildView(selec, model,true);
            if (model.IsFeedbackFormular1Selected)
            {
                Console.WriteLine("Formular 1 Ausgewählt");
                FeedbackForms.Add(new FeedbackForm { Form = Common.FormType.First,ID = Guid.NewGuid(), TimeStamp = DateTime.Now });
            }else if (model.IsFeedbackFormular2Selected)
            {
                Console.WriteLine("Formular 2 Ausgewählt");
                FeedbackForms.Add(new FeedbackForm { Form = Common.FormType.Second,ID = Guid.NewGuid(), TimeStamp = DateTime.Now });
            }
            
            FeedbackForms = [.. FeedbackForms];
            //@TODO ADD TO DATABASE
        }

        private void DoButtonSelectOpen()
        {
            FeedbackForm? feedbackForm = GetSelectedFeedbackForm();
            if (feedbackForm == null)
            {
                //@TODO Nachricht
                return;
            }
            if (feedbackForm.Form == FormType.First)
            {
                WindowNavigation.OpenWindowFeedback1();
            }
            else
            {
                MessageBox.Show("Nicht implementiert.");
            }
            //@TODO Open Window
        }


        private void DoButtonDelete()
        {
            FeedbackForm? feedbackForm = GetSelectedFeedbackForm();
            if (feedbackForm == null)
            {
                //@TODO Nachricht
                return;
            }
            //@TODO REMOVE FROM DATABASE
            FeedbackForms.Remove(feedbackForm);
            FeedbackForms = [.. FeedbackForms];
            SelectedIndex = -1;
        }

        private void OnLoad()
            //@TODO Load from database
        {
        }

        private void DoButtonLogout()
        {
            CloseView();
        }

        private FeedbackForm? GetSelectedFeedbackForm()
        {
            if(_selectedIndex == -1)
            {
                return null;
            }
            return _feedbackForms[_selectedIndex];
        }

        private List<FeedbackForm> _feedbackForms = new List<FeedbackForm>();

        private int _selectedIndex = -1;

    }
}
