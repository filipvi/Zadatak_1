using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1
{
    class NastavnikManager
    {
        public static void Start()
        {
            Console.WriteLine("a) Novi nastavnik");
            Console.WriteLine("b) Uredi nastavnika");
            Console.WriteLine("c) Obriši nastavnika");
            Console.WriteLine("d) Izbriši popis nastavnika");
            Console.WriteLine("e) Povratak");

            Console.Write("\n\nUnesite vaš odabir: ");
            string odabir = Console.ReadLine();

            switch (odabir)
            {
                case "a":
                    NoviNastavnik();
                    break;
                case "b":
                    UrediNastavnika();
                    break;
                case "c":
                    IzbrisiNastavnika();
                    break;
                case "d":
                    IzbrisiPopisNastavnika();
                    break;
                case "e":
                    DisplayMenu.Start();
                    break;
                default:
                    Start();
                    break;
            }

        }

        private static void NoviNastavnik()
        {
            //Deklaracija novog nastavnika
            Nastavnik nastavnik = new Nastavnik();

            //Korisnicki unos
            Console.Write("\n\nUnesite ime novog nastavnika: ");
            var ime = Console.ReadLine();
            Console.Write("Unesite prezime novog nastavnika: ");
            var prezime = Console.ReadLine();

            Console.Write("Unesi godine novog nastavnika: ");
            string godine = Console.ReadLine();
            //zakaj je -1?
            // Takav sam primjer nasao 
            // to je inicijalno samo valjda
            //int a;
            //kolika je vrijednost a?
            // nnull
            //25 sklekova za ovu glupost primitivnih carijabli
            //c# variable types
            //ili otvoris knjig koju sam ti dal, na 7oj stranici su varijable
            //pricali smo MILIJUN puta koje su osnivne vriejdnosti varijabli
            //koja je vrijednost: string a;
            // "", prazan string
            //znaci dok nest ne unesemo na formu, i to stavimo na spremanje u bazu, spremamop ujek prazan string?
            // ipak je null onda 
            //ako nije musko, onda je zensko
            //double a;
            //vrijednost?
            //0
            //Student a;
            //a.Godina? vrijednost 0
            //unhandled null reference exception
            //50

            //kako smo mogli unejt dva ista nastavnika po unique identifieru?
            // Kad svaki put napunimo u repository 
            // I kad krenemo ponovno poniste se vrijednostist
          //kuzim sta zelis reci
            //nismo krenuli ponovno
            //gledaj i objasni mi ovo
            // Nisam napravio provjeru za to, da ako u listi nastavnika postoji vec sa takvom sifrom , da ne dopusti onda izradu opet istog

            //znaci, to se ne smije desavat, nemamo nigdje popis kreiranih studenata, i ostalih kolekcija
            //da sad ne cjepidlacimo, na uredi nemas provjeru za godine, da li je broj
            //sifra studenta je broj ili slova
        // string sam stavio, jer moze otici i preko vrijednosti inta
            //na sifru nastavnika sam mislil
            //string sam stavio

            int num = -1;

            //bravo za ovo
            while (!int.TryParse(godine, out num))
            {
                Console.WriteLine("\nNiste unijeli odgovarajući broj za godine\n");
                Console.Write("Unesi godine novog nastavnika: ");
                godine = Console.ReadLine();
            }

            Console.Write("Unesi šifru novog nastavnika: ");
            string sifra = Console.ReadLine();
            int num1 = -1;
            while (!int.TryParse(sifra, out num))
            {
                Console.WriteLine("\nNiste unijeli odgovarajući šifru nastavnika\n");
                Console.Write("Unesi šifru novog nastavnika: ");
                sifra = Console.ReadLine();
            }

            //Dodjeljivanje korisničkog unosa varijabli nastavnik
            nastavnik.Ime = ime;
            nastavnik.Prezime = prezime;
            nastavnik.Godine = Convert.ToInt32(godine);
            nastavnik.Sifra = Convert.ToInt32(sifra);

            //Metoda u repo za kreiranje novog nastavnika koja prima lokalnu varijablu nastavnik
            //Repository.CreateNewNastavnik(nastavnik);

            //Ispis uspješnosti
            Console.WriteLine("\n\nNastavnik uspješno dodan sa podacima: " + nastavnik.ToString());
            Console.WriteLine("\n\n");

            Start();
        }

        private static void UrediNastavnika()
        {
            // Korisnički unos kojeg nastavnika se želi urediti
            Console.Write("\n\nUpišite šifru nastavnika kojeg želite urediti (0 za odustajanje): ");

            //Korisnički unos
            string sifra = Console.ReadLine();

            if (sifra?.Trim() == "0")
            {
                Console.WriteLine("\n\nOdustajanje");
                Start();
            }

            // Provjera da li je unesena šifra nastavnika
            if (string.IsNullOrWhiteSpace(sifra))
            {
                Console.WriteLine("\nNeispravan unos, pokušajte ponovno\n");
                //Vraćamo korisnika na ponovni unos za uredivanje nastavnika 
                UrediNastavnika();
            }

            //Pretrazivanje liste nastavnika sa korisnickim unosom šifre
            Nastavnik nastavnik = Repository.GetNastavnik(sifra);

            //Provjera da li je vraćeno iz metode jednako null
            if (nastavnik == null)
            {
                Console.WriteLine("\nNije pronađen niti jedan nastavnik sa traženom šifrom!\n");
                //vracamo se u glavni izbornik nastavnik managera
                Start();
            }

            //Nastavnik u bazi je pronađen, unosimo nove podatke o nastavniku koje zelimo mijenjati
            Console.WriteLine("\nUnesite ime: ");
            var ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime: ");
            var prezime = Console.ReadLine();
            Console.WriteLine("Unesite godine nastavnika: ");
            var godine = Convert.ToInt32(Console.ReadLine());

            nastavnik.Godine = godine;
            nastavnik.Ime = ime;
            nastavnik.Prezime = prezime;
            nastavnik.Sifra = nastavnik.Sifra;

            //krecemo u azuriranje nasih pohranjenih podataka
            Repository.UrediNastavnika(nastavnik);

            //Poruka o uspješnosti
            Console.WriteLine("\nPodaci nastavnika uspješno uređeni, podaci o nastavniku sa šifrom " + nastavnik.Sifra + ", su: " + nastavnik.ToString(), "\n\n");

            //povratak na glavni izbornik
            Start();
        }

        private static void IzbrisiNastavnika()
        {
            //Korisnicki unos
            Console.Write("\n\nUpišite šifru nastavnika kojeg želite izbrisati: ");

            //Korisnicki odabir
            string sifra = Console.ReadLine()?.ToLower();

            //Pretrazivanje baze da li postoji nastavnik sa predanim brojem indeksa
            Nastavnik nastavnik = Repository.GetNastavnik(sifra);

            //Provjera da li je vraćeno iz metode jednako null
            if (sifra == null)
            {
                Console.WriteLine("\nNije pronađen niti jedan nastavnik sa traženom šifrom!\n");
                //vracamo se u glavni izbornik nastavnik managera
                Start();
            }

            //Nastavnik je pronađen, redirect u repo na boolean metodu za brisanje nastavnika
            Repository.RemoveNastavnik(nastavnik);

            if (Repository.RemoveNastavnik(nastavnik) == false)
            {
                //Neuspjesnost
                Console.WriteLine("U bazi nije pronađen traženi nastavnik.");
                Start();
            }

            //Potvrda o uspjesnosti
            Console.WriteLine("\n\nUspješno je obrisan nastavnik iz baze sa podacima" + ", " + nastavnik.ToString());

            //Pokretanje izbornika za nastavnike
            Start();
        }

        private static void IzbrisiPopisNastavnika()
        {
            Repository.ClearNastavniciList();

            if (Repository.ClearStudentsList())
            {
                Console.WriteLine("\n\nLista nastavnika uspješno uklonjena");
            }
            else
            {
                Console.WriteLine("Nije pronađena lista nastavnika u bazi");
            }

            Start();
        }

    }
}
