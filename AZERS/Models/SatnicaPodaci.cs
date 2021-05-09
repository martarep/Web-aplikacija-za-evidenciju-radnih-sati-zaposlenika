using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AZERS.Models
{
    public class SatnicaPodaci
    {

        public int IDProjekt { get; set; }
        public int IDDjelatnik { get; set; }
        public DateTime DatumSatnica { get; set; }
        public TimeSpan Vrijeme { get; set; }
    }
}