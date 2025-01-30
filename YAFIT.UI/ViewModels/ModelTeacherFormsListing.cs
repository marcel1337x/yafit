using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using YAFIT.Common;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Interfaces.Forms;
using YAFIT.UI.Views;

namespace YAFIT.UI.ViewModels
{
    public class ModelTeacherFormsListing : BaseViewModel
    {
        public ICommand OnButtonDelete { get; private set; }
        public ICommand OnButtonSelectOpen { get; private set; }
        public ICommand OnButtonNew { get; private set; }
        public ICommand OnButtonLogout { get; private set; }

        public ObservableCollection<IForm> FeedbackForms { get { return _feedbackForms; } set { SetProperty("FeedbackForms", ref _feedbackForms, value); } }
        public int SelectedIndex { get { return _selectedIndex; } set { SetProperty("SelectedIndex", ref _selectedIndex, value); } }

        public ModelTeacherFormsListing(Window window) : base(window)
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
            ShowChildView(selec, model, true);

            //@TODO DATABASE IMPLEMENTATION
            //FeedbackForms.Add(new IForm { Form = FeedbackFormType.First, ID = Guid.NewGuid(), TimeStamp = DateTime.Now });

            OnPropertyChanged(nameof(FeedbackForms));
        }

        private void DoButtonSelectOpen()
        {
            IForm? feedbackForm = GetSelectedFeedbackForm();
            if (feedbackForm == null)
            {
                //@TODO Nachricht
                return;
            }
            if (feedbackForm.FormType == FeedbackFormType.First)
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
            IForm? feedbackForm = GetSelectedFeedbackForm();
            if (feedbackForm == null)
            {
                //@TODO Nachricht
                return;
            }
            //@TODO REMOVE FROM DATABASE
            FeedbackForms.Remove(feedbackForm);
            SelectedIndex = -1;
            OnPropertyChanged(nameof(FeedbackForms));
            OnPropertyChanged(nameof(SelectedIndex));
        }

        private void OnLoad()
        //@TODO Load from database
        {
        }

        private void DoButtonLogout()
        {
            CloseView();
        }

        private IForm? GetSelectedFeedbackForm()
        {
            if (_selectedIndex == -1)
            {
                return null;
            }
            return _feedbackForms[_selectedIndex];
        }

        private ObservableCollection<IForm> _feedbackForms = [];

        private int _selectedIndex = -1;

    }
}
