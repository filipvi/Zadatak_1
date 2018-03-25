using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1
{
    public class Nastavnik
    {
        public int Godine { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Sifra { get; set; }

        public override string ToString()
        {
            return "Ime nastavnika " + Ime + ", " + "prezime nastavnika " + Prezime + ", " + "godine " + Godine + "šifra nastavnika" + Sifra;
        }
    }
}
