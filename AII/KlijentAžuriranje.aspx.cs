using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class KlijentAžuriranje : System.Web.UI.Page
    {
        private static List<Projekt> privremeniProjekti;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziKlijente();
                PrikaziPodatkeOKlijentu();
                PopuniListu();
                PrikaziProjekte();
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
        private void PopuniListu()
        {

            var klijentId = int.Parse(ddlKlijent.SelectedValue);
            privremeniProjekti = new List<Projekt>();
            privremeniProjekti.AddRange(Repozitorij.GetProjektiKlijenta(klijentId));
            PrikaziProjekte();
            RemoveDuplikatiIzDdlProjekti();

        }

        private void PrikaziProjekte()
        {
            ddlProjekti.DataSource = Repozitorij.GetAktivniProjekti();
            ddlProjekti.DataTextField = "Naziv";
            ddlProjekti.DataValueField = "IDProjekt";
            ddlProjekti.DataBind();
        }

        private void PrikaziPodatkeOKlijentu()
        {
            var klijentId = int.Parse(ddlKlijent.SelectedValue);



            Klijent klijent = Repozitorij.GetKlijent(klijentId);
            tbNaziv.Text = klijent.Naziv;
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
        protected void DdlKlijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziPodatkeOKlijentu();
            PopuniListu();
        }


        protected void BtnSpremi_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Ažuriranje klijenta";
            lbl_main.Text = "Jeste li sigurni da želite ažurirati klijenta? ";
            ModalPopupExtender1.Show();

        }

        protected void BtnOdustani_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Odustajanje od ažuriranja klijenta";
            lbl_main.Text = "Jeste li sigurni da želite odustati od ažuriranja klijenta?";
            ModalPopupExtender1.Show();

        }

        protected void BtnDodaj_Click(object sender, EventArgs e)
        {

            int idProjektZaDodavanje = int.Parse(ddlProjekti.SelectedValue);

            Projekt projektDodaj = Repozitorij.GetProjekt(idProjektZaDodavanje);

            privremeniProjekti.Add(projektDodaj);
            LoadLbProjekti();
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

        private void LoadLbProjekti()
        {

            lbProjekti.DataSource = privremeniProjekti;
            lbProjekti.DataTextField = "Naziv";
            lbProjekti.DataValueField = "IDProjekt";
            lbProjekti.DataBind();
            PrikaziProjekte();
            RemoveDuplikatiIzDdlProjekti();
        }

        protected void BtnUkloni_Click(object sender, EventArgs e)
        {

            if (lbProjekti.SelectedValue == string.Empty)
            {
                return;
            }

            List<Projekt> projektiKlijenta = new List<Projekt>();
            projektiKlijenta.AddRange(Repozitorij.GetProjektiKlijenta(int.Parse(ddlKlijent.SelectedValue)));


            int idProjektzaUklanjanje = int.Parse(lbProjekti.SelectedValue);

            var itemUkloni = privremeniProjekti.Find(x => x.IDProjekt == idProjektzaUklanjanje);
            var itemPostoji= new Projekt();
            foreach (Projekt projekt in projektiKlijenta)
            {
              itemPostoji = projektiKlijenta.Find(x => x.IDProjekt == idProjektzaUklanjanje);

            }
            if (itemPostoji != null)
            {
                ModalPopupExtender2.Show();
            }
            else
            {
                privremeniProjekti.Remove(itemUkloni);
                LoadLbProjekti();
            }

        }

        protected void BtnDaSpremi_Click(object sender, EventArgs e)
        {

            if (lblheader.Text == "Ažuriranje klijenta")
            {
                Klijent ažuriraniKlijent = new Klijent();
                ažuriraniKlijent.IDKlijent = int.Parse(ddlKlijent.SelectedValue);
                ažuriraniKlijent.Naziv = tbNaziv.Text;

                Repozitorij.UpdateKlijent(ažuriraniKlijent);
                ModalPopupExtender1.Hide();
                ddlKlijent.SelectedValue = ažuriraniKlijent.IDKlijent.ToString();

                AžurirajProjekteKlijenta(ažuriraniKlijent.IDKlijent);
                PrikaziPodatkeOKlijentu();
                PrikaziKlijente();
                PopuniListu();
            }

            else
            {
                var ddlID = ddlKlijent.SelectedValue;
                ModalPopupExtender1.Hide();

                PrikaziPodatkeOKlijentu();
                PopuniListu();
                PrikaziKlijente();
                ddlKlijent.SelectedValue = ddlID;


            }

        }

        private void AžurirajProjekteKlijenta(int idKlijent)
        {

            List<Projekt> projektiKlijenta = new List<Projekt>();
            projektiKlijenta.AddRange(Repozitorij.GetProjektiKlijenta(idKlijent));
            List<Projekt> projektiZaDodati = privremeniProjekti;
            List<Projekt> projektiZaUkloniti = new List<Projekt>();
            List<Projekt> projektiKlijentaKojiOstaju = new List<Projekt>();

            foreach (Projekt projekt in projektiKlijenta)
            {
                var projektKojiOstaje = privremeniProjekti.Find(x => x.IDProjekt == projekt.IDProjekt);
                if (projektKojiOstaje != null)
                {
                    projektiKlijentaKojiOstaju.Add(projektKojiOstaje);
                }
            }
            foreach (Projekt projekt in projektiKlijenta)
            {
                var projektKojiNeOstaje = projektiKlijentaKojiOstaju.Find(x => x.IDProjekt == projekt.IDProjekt);
                if (projektKojiNeOstaje == null)
                {
                    projektiZaUkloniti.Add(projekt);
                }
            }


            foreach (Projekt projekt in projektiKlijenta)
            {
                var itemZaBrisanje = projektiZaDodati.Find(x => x.IDProjekt == projekt.IDProjekt);
                if (itemZaBrisanje != null)
                {
                    projektiZaDodati.Remove(itemZaBrisanje);
                }

            }

            if (projektiZaDodati.Count != 0)
            {
                foreach (Projekt projekt in projektiZaDodati)
                {
                    Repozitorij.UpdateProjektKlijentId(idKlijent, projekt.IDProjekt);
                }
            }

            if (projektiZaUkloniti.Count != 0)
            {
                foreach (Projekt projekt in projektiZaUkloniti)
                {
                   ModalPopupExtender2.Show();
                }
            }

        }
    }
}