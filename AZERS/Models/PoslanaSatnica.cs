using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AZERS.Models
{
    public class PoslanaSatnica
    {
        public int IDDjelatnik { get; set; }
        public string ImePrezime { get; set; }
        public DateTime DatumSlanja { get; set; }
        public TimeSpan VrijemeSlanja { get; set; }
        public DateTime DatumSatnice { get; set; }


    }
}