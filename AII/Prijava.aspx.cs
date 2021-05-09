using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class Prijava : System.Web.UI.Page
    {
        private bool ispravniPodaci;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPrijaviSe_Click(object sender, EventArgs e)
        {

            string email = tbEmail.Text;
            string lozinka = tbLozinka.Text;

            int postojiKorisnik = Repozitorij.GetPrijavaRezultat(email, lozinka);

            if (postojiKorisnik > 0)
            {
                ispravniPodaci = true;
                Djelatnik korisnik = Repozitorij.GetPrijavaDjelatnik(email, lozinka);
                Session["korisnik"] = korisnik;
                Session.Timeout = 2400;
                HttpCookie cookie = new HttpCookie("CultureInfo");
                if (korisnik.Jezik=="Engleski")
                {
                    cookie.Value = "en-EN";
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Value = "hr-HR";
                    Response.Cookies.Add(cookie);
                }
                
                Response.Redirect("Naslovna.aspx");
                
            }

            else
            {
                ispravniPodaci = false;
            }


        }

        protected void CustomValidatorPrijava_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ispravniPodaci;
        }
    }
}