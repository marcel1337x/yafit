using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using YAFIT.UI.Resources;

namespace YAFIT.UI.ViewModels;

public class SelectionViewModel : BaseViewModel
{
    //public bool SelectFb1 { get; private set; }
    //public bool SelectFb2 { get; private set; }
    public ICommand OnGenKey { get; private set; }
    
    public SelectionViewModel(Window window) : base(window)
    {
        WindowCaption = "YAFIT - Feedbackauswahl";
        OnGenKey = new RelayCommand(DoGenKey);
    }

    private void DoGenKey()
    {
        MessageBox.Show("Testkey 123");
        //Debug.WriteLine(SelectFb1.ToString());
        //Debug.WriteLine(SelectFb2.ToString());
    }
}