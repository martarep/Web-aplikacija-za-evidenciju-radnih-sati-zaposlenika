using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AZERS.Models
{
    public class ProjektEvidencijaVM
    {
        public int IdDjelatnik { get; set; }

        public List<ProjektEvidencija> ProjektiEvidencija { get; set; }

        public DateTime DatumSatnice { get; set; }

        public TimeSpan UkupnoRedovnihSati { get; set; }
        public TimeSpan UkupnoPrekovremenihSati { get; set; }

        public string StatusSatnice { get; set; }

        public string SaveOrDate { get; set; }
    }
}