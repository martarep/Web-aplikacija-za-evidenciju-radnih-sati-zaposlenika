using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AII.Models
{
    public class Djelatnik
    {
        public int IDDjelatnik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime  DatumZaposlenja { get; set; }
        public int  TipDjelatnikaID { get; set; }
        public string  Lozinka { get; set; }

        public string  Aktivan { get; set; }
        public string  Jezik { get; set; }
        public int TimID { get; set; }
        public string ImePrezime { get; set; }


    }
}