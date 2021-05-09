using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class KlijentPregled : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziKlijente();
                PrikaziPodatkeOKlijentu();

            }
            CheckPrijava();
        }
        private void CheckPrijava()
        {
            Djelatnik korisnik = (Djelatnik)Session["korisnik"];

            if (korisnik == null)
            {
                Response.Redirect("Prijava.aspx");
            }

        }
        private void PrikaziPodatkeOKlijentu()
        {
            var klijentId = int.Parse(ddlKlijent.SelectedValue);

            Klijent klijent = Repozitorij.GetKlijent(klijentId);
            lblNaziv.Text = klijent.Naziv;
          
            PrikaziProjekteKlijenta(klijentId);
        }

        private void PrikaziProjekteKlijenta(int klijentId)
        {
            lbProjekti.DataSource = Repozitorij.GetProjektiKlijenta(klijentId);
            lbProjekti.DataTextField = "Naziv";
            lbProjekti.DataValueField = "IDProjekt";
            lbProjekti.DataBind();
        }

        private void PrikaziKlijente()
        {


            ddlKlijent.DataSource = Repozitorij.GetAktivniKlijenti();
            ddlKlijent.DataTextField = "Naziv";
            ddlKlijent.DataValueField = "IDKlijent";
            ddlKlijent.DataBind();

        }

        protected void DdlKlijent_SelectedIndexChanged(object sender, EventArgs e) => PrikaziPodatkeOKlijentu();
    }
}