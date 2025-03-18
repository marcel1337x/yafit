using System.Windows;
using System.Windows.Controls;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;
using YAFIT.UI.Views.Forms.Formular2;

namespace YAFIT.UI.ViewModels.Forms.Formular2
{
    public class ModelFormular2Result : BaseViewModel
    {
        public ModelFormular2Result(Window window, UmfrageEntity umfrage) : base(window)
        {

            _umfrage = umfrage;
            OnLoad();
        }

        public void OnLoad()
        {
            if (_view is ViewFormular2Result formular == false)
            {
                return;
            }
            IList<Formular2Entity> entities = Formular2Entity.GetFormular2Service().GetAllByCriteria(x => x.Umfrage_Id == _umfrage.Id);

            StackPanel panel = formular.CommentPanel;
            foreach(var entity in entities)
            {
                panel.Children.Add(new TextBlock() { Text = entity.Text, TextWrapping = TextWrapping.Wrap });
            }

            formular.UpdateLayout();
        }

        private readonly UmfrageEntity _umfrage;

    }
}
