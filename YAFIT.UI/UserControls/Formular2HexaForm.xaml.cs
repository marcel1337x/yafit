using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace YAFIT.UI.UserControls
{
    /// <summary>
    /// Interaktionslogik für Formular2HexaForm.xaml
    /// </summary>
    public partial class Formular2HexaForm : UserControl
    {
        public Formular2HexaForm()
        {
            InitializeComponent();
            _selectedPieSection = Enumerable.Range(0, 8).Select(x => new bool[5]).ToArray();
            _polygons = Enumerable.Range(0, 8).Select(x => new Polygon[5]).ToArray();
            for (int i = 0; i < 4; i++)
            {
                DrawQuarterPie(i * 90, i);
            }
        }

        public int Length
        {
            get { return _length; }
            set {
                _length = value;
                UpdatePie();
            }
        }

        public bool IsInteractable
        {
            get { return _interactable; }
            set
            {
                _interactable = value;
                UpdatePie();
            }

        }

        public void UpdatePie()
        {
            PieCake.Children.Clear();
            PieCakeLines.Children.Clear();
            _polygons = Enumerable.Range(0, 8).Select(x => new Polygon[5]).ToArray();
            for (int i = 0; i < 4; i++)
            {
                DrawQuarterPie(i * 90, i);
            }
        }

        public void Update()
        {
            for (int poly = 0; poly < _polygons.Length; poly++)
            {
                for (int i = 0; i < 5; i++)
                {
                    bool state = _selectedPieSection[poly][i];
                    Polygon polygon1 = _polygons[poly][i];
                    polygon1.Stroke = state == true ? Brushes.Black : Brushes.Transparent;
                    polygon1.Fill = state == true ? i % 2 == 0 ? Brushes.LightGreen : Brushes.DarkGreen : i % 2 == 0 ? Brushes.LightGray : Brushes.DarkGray;
                }
            }
        }

        public void InteractChart(object o, MouseButtonEventArgs e)
        {
            Polygon polygon = e.Source as Polygon;
            int[] polygonId = polygon.Name.Split("_", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            int poly = polygonId[0];
            int index = polygonId[1];

            for (int i = 0; i < 5; i++)
            {
                _selectedPieSection[poly][i] = false;
            }

            _selectedPieSection[poly][index] = !_selectedPieSection[poly][index];

            for (int i = 0; i < 5; i++)
            {
                bool state = _selectedPieSection[poly][i];
                Polygon polygon1 = _polygons[poly][i];
                polygon1.Stroke = state == true ? Brushes.Black : Brushes.Transparent;
                polygon1.Fill = state == true ? i % 2 == 0 ? Brushes.LightGreen : Brushes.DarkGreen : i % 2 == 0 ? Brushes.LightGray : Brushes.DarkGray;
            }
        }

        private void DrawQuarterPie(int angle, int pieceId)
        {
            double sec = 2.2;
            double third = 3;
            RotateTransform rotation = new()
            {
                Angle = angle
            };
            for (int i = 0; i < 5; i++)
            {
                for (int x = 0; x < 2; x++)
                {
                    int polygonIndex = (pieceId * 2) + x;
                    Polygon polygon = new Polygon()
                    {
                        Fill = i % 2 == 0 ? Brushes.LightGray : Brushes.DarkGray,
                        StrokeThickness = 2,
                        Name = $"_{polygonIndex}_{i}",
                        RenderTransform = rotation,
                    };
                    if (IsInteractable)
                    {
                        polygon.MouseLeftButtonDown += InteractChart;
                    }
                    if (i == 0)
                    {
                        polygon.Points = [
                            new(0, 0),
                            new(sec * _length               , -(sec * _length)),
                            new(x == 0 ? third * _length : 0, x == 0 ? 0 : -(third * _length))
                        ];
                    }
                    else
                    {

                        if (x == 0)
                        {
                            polygon.Points = [
                                new(i * sec   * _length,         -(i * sec * _length)      ),
                                new(i * third * _length,         0                        ),
                                new((i + 1)   * third * _length, 0                        ),
                                new((i + 1)   * sec   * _length, -((i + 1) * sec * _length)),
                            ];
                        }
                        else
                        {
                            polygon.Points = [
                                new (0,                    -((i+1) * third * _length)),
                                new (0,                    -(i     * third * _length)),
                                new (i     * sec * _length, -(i     * sec   * _length)),
                                new ((i+1) * sec * _length, -((i+1) * sec   * _length)),
                            ];
                        }
                    }
                    _polygons[polygonIndex][i] = polygon;
                    PieCake.Children.Add(polygon);
                }
                Line top = new Line()
                {
                    X1 = 0,
                    Y1 = 0,

                    X2 = 0,
                    Y2 = -((i + 1) * third * _length),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    RenderTransform = rotation,
                };
                Line middle = new Line()
                {
                    X1 = i * sec * _length,
                    Y1 = -(i * sec * _length),

                    X2 = (i + 1) * sec * _length,
                    Y2 = -((i + 1) * sec * _length),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    RenderTransform = rotation,
                };
                PieCakeLines.Children.Add(top);
                PieCakeLines.Children.Add(middle);
            }

            PieCake.UpdateLayout();
            PieCakeLines.UpdateLayout();
        }

        public void Dispose()
        {
            for (int poly = 0; poly < _polygons.Length; poly++)
            {
                for (int i = 0; i < 5; i++)
                {
                    _polygons[poly][i].MouseLeftButtonDown -= InteractChart;
                }
            }
        }
        private readonly bool[][] _selectedPieSection;
        private Polygon[][] _polygons;

        private int _length = 15;
        private bool _interactable = true;

        private int GetRating(int i)
        {
            int value = Array.IndexOf(_selectedPieSection[i], true);

            if(value == -1)
            {
                return 0;
            }
            return value + 1;
            
        }

        public int[] GetResults()
        {
            return Enumerable.Range(0, _selectedPieSection.Length).Select(x => GetRating(x)).ToArray();
        }
    }
}
