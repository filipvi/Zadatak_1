using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1
{
    public class Kolegij
    {
        public string Skracenica { get; set; }
        public string Naziv { get; set; }
        public int SifraKolegija { get; set; }

        public override string ToString()
        {
            return "Naziv kolegija: " + Naziv + ", " + "skraćeni naziv kolegija: " + Skracenica + ", " + "šifra kolegija: " + SifraKolegija;
        }
    }
}
