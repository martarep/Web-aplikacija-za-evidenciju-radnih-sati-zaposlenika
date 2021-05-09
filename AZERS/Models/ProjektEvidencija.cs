using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AZERS.Models
{
    public class ProjektEvidencija
    {
        public int IDProjekt { get; set; }
        public string NazivProjekta { get; set; }
        public TimeSpan BrojZabiljezenihSati { get; set; }
        public TimeSpan BrojRedovnihSati { get; set; }
        public TimeSpan BrojPrekovremenihSati { get; set; }
        public TimeSpan StartVrijeme { get; set; }
        public TimeSpan StopVrijeme { get; set; }

    }
}