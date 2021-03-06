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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StulProgramy.Programy
{
    /// <summary>
    /// Interaction logic for NahodnePixelyZobrazeni.xaml
    /// </summary>
    public partial class NahodnePixelyZobrazeni : UserControl
    {
        private Action vygenerovatNove;

        public int PocetPixelu { get => (int)pixelySlider.Value; }
        public StavPixelu BarvaZadna { get => barvaZadnehoCbx.Stav; }
        public StavPixelu BarvaNenalezena { get => barvaNenalezenehoCbx.Stav; }
        public StavPixelu BarvaNalezena { get => barvaNalezenehoCbx.Stav; }

        public NahodnePixelyZobrazeni(Action vygenerovatNove)
        {
            InitializeComponent();
            this.vygenerovatNove = vygenerovatNove;
        }

        public void ZobrazitStav(int pocet, int nalezeno)
        {
            Dispatcher.Invoke(() =>
            {
                nalezenoTb.Text = $"{nalezeno}/{pocet}";


                progressBar.Maximum = pocet;
                progressBar.Value = nalezeno;
            });
        }

        private void VygenerovatNove(object sender, RoutedEventArgs e)
        {
            vygenerovatNove.Invoke();
        }
    }
}
