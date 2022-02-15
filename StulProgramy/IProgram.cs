using StulKnihovna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StulProgramy
{
    /// <summary>
    /// Interface pro všechny programy na stůl
    /// </summary>
    public interface IProgram
    {
        /// <summary>
        /// Vizuální zobrazení a ovládání programu
        /// </summary>
        UserControl Zobrazeni { get; set; }
        /// <summary>
        /// Objekt pro práci se stolem
        /// </summary>
        Stul Stul { get; set; }
        /// <summary>
        /// Název programu
        /// </summary>
        public string Nazev { get; set; }
        /// <summary>
        /// Popis programu
        /// </summary>
        public string Popis { get; set; }
        /// <summary>
        /// Event, který se zavolá po ukončení programu a uvolnění stolu
        /// </summary>
        public event EventHandler PriUkonceniProgramu;
        /// <summary>
        /// Ukončí program a uvolní stůl
        /// </summary>
        public void Ukoncit();
    }
}
