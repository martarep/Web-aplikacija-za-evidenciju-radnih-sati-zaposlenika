using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AII.Models
{
    public class Projekt
    {
        public int IDProjekt { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        public string Aktivan { get; set; }
        public int KlijentID { get; set; }
        public int VoditeljProjektaID { get; set; }
    }
}