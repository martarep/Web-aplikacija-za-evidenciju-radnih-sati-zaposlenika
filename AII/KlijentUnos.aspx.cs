using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class KlijentUnos : System.Web.UI.Page
    {

        private static List<Projekt> privremeniProjekti= new List<Projekt>();
        protected void Page_Load(object sender, EventArgs e)
        {
            PrikaziProjekte();
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


        private void PrikaziProjekte()
        {
            ddlProjekti.DataSource = Repozitorij.GetAktivniProjekti();
            ddlProjekti.DataTextField = "Naziv";
            ddlProjekti.DataValueField = "IDProjekt";
            ddlProjekti.DataBind();
        }

        protected void BtnUnesi_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Unos novog klijenta";
            lbl_main.Text = "Jeste li sigurni da želite unijeti novog klijenta? ";
            ModalPopupExtender1.Show();

        }

        protected void BtnOdustani_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Odustajanje od unosa novog klijenta";
            lbl_main.Text = "Jeste li sigurni da želite odustati od unosa novog klijenta?";
            ModalPopupExtender1.Show();

        }

        protected void BtnDaUnesi_Click(object sender, EventArgs e)
        {
            if (lblheader.Text == "Unos novog klijenta")
            {
                ModalPopupExtender1.Hide();
                Klijent klijent = new Klijent();
                klijent.Naziv = tbNaziv.Text;
               
                Repozitorij.InsertKlijent(klijent);
                ModalPopupExtender1.Hide();

                int idUnesenogKlijenta = Repozitorij.GetKlijentId(klijent.Naziv);
                if (idUnesenogKlijenta != 0)
                {
                  
                    AžurirajProjekteKlijenta(idUnesenogKlijenta);
                }
                else
                {
                    ModalPopupExtender2.Show();
                }

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
            tbNaziv.Text = "";
            PrikaziProjekte();

            ClearLbProjekti();
        }

        private void AžurirajProjekteKlijenta(int idKlijent)
        {
            if (privremeniProjekti.Count == 0)
            {
                return;
            }

            foreach (Projekt projekt in privremeniProjekti)
            {
                Repozitorij.UpdateProjektKlijentId(idKlijent, projekt.IDProjekt);
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