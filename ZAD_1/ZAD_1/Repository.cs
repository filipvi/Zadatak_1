﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1
{
    public class Repository
    {
        private static Dictionary<string, Student> studenti = new Dictionary<string, Student>();
        private static Dictionary<int, Kolegij> kolegiji = new Dictionary<int, Kolegij>();
        private static Dictionary<int, Nastavnik> nastavnici = new Dictionary<int, Nastavnik>();


        public static void CreateInitialData()
        {
            studenti = new Dictionary<string, Student>()
            {
                { "123456", new Student {Ime= "Filip", Prezime= "Karnik", BrojIndeksa = "123456", GodinaStudija = 2}},
                { "678901", new Student {Ime= "Marko", Prezime= "Marković", BrojIndeksa = "678901", GodinaStudija = 4}},
                { "786423", new Student {Ime= "Jure", Prezime= "Jurić", BrojIndeksa = "786423", GodinaStudija = 1}},
            };

            nastavnici = new Dictionary<int, Nastavnik>()
            {
                {34678, new Nastavnik{Ime = "Pero", Prezime = "Perić", Godine = 34}},
                {663478, new Nastavnik{Ime = "Matija", Prezime = "Lukeško", Godine = 45}},
                {5465678, new Nastavnik{Ime = "Ivan", Prezime = "Ivanić", Godine = 41}},
            };

            kolegiji = new Dictionary<int, Kolegij>()
            {
                {34689, new Kolegij{Naziv = "Matematika", Skracenica = "MAT"}},
                {34256, new Kolegij{Naziv = "Računalstvo", Skracenica = "RAČ"}},
                {87886, new Kolegij{Naziv = "Informatika", Skracenica = "INF"}}
            };

        }

        #region Studenti

        //Dohvaćanje liste studenata
        public static Dictionary<string, Student> GetStudenti()
        {
            foreach (var student in studenti.Values)
            {
                Console.WriteLine(student.ToString());
            }
            return studenti;
        }

        //Dohvaćanje studenta po predanom broju indeksa
        public static Student GetStudent(string brojIndeksa)
        {
            if (studenti.ContainsKey(brojIndeksa))
            {
                return studenti[brojIndeksa];
            }
            //Metoda ima posao pretrazivanja i vraćanja objekta Student, ukoliko ga je pronasla vraća studenta
            return null;
        }

        //Kreiranje novog studenta
        public static bool CreateNewStudent(Student student)
        {
            if (!studenti.ContainsKey(student.BrojIndeksa))
            {
                studenti.Add(student.BrojIndeksa, student);
                return true;
            }

            return false;
        }

        public static bool UrediStudenta(Student student)
        {

            if (studenti.ContainsKey(student.BrojIndeksa))
            {
                studenti[student.BrojIndeksa] = student;
            }
            return false;
        }

        public static bool RemoveStudent(Student student)
        {           
                if (studenti.ContainsKey(student.BrojIndeksa))
                {
                    studenti.Remove(student.BrojIndeksa);
                    return true;
                }
                        
            return false;
        }

        public static bool ClearStudentsList()
        {
            //Ako u listi studenata u bazi postoje zapisi obrisi popis studenata i vrati TRUE
            if (studenti != null && studenti.Count > 0)
            {
                studenti.Clear();
                return true;
            }

            //Ako ne postoje zapisi o studentima, vrati FALSE
            return false;
        }

        #endregion


        #region Nastavnici

        public static Dictionary<int, Nastavnik> PrikaziListuNastavnika()
        {
            foreach (var nastavnik in nastavnici)
            {
                Console.WriteLine(nastavnik.ToString());
            }

            return null;
        }


        public static Nastavnik GetNastavnik(string sifra)
        {
            //pokrenuta metoda trazenja, pripremljen container za eventualno nadjenog nastavnika
            Nastavnik matchNastavnik = null;

            //kroz kolekciju nastavnika trazimo match nastavnika
            foreach (var nastavnik in nastavnici)
            {
                //if (nastavnik.Sifra == Convert.ToInt32(sifra))
                //{
                //    //uvjet trazenja zadovoljen, prekidam petljanje nakon sto trazenog nastavnika pridruzim u nas container
                //    matchNastavnik = nastavnik; //pridruzujemo nadjenog nastavnika u kontejner
                //    break;
                //}
            }
            //Metoda ima posao pretrazivanja i vraćanja objekta Nastavnik, ukoliko ga je pronasla vraća nastavnika
            return matchNastavnik;
        }

        //public static void CreateNewNastavnik(Nastavnik nastavnik)
        //{
        //    nastavnici.Add(nastavnik);
        //}

        public static void UrediNastavnika(Nastavnik nastavnik)
        {
            foreach (var nast in nastavnici)
            {
                {
                    //if (nast.Sifra.Equals(nastavnik.Sifra))
                    //{
                    //    nastavnik.Godine = nast.Godine;
                    //    nastavnik.Ime = nast.Ime;
                    //    nastavnik.Prezime = nast.Prezime;
                    //    break;
                    //}

                }
            }
        }

        public static bool RemoveNastavnik(Nastavnik nastavnik)
        {
            //Prolazimo kroz listu nastavnika u bazi
            foreach (var nast in nastavnici)
            {
                //Ako u bazi postoji nastavnik koji ima šifru jednaku prednoj šifri
                // Izbrisi tog nastavnika iz baze, i metoda vrati TRUE
                //ISTO KO I SA STUIDENTIMA
                //if (nast.Sifra == nastavnik.Sifra)
                //{
                //    nastavnici.Remove(nastavnik);
                //    return true;
                //}
            }
            //Ukoliko ne postoji student vrati FALSE
            return false;
        }

        public static bool ClearNastavniciList()
        {
            //Ako u listi nastavnika u bazi postoje zapisi obrisi popis nastavnika i vrati TRUE
            if (nastavnici != null && nastavnici.Count > 0)
            {
                nastavnici.Clear();
                return true;
            }

            //Ako ne postoje zapisi o nastavnicima, vrati FALSE
            return false;
        }
        #endregion



    }
}
