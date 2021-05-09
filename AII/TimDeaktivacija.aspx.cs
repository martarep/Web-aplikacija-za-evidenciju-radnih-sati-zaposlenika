using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class TimDeaktivacija : System.Web.UI.Page
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
            int idTim = int.Parse(ddlTim.SelectedValue);
            string aktivnost = Repozitorij.GetAktivnostTima(idTim);
            Tim tim = Repozitorij.GetTim(idTim);
            if (aktivnost == "Aktivan")
            {
                lblAktivan.Text = $"Tim {tim.Naziv} trenutno je aktivan!";
                btnDeAktiviraj.Text = "Deaktiviraj";
            }
            else
            {
                lblAktivan.Text = $"Tim {tim.Naziv} trenutno nije aktivan!";
                btnDeAktiviraj.Text = "Aktiviraj";
            }
        }

        private void PopuniDdlListu()
        {
            ddlTim.DataSource = Repozitorij.GetSviTimovi();
            ddlTim.DataTextField = "Naziv";
            ddlTim.DataValueField = "IDTim";
            ddlTim.DataBind();

        }

        protected void BtnDaDeaktiviraj_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
            int idTim = int.Parse(ddlTim.SelectedValue);
            string operacija = btnDeAktiviraj.Text;
            if (operacija == "Aktiviraj")
            {
                
                Repozitorij.UpdateAktivnostTima(idTim,"Aktivan");

            }
            else
            {
                Repozitorij.UpdateAktivnostTima(idTim, "Neaktivan");
            }
            PrikaziStatus();
        }

        protected void BtnDeAktiviraj_Click(object sender, EventArgs e)
        {
            string operacija = btnDeAktiviraj.Text;
            if (operacija == "Aktiviraj")
            {
                lblheader.Text = "Aktivacija tima";
                lbl_main.Text = "Jeste li sigurni da želite aktivirati tim? ";
                ModalPopupExtender1.Show();
            }
            else
            {
                lblheader.Text = "Dektivacija tima";
                lbl_main.Text = "Jeste li sigurni da želite deaktivirati tim? ";
                ModalPopupExtender1.Show();
            }
            
        }

        protected void DdlTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziStatus();
        }
    }
}