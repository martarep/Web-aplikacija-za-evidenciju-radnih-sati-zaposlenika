using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class DjelatnikPregle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                PrikaziDjelatnike();
                PrikaziPodatkeODjelatniku();

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

        private void PrikaziPodatkeODjelatniku()
        {
            var djelatnikId = int.Parse(ddlDjelatnik.SelectedValue);

            Djelatnik djelatnik = Repozitorij.GetDjelatnik(djelatnikId);
            lblIme.Text = djelatnik.Ime;
            lblPrezime.Text = djelatnik.Prezime;
            lblEmail.Text = djelatnik.Email;
            lblDatumZaposlenja.Text = djelatnik.DatumZaposlenja.ToShortDateString();
            lblLozinka.Text = djelatnik.Lozinka;
            lblTipDjelatnika.Text = Repozitorij.GetTipDjelatnika(djelatnikId);
            lblTim.Text = Repozitorij.GetTimDjelatnika(djelatnikId);

            PrikaziProjekteDjelatnika(djelatnikId);
        }

        private void PrikaziProjekteDjelatnika(int djelatnikId)
        {
            lbProjekti.DataSource = Repozitorij.GetProjektiDjelatnika(djelatnikId);
            lbProjekti.DataTextField = "Naziv";
            lbProjekti.DataValueField = "IDProjekt";
            lbProjekti.DataBind();
        }

        private void PrikaziDjelatnike()
        {


            ddlDjelatnik.DataSource = Repozitorij.GetAktivniDjelatnici();
            ddlDjelatnik.DataTextField = "ImePrezime";
            ddlDjelatnik.DataValueField = "IDDjelatnik";
                ddlDjelatnik.DataBind();
    
        }

        protected void ddlDjelatnik_SelectedIndexChanged(object sender, EventArgs e) => PrikaziPodatkeODjelatniku();
    }
}