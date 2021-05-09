using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class DjelatnikUnos : System.Web.UI.Page
    {
        private static List<Projekt> privremeniProjekti;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziPodatkeDdl();
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
        private void PrikaziPodatkeDdl()
        {
            ddlTipDjelatnika.DataSource = Repozitorij.GetSviTipoviDjelatnika();
            ddlTipDjelatnika.DataTextField = "Naziv";
            ddlTipDjelatnika.DataValueField = "IDTipDjelatnika";
            ddlTipDjelatnika.DataBind();

            ddlTim.DataSource = Repozitorij.GetSviAktivniTimovi();
            ddlTim.DataTextField = "Naziv";
            ddlTim.DataValueField = "IDTim";
            ddlTim.DataBind();
            PrikaziProjekte();
            privremeniProjekti = new List<Projekt>();
        }

        private void PrikaziProjekte()
        {
            ddlProjekti.DataSource = Repozitorij.GetAktivniProjekti();
            ddlProjekti.DataTextField = "Naziv";
            ddlProjekti.DataValueField = "IDProjekt";
            ddlProjekti.DataBind();
        }

        protected void BtnUnesi_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Unos novog djelatnika";
            lbl_main.Text = "Jeste li sigurni da želite unijeti djelatnika? ";
            ModalPopupExtender1.Show();

        }

        protected void BtnOdustani_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Odustajanje od unosa novog djelatnika";
            lbl_main.Text = "Jeste li sigurni da želite odustati od unosa novog djelatnika?";
            ModalPopupExtender1.Show();
         
        }

        protected void BtnDaUnesi_Click(object sender, EventArgs e)
        {
            if (lblheader.Text == "Unos novog djelatnika")
            {
                Djelatnik noviDjelatnik = new Djelatnik();
                noviDjelatnik.Ime = tbIme.Text;
                noviDjelatnik.Prezime = tbPrezime.Text;
                noviDjelatnik.Email = tbEmail.Text;
                noviDjelatnik.Lozinka = tbLozinka.Text;
                noviDjelatnik.DatumZaposlenja = DateTime.Parse(tbDatumZaposlenja.Text);
                noviDjelatnik.TipDjelatnikaID = Repozitorij.GetTipDjelatnikaID(ddlTipDjelatnika.SelectedItem.Text);
                noviDjelatnik.TimID = Repozitorij.GetTimID(ddlTim.SelectedItem.Text);

                Repozitorij.InsertDjelatnik(noviDjelatnik);
                ModalPopupExtender1.Hide();

                int idUnesenogDjelatnika = Repozitorij.GetDjelatnikID(noviDjelatnik);
              
              
                    AžurirajProjekteDjelatnika(idUnesenogDjelatnika);
              
                ClearPoljaZaUnos();
            }
            else
            {

                ModalPopupExtender1.Hide();
                ClearPoljaZaUnos();
            }
        }

        private void ClearPoljaZaUnos()
        {
            tbIme.Text = "";
            tbPrezime.Text = "";
            tbEmail.Text = "";
            tbLozinka.Text = "";
            tbDatumZaposlenja.Text = "";
            PrikaziPodatkeDdl();

            ClearLbProjekti();
        }

        private void AžurirajProjekteDjelatnika(int iDDjelatnik)
        {
            if(privremeniProjekti.Count == 0)
            {
                return;
            }

            foreach (Projekt projekt in privremeniProjekti)
            {
                Repozitorij.InsertProjektDjelatnik(iDDjelatnik, projekt.IDProjekt);
            }

        }

        private void ClearLbProjekti()
        {
            privremeniProjekti.Clear();
            LoadLbProjekti();
        }

        protected void BtnDodaj_Click(object sender, EventArgs e)
        {
            int idProjektZaDodavanje = int.Parse(ddlProjekti.SelectedValue);

            Projekt projektDodaj = Repozitorij.GetProjekt(idProjektZaDodavanje);

            privremeniProjekti.Add(projektDodaj);
            LoadLbProjekti();
        }

        private void LoadLbProjekti()
        {
            lbProjekti.DataSource = privremeniProjekti;
            lbProjekti.DataTextField = "Naziv";
            lbProjekti.DataValueField = "IDProjekt";
            lbProjekti.DataBind();
            PrikaziProjekte();
            RemoveDuplikatiIzDdlProjekti();
         
        }

        private void RemoveDuplikatiIzDdlProjekti()
        {
            foreach (Projekt projekt in privremeniProjekti)
            {
                var projektDuplikat = ddlProjekti.Items.FindByValue(projekt.IDProjekt.ToString());
                if (projektDuplikat != null)
                {
                    ddlProjekti.Items.Remove(projektDuplikat);
                }

            }
        }

        protected void BtnUkloni_Click(object sender, EventArgs e)
        {
            if (lbProjekti.SelectedValue == string.Empty)
            {
                return;
            }

            int idProjektzaUklanjanje = int.Parse(lbProjekti.SelectedValue);

            var itemUkloni = privremeniProjekti.Find(x => x.IDProjekt == idProjektzaUklanjanje);
            privremeniProjekti.Remove(itemUkloni);
            LoadLbProjekti();
        }
    }
}