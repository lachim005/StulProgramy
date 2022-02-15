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
    internal interface IProgram
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
        /// Event, který se zavolá po ukončení programu a uvolnění stolu
        /// </summary>
        public event EventHandler? PriUkonceniProgramu;
        /// <summary>
        /// Ukončí program a uvolní stůl
        /// </summary>
        public void Ukoncit();
    }
}
