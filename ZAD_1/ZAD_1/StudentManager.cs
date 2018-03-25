using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ZAD_1.Helper;

namespace ZAD_1
{
    public class StudentManager
    {
        public static void Start()
        {
            Console.WriteLine("a) Novi student");
            Console.WriteLine("b) Uredi studenta");
            Console.WriteLine("c) Obriši studenta");
            Console.WriteLine("d) Izbriši popis studenata");
            Console.WriteLine("e) Povratak");

            Console.Write("\n\nUnesite vaš odabir: ");
            string odabir = Console.ReadLine();


            switch (odabir)
            {
                case "a":
                    NoviStudent();
                    break;
                case "b":
                    UrediStudenta();
                    break;
                case "c":
                    IzbrisiStudenta();
                    break;
                case "d":
                    IzbrisiPopisStudenata();
                    break;
                case "e":
                    DisplayMenu.Start();
                    break;
                default:
                    Start();
                    break;
            }
        }


        public static void NoviStudent()
        {
            Console.WriteLine("\n");

            try
            {
                //Deklaracija novog studenta
                Student student = new Student();

                //Korisnički unos imena
                Console.Write("Unesite ime novog studenta (0 za odustajanje): ");
                string ime = Console.ReadLine();
                var inputResult = InputManager.CheckType(ime.Trim());

                // NIJE DOBRO
                while (inputResult == "null")
                {
                    Console.WriteLine("\nUnos imena novog studenta je obavezan");
                    Console.Write("Unesite ime novog studenta (0 za odustajanje): ");
                    ime = Console.ReadLine();
                }

                while (inputResult == "0")
                {
                    Console.WriteLine("\nOdustajanje...\n\n");
                    Start();
                }               
                while (inputResult == "string")
                {
                    student.Ime = ime;
                }

                while (inputResult == "int")
                {
                    Console.WriteLine("\nUnesite pravilno ime novog studenta: \n");
                    ime = Console.ReadLine();
                    inputResult = InputManager.CheckType(ime.Trim());
                }

                //Korisnički unos prezimena
                Console.Write("Unesite prezime novog studenta (0 za odustajanje): ");
                string prezime = Console.ReadLine();
                inputResult = InputManager.CheckType(prezime.Trim());

                if (inputResult == "null")
                {
                    Console.WriteLine("\nUnos prezimena novog studenta je obavezno");
                    Start();
                }
                else if (inputResult == "0")
                {
                    Console.WriteLine("\nOdustajanje...\n\n");
                    Start();
                }               
                else if (inputResult == "string")
                {
                    student.Prezime = prezime.Trim();

                }
                while (inputResult == "int")
                {
                    Console.WriteLine("\nUnesite pravilno prezime novog studenta: \n");
                    prezime = Console.ReadLine();
                    inputResult = InputManager.CheckType(prezime.Trim());
                }

                //Korisnički unos broja indeksa
                Console.Write("Unesi broj indeksa novog studenta (0 za odustajanje): ");
                string brojIndeksa = Console.ReadLine();
                inputResult = InputManager.CheckType(brojIndeksa.Trim());

                if (inputResult == "null")
                {
                    Console.WriteLine("\nUnos broja indeksa novog studenta je obavezno");
                    Console.Write("Unesi broj indeksa novog studenta (0 za odustajanje): ");
                    brojIndeksa = Console.ReadLine();
                    inputResult = InputManager.CheckType(brojIndeksa.Trim());
                }
                else if (inputResult == "0")
                {
                    Console.WriteLine("\nOdustajanje...\n\n");
                    Start();
                }               
                else if (inputResult == "string" || inputResult == "int")
                {
                    student.BrojIndeksa = brojIndeksa;
                }               

                //Korisnicki unos godine studija
                Console.Write("Unesi godinu studija novog studenta (0 za odustajanje): ");
                string godinaStudija = Console.ReadLine();
                inputResult = InputManager.CheckType(godinaStudija);

                if (inputResult == "null")
                {
                    Console.WriteLine("\nUnos godine studija novog studenta je obavezno");
                    Start();
                }
                else if (inputResult == "0")
                {
                    Console.WriteLine("\nOdustajanje...\n\n");
                    Start();
                }                              
                else if (inputResult == "int")
                {
                    student.GodinaStudija = Convert.ToInt32(godinaStudija);
                }
                while (inputResult == "string")
                {
                    Console.WriteLine("\nUnesite pravilno godinu studija novog studenta: \n");
                    godinaStudija = Console.ReadLine();
                    inputResult = InputManager.CheckType(godinaStudija);
                }   

                //Metoda u repo za kreiranje novog studenta koja prima lokalnu varijablu student
                var result = Repository.CreateNewStudent(student);
                if (result)
                {
                    //Ispis uspješnosti
                    Console.WriteLine("\n\nStudent uspješno dodan sa podacima: " + student.ToString());
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.WriteLine("\nU bazi već postoji student sa istim brojem indeksa\n");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            //Pokretanje metode za ispis podataka o unesenom studentu
            Start();
        }

        public static void UrediStudenta()
        {
            Console.WriteLine("\n");

            //Ispis svih studanata u bazi
            var studenti = Repository.GetStudenti();
            //Console.WriteLine("\n" + studenti +"\n");
            //Console.WriteLine(Repository.PrikaziStudente());

            // Korisnički unos kojeg studenta se želi urediti
            Console.Write("\n\nUpišite broj indeksa studenta kojeg želite urediti (0 za odustajanje): ");

            //Korisnički unos
            string brojIndeksa = Console.ReadLine();

            if (brojIndeksa == "0")
            {
                Console.WriteLine("\n\nOdustajanje");
                Start();
            }

            // Provjera da li je unesen broj indeksa
            if (string.IsNullOrWhiteSpace(brojIndeksa))
            {
                Console.WriteLine("\nNeispravan unos, pokušajte ponovno\n");
                //Vraćamo korisnika na ponovni unos za uredivanje studenta 
                UrediStudenta();
            }

            //Pretrazivanje liste studenata sa korisnickim unosom broja indeksa
            Student student = Repository.GetStudent(brojIndeksa);

            //Provjera da li je vraćeno iz metode jednako null
            if (student == null)
            {
                Console.WriteLine("\nNije pronađen niti jedan student sa traženim brojem indeksa!\n");
                //vracamo se u glavni izbornik student managera
                Start();
            }

            //Student u bazi je pronađen, unosimo nove podatke o studentu koje zelimo mijenjati
            Console.WriteLine("\nUnesite novo ime studenta: ");
            var ime = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(ime))
            {
                Console.WriteLine("\nNeispravan unos, pokušajte ponovno\n");
                Console.WriteLine("\nUnesite novo ime studenta: ");
                ime = Console.ReadLine();
            }
            student.Ime = ime;

            Console.WriteLine("Unesite prezime: ");
            var prezime = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(prezime))
            {
                Console.WriteLine("\nNeispravan unos, pokušajte ponovno\n");
                Console.WriteLine("\nUnesite novo prezime studenta: ");
                prezime = Console.ReadLine();
            }
            student.Prezime = prezime;

            Console.WriteLine("Unesite godinu studija: ");
            var godinaStudija = Convert.ToInt32(Console.ReadLine());

            while (godinaStudija == null)
                student.GodinaStudija = godinaStudija;


            //krecemo u azuriranje nasih pohranjenih podataka
            Repository.UrediStudenta(student);

            //Poruka o uspješnosti
            Console.WriteLine("\nPodaci studenta uspješno uređeni, podaci o studentu sa brojem indeksa " + student.BrojIndeksa + ", su " + student.ToString());

            Console.WriteLine("\nNova lista studenata: ");
            //Console.WriteLine(Repository.PrikaziStudente());

            //povratak na glavni izbornik
            Start();
        }

        public static void IzbrisiStudenta()
        {
            Console.WriteLine("\n");

            //Prikaz svih studenata
            var studenti = Repository.GetStudenti();
            Console.WriteLine("\n" + studenti +"\n");
            //Korisnicki unos
            Console.Write("\n\nUpišite broj indeksa studenta kojeg želite izbrisati: ");

            //Korisnicki odabir
            string brojIndeksa = Console.ReadLine()?.ToLower();

            //Pretrazivanje baze da li postoji student sa predanim brojem indeksa

            //objasni mi sljedecu logiku: korisniik unese identifier studenta kiojeg zeli brisati
            //ti odes u bazu, pretrazis 10000 studenata ekonomije i dohvatis jednog
            //tog istog studenta onda saljes na brisanje
            //kaj tu ne valja?
            // Dulpi odlazak u bazu, dva šamara (20 sklekova)-10 za tocan odgovoro barem
            //radi bahatosti 30
            //da si znal tocan odgovor ne bi napravil ovu glupost
            //ISPRAVITI
            Student student = Repository.GetStudent(brojIndeksa);

            //Provjera da li je vraćeno iz metode jednako null
            if (student == null)
            {
                Console.WriteLine("\nNije pronađen niti jedan student sa traženim brojem indeksa!\n");
                //vracamo se u glavni izbornik student managera
                Start();
            }

            //Student je pronađen, redirect u repo na boolean metodu za brisanje studenta
            Repository.RemoveStudent(student);

            if (Repository.RemoveStudent(student) == false)
            {
                //Neuspjesnost
                Console.WriteLine("U bazi nije pronađen student.");
                Start();
            }

            //Potvrda o uspjesnosti
            Console.WriteLine("\n\nUspješno je obrisan student iz baze sa podacima" + ", " + student.ToString());

            //Pokretanje izbornika za studente
            Start();
        }

        public static void IzbrisiPopisStudenata()
        {
            Console.WriteLine("\n");

            

            if (Repository.ClearStudentsList())
            {
                Console.WriteLine("\n\nLista studenata uspješno uklonjena");
            }
            else
            {
                Console.WriteLine("Nije pronađena lista studenata u bazi");
            }

            Start();

        }

    }
}
