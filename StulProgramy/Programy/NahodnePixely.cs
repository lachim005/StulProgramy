using StulKnihovna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StulProgramy.Programy
{
    internal class NahodnePixely : IProgram
    {
        public UserControl Zobrazeni { get; set; }
        public Stul Stul { get; set; }
        public string Nazev { get; set; } = "Náhodné pixely";
        public string Popis { get; set; } = "Program rozsvítí náhodné pixely vybranou barvou a změní ji, detekuje-li pixel magnet";

        public event EventHandler? PriUkonceniProgramu;

        public NahodnePixely(Stul s)
        {
            Stul = s;
            Zobrazeni = new NahodnePixelyZobrazeni();
        }


        public void Ukoncit()
        {
            throw new NotImplementedException();
        }
    }
}
