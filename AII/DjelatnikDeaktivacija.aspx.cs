using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class DjelatnikDeaktivacija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopuniDdlListu();
                PrikaziStatus();
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
        private void PrikaziStatus()
        {
            int idDjelatnika = int.Parse(ddlDjelatnik.SelectedValue);
            string aktivnost = Repozitorij.GetAktivnostDjelatnika(idDjelatnika);
            Djelatnik djelatnik = Repozitorij.GetDjelatnik(idDjelatnika);
            if (aktivnost == "Aktivan")
            {
                lblAktivan.Text = $"Djelatnik {djelatnik.ImePrezime} trenutno je aktivan!";
                btnDeAktiviraj.Text = "Deaktiviraj";
            }
            else
            {
                lblAktivan.Text = $"Djelatnik {djelatnik.ImePrezime} trenutno nije aktivan!";
                btnDeAktiviraj.Text = "Aktiviraj";
            }
        }

        private void PopuniDdlListu()
        {
            ddlDjelatnik.DataSource = Repozitorij.GetSviDjelatnici();
            ddlDjelatnik.DataTextField = "ImePrezime";
            ddlDjelatnik.DataValueField = "IDDjelatnik";
            ddlDjelatnik.DataBind();

        }

        protected void BtnDaSpremi_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
            int idDjelatnika = int.Parse(ddlDjelatnik.SelectedValue);
            string operacija = btnDeAktiviraj.Text;
            if (operacija == "Aktiviraj")
            {
                
                Repozitorij.UpdateAktivnostDjelatnika(idDjelatnika,"Aktivan");

            }
            else
            {
                Repozitorij.UpdateAktivnostDjelatnika(idDjelatnika, "Neaktivan");
            }
            PrikaziStatus();
        }

        protected void BtnDeAktiviraj_Click(object sender, EventArgs e)
        {
            string operacija = btnDeAktiviraj.Text;
            if (operacija == "Aktiviraj")
            {
                lblheader.Text = "Aktivacija djelatnika";
                lbl_main.Text = "Jeste li sigurni da želite aktivirati djelatnika? ";
                ModalPopupExtender1.Show();
            }
            else
            {
                lblheader.Text = "Dektivacija djelatnika";
                lbl_main.Text = "Jeste li sigurni da želite deaktivirati djelatnika? ";
                ModalPopupExtender1.Show();
            }
            
        }

        protected void DdlDjelatnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziStatus();
        }
    }
}