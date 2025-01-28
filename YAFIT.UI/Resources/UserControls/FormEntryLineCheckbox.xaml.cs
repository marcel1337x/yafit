using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace YAFIT.UI.Resources.UserControls
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
