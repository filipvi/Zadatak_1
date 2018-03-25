using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1
{
    class DisplayMenu
    {
        public static void Start()
        {
            Console.WriteLine("1. Studenti");
            Console.WriteLine("2. Kolegiji");
            Console.WriteLine("3. Nastavnici");
            Console.WriteLine("4. Izlaz");

            Console.Write("\n\nUnesite vaš odabir: ");

            string result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    Console.WriteLine("\nStudenti\n");
                    StudentManager.Start();
                    break;
                case "2":
                    Console.WriteLine("\nKolegiji\n");
                    KolegijManager.Start();
                    break;
                case "3":
                    Console.WriteLine("\nNastavnici\n");
                    NastavnikManager.Start();
                    break;
                case "4":
                    Console.WriteLine("\nIzlazak iz programa...");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nNiste unijeli valjani broj!\n");
                    Start();
                    break;
            }
        }
    }
}
