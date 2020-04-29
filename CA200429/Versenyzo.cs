using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200429
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public int Rajtszam { get; set; }
        public bool Kategoria { get; set; }
        public string VersenyIdo { get; set; }
        public double IdoOraban
        {
            get
            {
                var t = VersenyIdo.Split(':');
                return new TimeSpan(
                    int.Parse(t[0]),
                    int.Parse(t[1]),
                    int.Parse(t[2])).TotalHours;
            }
        }
        public int TavSzazalek { get; set; }

        public Versenyzo(string sor)
        {
            var t = sor.Split(';');
            Nev = t[0];
            Rajtszam = int.Parse(t[1]);
            Kategoria = t[2] == "Ferfi";
            VersenyIdo = t[3];
            TavSzazalek = int.Parse(t[4]);
        }
    }
}
