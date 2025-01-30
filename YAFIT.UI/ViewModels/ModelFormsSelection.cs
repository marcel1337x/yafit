using System.Windows;
using System.Windows.Input;
using YAFIT.Common;
using YAFIT.Common.UI.ViewModel;

namespace YAFIT.UI.ViewModels;

public class ModelFormsSelection : BaseViewModel
{

    public bool[] SelectionButton
    {
        get { return _selectedButton; }
        set { _selectedButton = value; }
    }
    
    public ICommand OnGenKey { get; private set; }
    
    public ModelFormsSelection(Window window) : base(window)
    {
        WindowCaption = "YAFIT - Feedbackauswahl";
        OnGenKey = new RelayCommand(DoGenKey);
    }

    public FeedbackFormType GetSelectedForm()
    {
        int index = Array.IndexOf(_selectedButton, true);
        if(index == -1)
        {
            return FeedbackFormType.Unknown;
        }
        return (FeedbackFormType)(index + 1);
    }
    
    private void DoGenKey()
    {
        CloseView();
    }

    private bool[] _selectedButton = [true, false];
}