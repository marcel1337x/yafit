using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using YAFIT.UI.Resources;

namespace YAFIT.UI.ViewModels;

public class SelectionViewModel : BaseViewModel
{
    private bool _isFeedbackFormular1Selected;
    private bool _isFeedbackFormular2Selected;
    public bool IsFeedbackFormular1Selected
    {
        get => _isFeedbackFormular1Selected;
        set
        {
            if (_isFeedbackFormular1Selected != value)
            {
                _isFeedbackFormular1Selected = value;
            }
        }
    }

    public bool IsFeedbackFormular2Selected
    {
        get => _isFeedbackFormular2Selected;
        set
        {
            if (_isFeedbackFormular2Selected != value)
            {
                _isFeedbackFormular2Selected = value;
            }
        }
    }
    
    public ICommand OnGenKey { get; private set; }
    
    public SelectionViewModel(Window window) : base(window)
    {
        WindowCaption = "YAFIT - Feedbackauswahl";
        OnGenKey = new RelayCommand(DoGenKey);
    }
    
    private void DoGenKey()
    {
        if (_isFeedbackFormular1Selected || _isFeedbackFormular2Selected)
        {
            CloseView();
        }
    }
}