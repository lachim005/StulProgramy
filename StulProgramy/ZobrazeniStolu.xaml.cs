using StulKnihovna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StulProgramy
{
    /// <summary>
    /// Interaction logic for ZobrazeniStolu.xaml
    /// </summary>
    public partial class ZobrazeniStolu : Window
    {
        private Ellipse[,] svetla;

        const int velikostPole = 100;
        const int velikostSvetla = 30;

        private Dictionary<StavPixelu, Color> barvy = new Dictionary<StavPixelu, Color>(3);

        public ZobrazeniStolu(Stul stul)
        {
            InitializeComponent();


            barvy.Add(StavPixelu.Zadny, Color.FromRgb(128, 128, 128));
            barvy.Add(StavPixelu.Cervena, Color.FromRgb(255, 0, 0));
            barvy.Add(StavPixelu.Zelena, Color.FromRgb(0, 255, 0));
            barvy.Add(StavPixelu.Zluta, Color.FromRgb(255, 255, 0));

            svetlaCanvas.Width = Stul.sirka * velikostPole;
            svetlaCanvas.Height = Stul.vyska * velikostPole;

            svetla = new Ellipse[Stul.sirka,Stul.vyska];

            for (int x = 0; x < Stul.sirka; x++)
            {
                for (int y = 0; y < Stul.vyska; y++)
                {
                    Ellipse e = new Ellipse();

                    e.Width = velikostSvetla;
                    e.Height = velikostSvetla;

                    svetlaCanvas.Children.Add(e);
                    Canvas.SetTop(e, (y * velikostPole) + ((velikostPole - velikostSvetla) / 2));
                    Canvas.SetLeft(e, (x * velikostPole) + ((velikostPole - velikostSvetla) / 2));
                    e.Fill = new SolidColorBrush(barvy[stul[x,y].Stav]);

                    svetla[x, y] = e;
                }
            }

            stul.ZmenaPixelu += ZmenaPixelu;
        }

        private void ZmenaPixelu(object sender, PixelEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                svetla[e.X, e.Y].Fill = new SolidColorBrush(barvy[e.Pixel.Stav]);
            });
        }
    }
}
