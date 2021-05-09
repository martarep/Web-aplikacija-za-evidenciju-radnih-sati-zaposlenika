using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class ProjektPregled : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziProjekte();
                PrikaziPodatkeOProjektu();

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
        private void PrikaziPodatkeOProjektu()
        {
            var projektId = int.Parse(ddlProjekt.SelectedValue);

            Projekt projekt = Repozitorij.GetProjekt(projektId);
            lblNaziv.Text = projekt.Naziv;
            lblVoditeljProjekta.Text = Repozitorij.GetVoditeljProjekta(projektId);
            lblDatumOtvaranja.Text = projekt.DatumOtvaranja.ToShortDateString();

            Klijent klijent = Repozitorij.GetKlijentProjekta(projektId) as Klijent;
            lblKlijent.Text = klijent.Naziv;


            PrikaziDjelatnikeNaProjektu(projektId);
        }

        private void PrikaziDjelatnikeNaProjektu(int projektId)
        {
            lbDjelatnici.DataSource = Repozitorij.GetDjelatniciNaProjektu(projektId);
            lbDjelatnici.DataTextField = "ImePrezime";
            lbDjelatnici.DataValueField = "IDDjelatnik";
            lbDjelatnici.DataBind();
        }

        private void PrikaziProjekte()
        {

            ddlProjekt.DataSource = Repozitorij.GetAktivniProjekti();
            ddlProjekt.DataTextField = "Naziv";
            ddlProjekt.DataValueField = "IDProjekt";
            ddlProjekt.DataBind();

        }


        protected void DdlProjekt_SelectedIndexChanged(object sender, EventArgs e) => PrikaziPodatkeOProjektu();

    }
}