using System.Windows.Controls;

namespace YAFIT.UI.UserControls
{
    /// <summary>
    /// Interaktionslogik für CircleFeedback.xaml
    /// </summary>
    public partial class FormEntryLineCheckbox : UserControl
    {

        public FormEntryLineCheckbox()
        {
            InitializeComponent();
            DataContext = this;
            Grid grid = CircleGrid;
            grid.SizeChanged += (sender, e) => Update();
            Update();
        }

        private void Update()
        {
        }
    }
}
