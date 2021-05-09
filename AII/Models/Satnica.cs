using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AII.Models
{
    public class Satnica
    {
        public int IDSatnica { get; set; }
        public int BrojRedovnihSati { get; set; }
        public int BrojPrekovremenihSati { get; set; }
        public DateTime DatumSatnice{ get; set; }
        public DateTime DatumSlanja{ get; set; }
        public string Status { get; set; }
        public int DjelatnikID { get; set; }
        public int ProjektID { get; set; }
        public int KlijentID { get; set; }
        public int TimID { get; set; }
    }
}