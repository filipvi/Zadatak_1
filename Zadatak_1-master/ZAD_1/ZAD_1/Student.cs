using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1
{
    public class Student
    {
        public string BrojIndeksa { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int GodinaStudija { get; set; }

        public override string ToString()
        {            
            return "Ime studenta: " + Ime + ", " + "prezime studenta: " + Prezime + ", " + "broj indeksa: " + BrojIndeksa  + ", " + "godine studenta: " + GodinaStudija;
        }
    }
}
