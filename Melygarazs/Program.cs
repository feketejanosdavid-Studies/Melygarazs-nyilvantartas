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
                Console.WriteLine(rendszam);
                Console.ReadKey(true);
            }
        }

        static string VeletlenRendszam()
        {
            string rendszam = "";
            int melyik = (new Random()).Next(1, 3);
            switch (melyik)
            {
                case 1:
                    rendszam=Valtozat1();
                    break;
                case 2:
                    rendszam=Valtozat2();
                    break;
                case 3:
                    rendszam=Valtozat3();
                    break;
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

