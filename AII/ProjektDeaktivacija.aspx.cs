using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class ProjektDeaktivacija : System.Web.UI.Page
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
            int idProjekt = int.Parse(ddlProjekt.SelectedValue);
            string aktivnost = Repozitorij.GetAktivnostProjekta(idProjekt);
            Projekt projekt = Repozitorij.GetProjekt(idProjekt);
            if (aktivnost == "Aktivan")
            {
                lblAktivan.Text = $"Projekt {projekt.Naziv} trenutno je aktivan!";
                btnDeAktiviraj.Text = "Deaktiviraj";
            }
            else
            {
                lblAktivan.Text = $"Projekt {projekt.Naziv} trenutno nije aktivan!";
                btnDeAktiviraj.Text = "Aktiviraj";
            }
        }

        private void PopuniDdlListu()
        {
            ddlProjekt.DataSource = Repozitorij.GetSviProjekti();
            ddlProjekt.DataTextField = "Naziv";
            ddlProjekt.DataValueField = "IDProjekt";
            ddlProjekt.DataBind();

        }

        protected void BtnDaDeaktiviraj_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
            int idProjekt = int.Parse(ddlProjekt.SelectedValue);
            string operacija = btnDeAktiviraj.Text;
            if (operacija == "Aktiviraj")
            {

                Repozitorij.UpdateAktivnostProjekta(idProjekt, "Aktivan");

            }
            else
            {
                Repozitorij.UpdateAktivnostProjekta(idProjekt, "Neaktivan");
            }
            PrikaziStatus();
        }

        protected void BtnDeAktiviraj_Click(object sender, EventArgs e)
        {
            string operacija = btnDeAktiviraj.Text;
            if (operacija == "Aktiviraj")
            {
                lblheader.Text = "Aktivacija projekta";
                lbl_main.Text = "Jeste li sigurni da želite aktivirati projekt? ";
                ModalPopupExtender1.Show();
            }
            else
            {
                lblheader.Text = "Dektivacija projekta";
                lbl_main.Text = "Jeste li sigurni da želite deaktivirati projekt? ";
                ModalPopupExtender1.Show();
            }

        }

        protected void DdlProjekt_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziStatus();
        }
    }
}