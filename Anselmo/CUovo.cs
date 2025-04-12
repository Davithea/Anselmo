using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anselmo
{
    public class CUovo
    {
        public string Colore1 { get; set; }
        public string Colore2 { get; set; }
        public int Tentativi { get; set; }

        public CUovo(string colore1, string colore2)
        {
            Colore1 = colore1;
            Colore2 = colore2;
            Tentativi = 0;
        }

        public bool HaColoreInComune(CUovo altro)
        {
            return Colore1 == altro.Colore1 || Colore1 == altro.Colore2 ||
                   Colore2 == altro.Colore1 || Colore2 == altro.Colore2;
        }

        public override string ToString()
        {
            return $"{Colore1}-{Colore2} (T: {Tentativi})";
        }
    }

}
