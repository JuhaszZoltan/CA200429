using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200429
{
    class Program
    {
        private static List<Versenyzo> _versenyzok;
        private static void Main()
        {

            F02();
            F03();
            F04();
            F05();
            F07();
            F08();
            Console.ReadKey();
        }

        private static void F08()
        {
            Console.Write("8. feladat: ");
            Console.WriteLine("verseny győztesei");

            var n = Gyoztes(false);
            Console.WriteLine("\tNők: {0} ({1}.) - {2}", n.Nev, n.Rajtszam, n.VersenyIdo);
            var f = Gyoztes(true);
            Console.WriteLine("\tFérfiak: {0} ({1}.) - {2}", f.Nev, f.Rajtszam, f.VersenyIdo);
        }

        private static Versenyzo Gyoztes(bool kategoria)
        {
            Versenyzo gyoztes = null;
            foreach (var v in _versenyzok)
            {
                if(kategoria == v.Kategoria && v.TavSzazalek == 100)
                {
                    if (gyoztes is null) gyoztes = v;
                    else if (v.IdoOraban < gyoztes.IdoOraban) gyoztes = v;
                }
            }
            return gyoztes;
        }

        private static void F07()
        {
            Console.Write("7. feladat: ");
            var sum = .0;
            var c = 0;
            foreach (var v in _versenyzok)
                if (v.Kategoria && v.TavSzazalek == 100)
                {
                    c++;
                    sum += v.IdoOraban;
                }
            Console.WriteLine($"Átlagos idő: {sum / c} óra");
        }

        private static void F05()
        {
            Console.Write("5. feladat: ");
            Console.Write("kérem a sportoló nevét: ");
            var nev = Console.ReadLine();
            int i = 0;
            while (i < _versenyzok.Count && _versenyzok[i].Nev != nev) i++;
            Console.Write("\tIndult egyéniben a sportoló? ");
            if (i < _versenyzok.Count)
            {
                Console.WriteLine("IGEN");

                Console.WriteLine($"\tTeljesítette a teljes távot? " +
                    $"{(_versenyzok[i].TavSzazalek == 100 ? "IGEN" : "NEM")}");
            }
            else Console.WriteLine("NEM");

            #region "Elvis" operátor ?:
            /*
            [feltétel] ? [eredmény, ha a feltétel IGAZ] : [eredmény, ha a feltétel hamis];
            ===
            if ([feltétel]) [eredmény, ha a feltétel IGAZ]
            else [eredmény, ha a feltétel hamis] 

            string r = x > 10 ? "nagyobb" : "nem nagyobb";
            */
            #endregion
        }

        private static void F04()
        {
            Console.Write("4. feladat: ");
            int c = 0;
            foreach (var v in _versenyzok)
                if (!v.Kategoria && v.TavSzazalek == 100) c++;
            Console.WriteLine($"Célba érkező női sportolók: {c} fő");
        }

        private static void F03()
        {
            Console.Write("3. feladat: ");
            Console.WriteLine($"Egyéni indulók: {_versenyzok.Count} fő");
        }

        private static void F02()
        {
            _versenyzok = new List<Versenyzo>();
            var sr = new StreamReader(@"..\..\res\ub2017egyeni.txt", Encoding.UTF8);
            sr.ReadLine(); //--eldobom a felesleges "fejléc" sort
            while (!sr.EndOfStream)
                _versenyzok.Add(new Versenyzo(sr.ReadLine()));
            sr.Close();

        }
    }
}
