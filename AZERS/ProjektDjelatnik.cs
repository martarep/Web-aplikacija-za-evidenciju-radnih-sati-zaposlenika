//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AZERS
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjektDjelatnik
    {
        public int IDProjektDjelatnik { get; set; }
        public int ProjektID { get; set; }
        public int DjelatnikID { get; set; }
    
        public virtual Djelatnik Djelatnik { get; set; }
        public virtual Projekt Projekt { get; set; }
    }
}