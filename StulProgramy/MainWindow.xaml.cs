using StulKnihovna;
using StulProgramy.Programy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StulProgramy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ProgramData> programy = new();

        ZobrazeniStolu? zs;

        IProgram? program;

        Stul? stul;

        public MainWindow()
        {
            InitializeComponent();
            NaplnitProgramy();
            programyIc.ItemsSource = programy;
        }
        private void NaplnitProgramy()
        {
            ProgramData pd;

            pd = new();
            pd.Nazev = "Náhodné pixely";
            pd.Obrazek = "NahodnePixelyIkona.png";
            pd.Popis = "Program vygeneruje náhodné pixely, které musí být nalezeny a označeny magnetem";
            pd.Vytvorit = (s) => new NahodnePixely(s);
            programy.Add(pd);
        }

        private void StulPripojen(object sender, EventArgs e)
        {
            pripojeniStoluDialog.Visibility = Visibility.Hidden;
            stul = pripojeniStoluDialog.stul;
            pripojeniStoluDialog.Visibility = Visibility.Hidden;
            dialogyGrid.Visibility = Visibility.Hidden;
            programyGrid.Visibility = Visibility.Visible;
            sbZobrazitStulBtn.IsEnabled = true;
        }


        #region Zobrazení, výběr a spouštění programů
        private void ProgramClick(object sender, RoutedEventArgs e)
        {
            Button? b = sender as Button;
            if (b is not null)
            {
                //Spustí program s názvem, jaký ma Tag tlačítka
                SpustitProgram(programy.First((pd) => pd.Nazev == (string)b.Tag));
            }
        }

        private void SpustitProgram(ProgramData programData)
        {
            if (stul is not null)
            {
                stul.NastavVsechnyPixely(StavPixelu.Zadny);
                programyGrid.Visibility = Visibility.Hidden;
                dialogyGrid.Visibility = Visibility.Visible;
                program = programData.Vytvorit(stul);
                dialogyGrid.Children.Add(program.Zobrazeni);
                sbUkoncitProgramBtn.IsEnabled = true;
                sbNazevProgramu.Text = programData.Nazev;
            }
        }
        #endregion

        private void WindowClosed(object sender, EventArgs e)
        {
            program?.Ukoncit();
            zs?.Close();
            stul?.Dispose();
        }

        private void UkoncitProgram(object sender, RoutedEventArgs e)
        {
            if (program is null)
            {
                return;
            }
            program.Ukoncit();
            programyGrid.Visibility = Visibility.Visible;
            dialogyGrid.Visibility = Visibility.Hidden;
            dialogyGrid.Children.Remove(program.Zobrazeni);
            program = null;
            sbNazevProgramu.Text = "Žádný program";
            sbUkoncitProgramBtn.IsEnabled = false;
        }

        private void ZobrazitStul(object sender, RoutedEventArgs e)
        {
            if (zs is null)
            {
                if (stul is null)
                {
                    return;
                }
            }
            else if (zs.IsVisible)
            {
                return;
            }
            zs = new ZobrazeniStolu(stul);
            zs.Show();
        }
    }
}
