using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class KlijentDeaktivacija : System.Web.UI.Page
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
            int idKlijent = int.Parse(ddlKlijent.SelectedValue);
            string aktivnost = Repozitorij.GetAktivnostKlijenta(idKlijent);
            Klijent klijent = Repozitorij.GetKlijent(idKlijent);
            if (aktivnost == "Aktivan")
            {
                lblAktivan.Text = $"Klijent {klijent.Naziv} trenutno je aktivan!";
                btnDeAktiviraj.Text = "Deaktiviraj";
            }
            else
            {
                lblAktivan.Text = $"Klijent {klijent.Naziv} trenutno nije aktivan!";
                btnDeAktiviraj.Text = "Aktiviraj";
            }
        }

        private void PopuniDdlListu()
        {
            ddlKlijent.DataSource = Repozitorij.GetSviKlijenti();
            ddlKlijent.DataTextField = "Naziv";
            ddlKlijent.DataValueField = "IDKlijent";
            ddlKlijent.DataBind();

        }

        protected void BtnDaDeaktiviraj_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
            int idKlijent = int.Parse(ddlKlijent.SelectedValue);
            string operacija = btnDeAktiviraj.Text;
            if (operacija == "Aktiviraj")
            {

                Repozitorij.UpdateAktivnostKlijenta(idKlijent, "Aktivan");

            }
            else
            {
                Repozitorij.UpdateAktivnostKlijenta(idKlijent, "Neaktivan");
            }
            PrikaziStatus();
        }

        protected void BtnDeAktiviraj_Click(object sender, EventArgs e)
        {
            string operacija = btnDeAktiviraj.Text;
            if (operacija == "Aktiviraj")
            {
                lblheader.Text = "Aktivacija klijenta";
                lbl_main.Text = "Jeste li sigurni da želite aktivirati klijenta? ";
                ModalPopupExtender1.Show();
            }
            else
            {
                lblheader.Text = "Dektivacija klijenta";
                lbl_main.Text = "Jeste li sigurni da želite deaktivirati klijenta? ";
                ModalPopupExtender1.Show();
            }

        }

        protected void DdlKlijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziStatus();
        }
    }
}