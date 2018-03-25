using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1
{
    class Program
    {
        static void Main(string[] args)
        {            
            //generate test data
            Repository.CreateInitialData();

            DisplayMenu.Start();
            //DO PONEDJELJKA UZ ONA PITANJA ZA USMENI
            //uvest u cijeli program try/catch, sa tipiziranim exceptionom, genericki moze biti zadnji u navodjenju, 
            //rijesit sve one nedostatke
            //staticke liste promjenit u staticke dictionaries
            //pri cemu je key dictionarija, unique identifier odredjenog objekta..
            //npr: Dictionary<string, Student> studentDict; gdje je string sifraIndeksa

        }

       









       
        //public static void StudentManager()
        //{
        //    var listaStudenata = Repository.Studenti;
        //    var student = new Student();

        //    Console.WriteLine("Unesi naziv novog studenta");
        //    var naziv = Console.ReadLine();

        //    Console.WriteLine("Unesi broj indeksa novog studenta");
        //    var brojIndeksa = Console.ReadLine();

        //    student.Naziv = naziv;
        //    student.BrojIndeksa = brojIndeksa;

        //    listaStudenata.Add(student);
        //}

        ////Uređivanje dohvaćenog studenta
        //public static void StudentManager(Student student)
        //{

        //    string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Filip\Desktop\ZAD_1\ZAD_1\Studenti.txt");
        //    int index = 0;

        //    foreach (var line in lines)
        //    {
        //        index++;
        //        Console.WriteLine(index + " " + line);
        //    }

        //    Console.WriteLine("Odaberite broj indeksa studenta kojeg želite urediti: ");
        //    string input = Console.ReadLine();
        //    var listaStudenata = Repository.Studenti;
        //    string brojIndeksa = input;
        //    Student matchStudent = listaStudenata.FirstOrDefault(x => x.BrojIndeksa.Trim() == brojIndeksa);

        //    Console.WriteLine("Promijenite broj indeksa studenta: ");
        //    brojIndeksa = Console.ReadLine();
        //    Console.WriteLine("Promijenite naziv studenta: ");
        //    string naziv = Console.ReadLine();

        //    matchStudent.Naziv = naziv;
        //    matchStudent.BrojIndeksa = brojIndeksa;

        //    listaStudenata.Add(matchStudent);
        //}

        //// Brisanje studenta
        //public static void StudentManager(string brojIndeksa)
        //{
        //    var listaStudenata = Repository.Studenti;

        //    listaStudenata.RemoveAll(x => x.BrojIndeksa == brojIndeksa);
        //}

        //// Ispis studenata
        //public static List<Student> StudentManager(List<Student> studenti)
        //{
        //    var listaStudenata = Repository.Studenti;

        //    return listaStudenata;
        //}

    }
}
