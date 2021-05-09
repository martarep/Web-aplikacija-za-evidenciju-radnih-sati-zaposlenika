using AII.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class Naslovna : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
         
            CheckPrijava();
        
        }

       

        private void CheckPrijava()
        {
            Djelatnik korisnik = (Djelatnik)Session["korisnik"];

            if(korisnik == null)
            {
                Response.Redirect("Prijava.aspx");
            }

        }

        protected void BtnEngleski_Click(object sender, EventArgs e)
        {

            Djelatnik korisnik = (Djelatnik)Session["korisnik"];
          int  idKorisnik = korisnik.IDDjelatnik;
            if (korisnik != null)
            {
                Repozitorij.UpdateDjelatnikJezik(idKorisnik, "Engleski");
            }

            Session["korisnik"] = Repozitorij.GetDjelatnik(idKorisnik);
            Request.Cookies["CultureInfo"].Value = "en-EN";
            Response.Redirect(Request.Url.AbsolutePath);
        }
        protected void BtnHrvatski_Click(object sender, EventArgs e)
        {

            Djelatnik korisnik = (Djelatnik)Session["korisnik"];
            int idKorisnik = korisnik.IDDjelatnik;
            if (korisnik != null)
            {
                Repozitorij.UpdateDjelatnikJezik(idKorisnik, "Hrvatski");
            }

            Session["korisnik"] = Repozitorij.GetDjelatnik(idKorisnik);
            Request.Cookies["CultureInfo"].Value = "hr-HR";

            Response.Redirect(Request.Url.AbsolutePath);
        }
        protected void BtnOdjava_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Prijava.aspx");
        }
    }
}