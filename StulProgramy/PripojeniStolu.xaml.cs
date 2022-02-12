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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using StulKnihovna;

namespace StulProgramy
{
    /// <summary>
    /// Interaction logic for PripojeniStolu.xaml
    /// </summary>
    public partial class PripojeniStolu : UserControl
    {
        string[] porty;

        public Stul? stul;
        public event EventHandler StulPripojen;

        public PripojeniStolu()
        {
            InitializeComponent();

            ZobrazitPorty();
        }

        private void ZobrazitPorty()
        {
            //Přidá možnosti s porty
            porty = SerialPort.GetPortNames();
            portyLb.Items.Clear();
            foreach (string portName in porty)
            {
                ListBoxItem lbi = new();
                lbi.Content = portName;
                lbi.MouseDoubleClick += Vybrat;
                portyLb.Items.Add(lbi);
            }

        }

        private void Vybrat(object sender, EventArgs e)
        {
            string port = porty[portyLb.SelectedIndex];
            //Připojí stůl, pokud to jde
            try
            {
                stul = new(port, 5000);
                StulPripojen?.Invoke(this, EventArgs.Empty);
            } catch (Exception ex)
            {
                if (ex is TimeoutException)
                {
                    MessageBox.Show("Čas vypršel", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                stul = null;
            }

        }

        private void Obnovit(object sender, RoutedEventArgs e)
        {
            ZobrazitPorty();
        }
    }
}
