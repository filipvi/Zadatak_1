using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
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
            Console.WriteLine("\n");
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
                string result = InputManager.CheckType(ime);

                while (result == "Int" || result == "Null")
                {
                    Console.Write("Unos imena novog studenta nije u odgovarajućem formatu, pokušajte ponovno (0 za odustajanje): ");
                    ime = Console.ReadLine();
                    result = InputManager.CheckType(ime);
                }

                if (ime == "0")
                {
                    Console.WriteLine("\n\nOdustajanje...\n\n");
                    Start();
                }

                student.Ime = ime;


                //Korisnički unos prezimena
                Console.Write("Unesite prezime novog studenta (0 za odustajanje): ");
                string prezime = Console.ReadLine();
                result = InputManager.CheckType(prezime);

                while (result == "Int" || result == "Null")
                {
                    Console.Write("Unos prezimena novog studenta nije u odgovarajućem formatu, pokušajte ponovno (0 za odustajanje): ");
                    prezime = Console.ReadLine();
                    result = InputManager.CheckType(prezime);
                }

                if (prezime == "0")
                {
                    Console.WriteLine("\n\nOdustajanje...\n\n");
                    Start();
                }

                student.Prezime = prezime;


                //Korisnički unos godine studija
                Console.Write("Unesite godinu studija novog studenta (0 za odustajanje): ");
                string godina = Console.ReadLine();
                result = InputManager.CheckType(godina);

                while (result == "String" || result == "Null")
                {
                    Console.Write("Unos godine studija novog studenta nije u odgovarajućem formatu, pokušajte ponovno (0 za odustajanje): ");
                    godina = Console.ReadLine();
                    result = InputManager.CheckType(godina);
                }

                if (godina == "0")
                {
                    Console.WriteLine("\n\nOdustajanje...\n\n");
                    Start();
                }

                student.GodinaStudija = Convert.ToInt32(godina);


                //Korisnički unos broja indeksa
                Console.Write("Unesite broj indeksa novog studenta (0 za odustajanje): ");
                string broj = Console.ReadLine();
                result = InputManager.CheckType(broj);

                while (result == "String" || result == "Null")
                {
                    Console.Write("Unos broja indeksa novog studenta nije u odgovarajućem formatu, pokušajte ponovno (0 za odustajanje): ");
                    broj = Console.ReadLine();
                    result = InputManager.CheckType(broj);
                }

                if (broj == "0")
                {
                    Console.WriteLine("\n\nOdustajanje...\n\n");
                    Start();
                }

                student.BrojIndeksa = broj;


                //Metoda u repo za kreiranje novog studenta
                bool provjera = Repository.CreateNewStudent(student);
                if (provjera)
                {
                    //Ispis uspješnosti
                    Console.WriteLine("\n\nStudent uspješno dodan sa podacima: " + student.ToString());
                    Console.WriteLine("\n\n");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\nU bazi već postoji student sa unesenim brojem indeksa\n");
                    Console.ReadLine();
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

            // Korisnički unos kojeg studenta se želi urediti
            Console.Write("\n\nUpišite broj indeksa studenta kojeg želite urediti (0 za odustajanje): ");

            //Korisnički unos
            string broj = Console.ReadLine();
            string result = InputManager.CheckType(broj);

            while (result == "String" || result == "Null")
            {
                Console.Write("Unos broja indeksa studenta nije u odgovarajućem formatu, pokušajte ponovno (0 za odustajanje): ");
                broj = Console.ReadLine();
                result = InputManager.CheckType(broj);
            }

            if (broj == "0")
            {
                Console.WriteLine("\n\nOdustajanje...\n\n");
                Start();
            }

            //Pretrazivanje liste studenata sa korisnickim unosom broja indeksa
            Student student = Repository.GetStudent(broj);

            //Provjera da li je vraćeno iz metode jednako null
            if (student == null)
            {
                Console.WriteLine("\nNije pronađen niti jedan student sa traženim brojem indeksa!\n");
                //vracamo se u glavni izbornik student managera
                UrediStudenta();
            }

            //Student u bazi je pronađen, unosimo nove podatke o studentu koje zelimo mijenjati
            Console.WriteLine("\nUnesite novo ime studenta: ");
            string ime = Console.ReadLine();
            result = InputManager.CheckType(ime);

            while (result == "Int" || result == "Null")
            {
                Console.Write("Unos imena novog studenta nije u odgovarajućem formatu, pokušajte ponovno (0 za odustajanje): ");
                ime = Console.ReadLine();
                result = InputManager.CheckType(ime);
            }

            if (ime == "0")
            {
                Console.WriteLine("\n\nOdustajanje...\n\n");
                Start();
            }

            student.Ime = ime;


            Console.WriteLine("Unesite prezime: ");
            var prezime = Console.ReadLine();
            result = InputManager.CheckType(prezime);

            while (result == "Int" || result == "Null")
            {
                Console.Write("Unos prezimena novog studenta nije u odgovarajućem formatu, pokušajte ponovno (0 za odustajanje): ");
                prezime = Console.ReadLine();
                result = InputManager.CheckType(prezime);
            }

            if (prezime == "0")
            {
                Console.WriteLine("\n\nOdustajanje...\n\n");
                Start();
            }

            student.Prezime = prezime;


            Console.WriteLine("Unesite godinu studija: ");
            var godinaStudija = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(godinaStudija))
            {
                Console.WriteLine("\nNeispravan unos, pokušajte ponovno\n");
                Console.WriteLine("\nUnesite novu godinu studija studenta: ");
                godinaStudija = Console.ReadLine();
            }

            result = InputManager.CheckType(godinaStudija);
            while (result == "String" || result == "Null")
            {
                Console.Write("Unos godine studija novog studenta nije u odgovarajućem formatu, pokušajte ponovno (0 za odustajanje): ");
                godinaStudija = Console.ReadLine();
                result = InputManager.CheckType(godinaStudija);
            }

            if (godinaStudija == "0")
            {
                Console.WriteLine("\n\nOdustajanje...\n\n");
                Start();
            }

            student.GodinaStudija = Convert.ToInt32(godinaStudija);

            //krecemo u azuriranje nasih pohranjenih podataka
            bool isEdited = Repository.UrediStudenta(student);

            if (isEdited)
            {
                //Poruka o uspješnosti
                Console.WriteLine("\nPodaci studenta uspješno uređeni, podaci o studentu su " + student.ToString());
            }
            else
            {
                Console.WriteLine("Neuspješno uređivanje podataka o studentu");
            }

            //povratak na glavni izbornik
            Start();
        }

        public static void IzbrisiStudenta()
        {
            Console.WriteLine("\n");

            //Prikaz svih studenata
            Console.WriteLine("Lista studenata iz baze: ");
            var studenti = Repository.GetStudenti();

            //Korisnicki unos
            Console.Write("\n\nUpišite broj indeksa studenta kojeg želite izbrisati: ");

            //Korisnicki odabir
            string brojIndeksa = Console.ReadLine();
            string result = InputManager.CheckType(brojIndeksa);
            while (result == "String" || result == "Null")
            {
                Console.Write("Unos broja indeksa studenta nije u odgovarajućem formatu, pokušajte ponovno (0 za odustajanje): ");
                brojIndeksa = Console.ReadLine();
                result = InputManager.CheckType(brojIndeksa);
            }

            if (brojIndeksa == "0")
            {
                Console.WriteLine("\n\nOdustajanje...\n\n");
                Start();
            }
            if (!studenti.ContainsKey(brojIndeksa))
            {
                Console.WriteLine("\nNije pronađen niti jedan student sa traženim brojem indeksa!\n");
                //vracamo se u glavni izbornik student managera
                Start();
            }

            Student student = Repository.GetStudent(brojIndeksa);

            bool isRemoved = Repository.RemoveStudent(student);
            if (isRemoved)
            {
                //Uspješno
                Console.WriteLine("\n\nUspješno je obrisan student iz baze sa podacima" + ", " + student.ToString() + "\n\n");
                //Prikaz svih studenata
                Console.WriteLine("Lista studenata iz baze: ");
                studenti = Repository.GetStudenti();

                Start();
            }
            else
            {
                //Potvrda o neuspješnosti
                Console.WriteLine("Neuspješno brisanje studenta iz baze");
            }                      

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