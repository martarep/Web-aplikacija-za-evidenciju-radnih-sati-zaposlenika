using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AII.Models
{
    public class LanguageEventArgs:EventArgs
    {
        public string Jezik { get; set; }
    }
}