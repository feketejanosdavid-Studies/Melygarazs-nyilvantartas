using Melygarazs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melygarazs
{
    internal class Program
    {
        static SzimulacioAdatbazis adatbazis;
        static Random vszg = new Random();
        static int[] valtozatok = new int[3];
        static void Main(string[] args)
        {
            adatbazis = new SzimulacioAdatbazis();
            adatbazis.Database.EnsureCreated();
            Console.Clear();
            string cim = "Parkolóház szimuláció";
            int poz = Console.WindowWidth - cim.Length / 2;
            Console.SetCursorPosition(poz, 5);
            Console.WriteLine(cim);

            while (true)
            {
                string rendszam = VeletlenRendszam();
                Auto auto = new Auto();
                auto.Rendszam = rendszam;
                adatbazis.autok.Add(auto);
                adatbazis.SaveChanges();
                Console.ReadKey(true);
            }
        }

        static string VeletlenRendszam()
        {
            string rendszam = "";
            int melyik = (new Random()).Next(1, 4);
            valtozatok[melyik - 1]++;
            switch (melyik)
            {
                case 1:
                    rendszam = Valtozat1();
                    break;
                case 2:
                    rendszam = Valtozat2();
                    break;
                case 3:
                    rendszam = Valtozat3();
                    break;

            }
            var lista = adatbazis.autok.ToList();
            foreach (var elem in lista)
            {
                if (elem.Rendszam == rendszam)
                {
                    valtozatok[melyik - 1]--;
                    break;
                }
            }
            return rendszam;
        }

        static string Valtozat1()
        {
            return "AB 12-34";

        }

        static string Valtozat2()
        {
            return "ABC 123";
        }

        static string Valtozat3()
        {
            return "AB-CD 123";
        }

    }
}

