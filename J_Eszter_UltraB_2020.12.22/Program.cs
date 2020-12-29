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

            Console.ReadKey();
        }
    }
}
