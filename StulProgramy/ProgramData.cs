using StulKnihovna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StulProgramy
{
    /// <summary>
    /// Třída, která obsahuje informace a programu a funkci na jeho vytvoření
    /// </summary>
    public class ProgramData
    {
        /// <summary>
        /// Název programu
        /// </summary>
        public string Nazev { get; set; }
        /// <summary>
        /// Popis programu
        /// </summary>
        public string Popis { get; set; }
        /// <summary>
        /// Funkce, která vytvoří instanci programu
        /// </summary>
        public Func<Stul, IProgram> Vytvorit { get; set; }
    }
}
