using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1
{
    class KolegijManager
    {
        public static void Start()
        {
            Console.WriteLine("a) Novi kolegij");
            Console.WriteLine("b) Uredi kolegij");
            Console.WriteLine("c) Obriši kolegij");
            Console.WriteLine("d) Izbriši popis kolegija");
            Console.WriteLine("e) Povratak");

            Console.Write("\n\nUnesite vaš odabir: ");
            string odabir = Console.ReadLine();

            switch (odabir)
            {
                case "a":
                    NoviKolegij();
                    break;
                case "b":
                    UrediKolegij();
                    break;
                case "c":
                    IzbrisiKolegij();
                    break;
                case "d":
                    IzbrisiPopisKolegija();
                    break;
                case "e":
                    DisplayMenu.Start();
                    break;
                default:
                    Start();
                    break;
            }
        }

        private static void IzbrisiPopisKolegija()
        {
            //List<Kolegij> listaKolegija = Repository.GetKolegiji();
            //listaKolegija.Clear();
            //Console.WriteLine("\n\nLista kolegija uspješno uklonjena");
            //Console.WriteLine("\n\n");

            //DisplayMenu.Start();
        }

        private static void IzbrisiKolegij()
        {
            //Kolegij kolegij = new Kolegij();
            //List<Kolegij> listaKolegija = Repository.GetKolegiji();
            //foreach (var jedanKolegij in listaKolegija)
            //{          
            //    Console.WriteLine(jedanKolegij.Naziv);
            //}
            //Console.Write("\n\nUpišite naziv kolegija kojeg želite izbrisati: ");
            //string odabir = Console.ReadLine().ToLower();

            //kolegij= listaKolegija.FirstOrDefault(x => x.Naziv.ToLower() == odabir);

            //if (kolegij == null)
            //{
            //    Console.WriteLine("Ne postoji kolegij sa nazivom: " + odabir);
            //    Console.WriteLine("\n\n");
            //    Start();
            //}

            //listaKolegija.Remove(kolegij);
            //Console.WriteLine("\n\n Kolegij uspješno izbrisan");
            //Console.WriteLine("\n\n");

            //DisplayMenu.Start();
        }

        private static void UrediKolegij()
        {
            //Kolegij kolegij = new Kolegij();
            //List<Kolegij> listaKolegija = Repository.GetKolegiji();

            //foreach (var jedanKolegij in listaKolegija)
            //{          
            //    Console.WriteLine(jedanKolegij.Skracenica);
            //}
            
            //Console.Write("\n\nUpišite skraćenicu kolegija kojeg želite urediti: ");
            //string odabir = Console.ReadLine().ToLower();

            //kolegij = listaKolegija.FirstOrDefault(x => x.Skracenica.ToLower() == odabir);

            //if (kolegij== null)
            //{
            //    Console.WriteLine("\n\nNe postoji kolegij sa skraćenicom: " + odabir);
            //    Console.WriteLine("\n\n");
            //    Start();
            //}
           
            //Console.Write("\n\nPromijenite naziv kolegija: ");
            //var naziv = Console.ReadLine();
            //Console.Write("Promijenite skraćenicu kolegija: ");
            //var skracenica = Console.ReadLine();

            //kolegij.Skracenica = skracenica;
            //kolegij.Naziv = naziv;
            //Console.WriteLine("\n\n Kolegij uspješno ažuriran");
            //Console.WriteLine("\n\n");

            //DisplayMenu.Start();
        }

        private static void NoviKolegij()
        {
            Kolegij kolegij = new Kolegij();
            //List<Kolegij> listaKolegija = Repository.GetKolegiji();

            Console.Write("\n\nUnesite skraćenicu novog kolegija: ");
            var skracenica = Console.ReadLine();
            Console.Write("Unesi naziv novog kolegija: ");
            var naziv= Console.ReadLine();

            kolegij.Skracenica = skracenica;
            kolegij.Naziv= naziv;

            //listaKolegija.Add(kolegij);
            Console.WriteLine("\n\nKolegij uspješno dodan sa podacima: " + " " + "Skraćenica kolegija: " + skracenica + " " + " i nazivom kolegija: " + naziv);
            Console.WriteLine("\n\n");
            DisplayMenu.Start();
        }
    }
}
