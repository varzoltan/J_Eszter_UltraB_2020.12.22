using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace J_Eszter_UltraB_2020._12._22
{
    class Program
    {
        struct Adat
        {
            public string nev;
            public int rajtszam;
            public string kategoria;
            public string ido;
            public int tavszazalek;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[500];
            
            StreamReader beolvas = new StreamReader(@"E:\OneDrive - Kisvárdai SZC Móricz Zsigmond Szakgimnáziuma és Szakközépiskolája\Oktatas\Programozas\Jakab_Acs_Eszter\Erettsegi_feladatok\2019_maj_Ultrabalaton\ub2017egyeni.txt");
            string nemKell = beolvas.ReadLine();
            int n = 0;
            while (!beolvas.EndOfStream)
            {
                string sor = beolvas.ReadLine();
                string[] db = sor.Split(';');
                adatok[n].nev = db[0];
                adatok[n].rajtszam = int.Parse(db[1]);
                adatok[n].kategoria = db[2];
                adatok[n].ido = db[3];
                adatok[n].tavszazalek = int.Parse(db[4]);
                n++;
            }
            beolvas.Close();
            Console.WriteLine($"2. feladat: Beolvasás kész!");

            //3.feladat
            Console.WriteLine($"3. feladat: Egyéni indulók: {n} fő");

            //4.feladat
            int noi_sportolo = 0;          
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].kategoria == "Noi" && adatok[i].tavszazalek == 100)
                {
                    noi_sportolo++;
                }
            }
            Console.WriteLine($"4.feladat: Célba érkező női sportolók: {noi_sportolo} fő");

            //5.feladat
            Console.Write("5. feladat: Kérem adja meg az induló nevét!: ");
            string indulo = Console.ReadLine();
            bool volt = false;
            for (int i = 0; i<n; i++)
            {
                if (indulo == adatok[i].nev)
                {
                    volt = true;
                    Console.WriteLine("\tIndult egyéniben a sportoló? Igen");
                    if (adatok[i].tavszazalek == 100)
                    {
                        Console.WriteLine("\tTeljesítette a távot? Igen");
                    }
                    else
                    {
                        Console.WriteLine("\tTeljesítette a távot? Nem");
                    }
                }
            }
            if (!volt)
            {
                Console.WriteLine($"Nincs ilyen induló.");
            }

            //7.feladat
            int szamlalo = 0;
            double idoosszeg = 0;
            for (int i = 0; i<n; i++)
            {
                if (adatok[i].kategoria == "Ferfi" && adatok[i].tavszazalek == 100)
                {
                     idoosszeg += IdőÓrában(adatok[i].ido);
                    szamlalo++;
                }
            }
            Console.WriteLine($"7. feladat: Átlagos idő: {idoosszeg/szamlalo} óra");
            Console.ReadKey();
        }

        //6.feladat
        static double IdőÓrában(string ora)
        {
            string[] db = ora.Split(':');

            return int.Parse(db[0]) + (double) int.Parse(db[1]) / 60 + (double) int.Parse(db[2]) / 3600;
        }
    }
}
