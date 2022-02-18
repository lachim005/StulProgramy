using StulKnihovna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StulProgramy.Programy
{
    public class NahodnePixely : IProgram
    {
        public UserControl Zobrazeni { get; set; }
        public Stul Stul { get; set; }

        public event EventHandler? PriUkonceniProgramu;

        public bool HraJede { get; private set; }


        //Nastavení
        private int pocetPixelu;
        private StavPixelu barvaZadna;
        private StavPixelu barvaNenalezena;
        private StavPixelu barvaNalezena;

        private int[,] stavy;
        private int nalezenyPixely;

        public NahodnePixely(Stul s)
        {
            Stul = s;
            Zobrazeni = new NahodnePixelyZobrazeni(VygenerovatNove);
        }

        private void VygenerovatNove()
        {
            //Zjistí aktuální nastavení
            NahodnePixelyZobrazeni npz = Zobrazeni as NahodnePixelyZobrazeni;
            pocetPixelu = npz.PocetPixelu;
            barvaZadna = npz.BarvaZadna;
            barvaNenalezena = npz.BarvaNenalezena;
            barvaNalezena = npz.BarvaNalezena;

            //0 - žádné
            //1 - nenalezeno
            //2 - nalezeno
            stavy = new int[Stul.sirka, Stul.vyska];

            for (int x = 0; x < Stul.sirka; x++)
            {
                for (int y = 0; y < Stul.vyska; y++)
                {
                    stavy[x, y] = 0;
                }
            }

            Stul.NastavVsechnyPixely(barvaZadna);

            //Vygeneruje náhodné pixely
            Random ran = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < pocetPixelu; i++)
            {
                int dalsiX = ran.Next(Stul.sirka);
                int dalsiY = ran.Next(Stul.vyska);
                if (stavy[dalsiX, dalsiY] == 0)
                {
                    stavy[dalsiX,dalsiY] = 1;
                    Stul[dalsiX, dalsiY].Stav = barvaNenalezena;
                } else
                {
                    i--;
                }
            }

            Stul.MagnetEvent += MagnetEvent;

            nalezenyPixely = 0;
            npz.ZobrazitStav(pocetPixelu, 0);
            HraJede = true;
        }

        private void MagnetEvent(object sender, PixelEventArgs e)
        {
            //Pokud má pixel stav nenalezeno, změní na nalezeno
            if (stavy[e.X, e.Y] == 1)
            {
                stavy[e.X, e.Y] = 2;
                e.Pixel.Stav = barvaNalezena;
                nalezenyPixely++;
            }
            (Zobrazeni as NahodnePixelyZobrazeni).ZobrazitStav(pocetPixelu, nalezenyPixely);


            if (nalezenyPixely == pocetPixelu)
            {
                HraJede = false;
            }
        }

        public void Ukoncit()
        {
            HraJede = false;
            Stul.MagnetEvent -= MagnetEvent;
            PriUkonceniProgramu?.Invoke(this, EventArgs.Empty);
        }
    }
}
