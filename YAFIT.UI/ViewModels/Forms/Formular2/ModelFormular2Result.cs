using FluentNHibernate.Utils;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;
using YAFIT.UI.UserControls;
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

            int[][] results = [.. Enumerable.Range(0, 8).Select(x => new int[] { 0, 0, 0, 0, 0 })];

            foreach (var entity in entities)
            {
                if (entity.Question1 != 0)
                    results[0][entity.Question1 - 1] += 1;
                if (entity.Question2 != 0)
                    results[1][entity.Question2 - 1] += 1;
                if (entity.Question3 != 0)
                    results[2][entity.Question3 - 1] += 1;
                if (entity.Question4 != 0)
                    results[3][entity.Question4 - 1] += 1;
                if (entity.Question5 != 0)
                    results[4][entity.Question5 - 1] += 1;
                if (entity.Question6 != 0)
                    results[5][entity.Question6 - 1] += 1;
                if (entity.Question7 != 0)
                    results[6][entity.Question7 - 1] += 1;
                if (entity.Question8 != 0)
                    results[7][entity.Question8 - 1] += 1;
            }

            Formular2HexaForm hexa = formular.HexaCanvas;

            for (int i = 0; i < results.Length; i++)
            {
                int[] result = results[i];
                Polygon[] polygons = hexa._polygons[i];
                var ordered = result.Select((x, i) => new { Index = i, Value = x }).OrderByDescending(x => x.Value).ToArray();
                for (int x = 0; x < ordered.Length; x++)
                {
                    Debug.WriteLine(ordered[x].Index + "/" + ordered.Length+", "+polygons.Length);
                    polygons[ordered[x].Index].Fill = ToSolidColorBrush(x <= 1 ? ControlConstants.Formular1ColorGood(x) : ControlConstants.Formular1ColorBad(x-2));
                }

                StackPanel panel = formular.CommentPanel;
                foreach (var entity in entities)
                {
                    panel.Children.Add(new TextBlock() { Text = entity.Text, TextWrapping = TextWrapping.Wrap });
                }

                formular.UpdateLayout();
            }
        }

        private SolidColorBrush ToSolidColorBrush(System.Drawing.Color color)
        {
            return new()
            {
                Color = new Color { R = color.R, G = color.G, B = color.B, A = color.A }
            };
        }

        private readonly UmfrageEntity _umfrage;

    }
}
