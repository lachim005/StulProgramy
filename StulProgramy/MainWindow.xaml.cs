using StulKnihovna;
using StulProgramy.Programy;
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

namespace StulProgramy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ProgramData> programy = new();
        List<Button> programButtony = new();

        ZobrazeniStolu? zs;

        IProgram? program;

        Stul? stul;

        public MainWindow()
        {
            InitializeComponent();
            NaplnitProgramy();
            ZobrazitProgramy();
        }
        private void NaplnitProgramy()
        {
            ProgramData pd;

            pd = new();
            pd.Nazev = "Náhodné pixely";
            pd.Popis = "Program vygeneruje náhodné pixely, které musí být nalezeny a označeny magnetem";
            pd.Vytvorit = (s) => new NahodnePixely(s);
            programy.Add(pd);
        }

        private void StulPripojen(object sender, EventArgs e)
        {
            pripojeniStoluDialog.Visibility = Visibility.Hidden;
            stul = pripojeniStoluDialog.stul;
            if (stul is not null)
            {
                zs = new ZobrazeniStolu(stul);
                zs.Show();
            }
            pripojeniStoluDialog.Visibility = Visibility.Hidden;
            dialogyGrid.Visibility = Visibility.Hidden;
            programyGrid.Visibility = Visibility.Visible;
        }


        #region Zobrazení, výběr a spouštění programů
        private void ZobrazitProgramy()
        {
            foreach (ProgramData prog in programy)
            {
                GroupBox gb = new();
                gb.Header = prog.Nazev;
                gb.Width = 250;
                gb.Margin = new Thickness(10);
                gb.Padding = new Thickness(5);
                gb.HorizontalAlignment = HorizontalAlignment.Left;

                StackPanel sp = new StackPanel();

                sp.Children.Add(new TextBlock() { Text = prog.Popis, TextWrapping = TextWrapping.Wrap });

                Button b = new Button() { Content = "Spustit"};
                b.Click += ProgramClick;
                programButtony.Add(b);
                b.Margin = new Thickness(5);
                sp.Children.Add(b);

                gb.Content = sp;

                programyStackpanel.Children.Add(gb);
            }
        }

        private void ProgramClick(object sender, RoutedEventArgs e)
        {
            int programIndex = -1;

            for (int i = 0; i < programButtony.Count; i++)
            {
                if (programButtony[i].Equals(sender))
                {
                    programIndex = i;
                }
            }
            if (programIndex != -1)
            {
                SpustitProgram(programy[programIndex]);
            }
        }

        private void SpustitProgram(ProgramData programData)
        {
            programyGrid.Visibility = Visibility.Hidden;
            dialogyGrid.Visibility = Visibility.Visible;
            program = programData.Vytvorit(stul);
            dialogyGrid.Children.Add(program.Zobrazeni);
        }
        #endregion
    }
}
