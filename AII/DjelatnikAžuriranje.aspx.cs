using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class DjelatnikAžuriranje : System.Web.UI.Page
    {
        private static List<Projekt> privremeniProjekti;
     
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PrikaziDjelatnike();
                PrikaziPodatkeODjelatniku();
                PrikaziTipDjelatnikaITim();
                PopuniListu();
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

            var djelatnikId = int.Parse(ddlDjelatnik.SelectedValue);
            privremeniProjekti = new List<Projekt>();
            privremeniProjekti.AddRange(Repozitorij.GetProjektiDjelatnika(djelatnikId));
            PrikaziProjekte();
            RemoveDuplikatiIzDdlProjekti();

        }

        private void PrikaziTipDjelatnikaITim()
        {
            ddlTipDjelatnika.DataSource = Repozitorij.GetSviTipoviDjelatnika();
            ddlTipDjelatnika.DataTextField = "Naziv";
            ddlTipDjelatnika.DataValueField = "IDTipDjelatnika";
            ddlTipDjelatnika.DataBind();

            ddlTim.DataSource = Repozitorij.GetSviAktivniTimovi();
            ddlTim.DataTextField = "Naziv";
            ddlTim.DataValueField = "IDTim";
            ddlTim.DataBind();
        }

        private void PrikaziProjekte()
        {
            ddlProjekti.DataSource = Repozitorij.GetAktivniProjekti();
            ddlProjekti.DataTextField = "Naziv";
            ddlProjekti.DataValueField = "IDProjekt";
            ddlProjekti.DataBind();
        }

        private void PrikaziPodatkeODjelatniku()
        {
            var djelatnikId = int.Parse(ddlDjelatnik.SelectedValue);

            

            Djelatnik djelatnik = Repozitorij.GetDjelatnik(djelatnikId);
            tbIme.Text = djelatnik.Ime;
            tbPrezime.Text = djelatnik.Prezime;
            tbEmail.Text = djelatnik.Email;
            tbDatumZaposlenja.Text = djelatnik.DatumZaposlenja.ToString("yyyy-MM-dd");
            tbLozinka.Text = djelatnik.Lozinka;
            ddlTipDjelatnika.SelectedValue = Repozitorij.GetTipDjelatnikaID(Repozitorij.GetTipDjelatnika(djelatnikId)).ToString();
            ddlTim.SelectedValue = Repozitorij.GetTimID(Repozitorij.GetTimDjelatnika(djelatnikId)).ToString();

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
        protected void DdlDjelatnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziPodatkeODjelatniku();
            PopuniListu();
        }
    

        protected void BtnSpremi_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Ažuriranje djelatnika";
            lbl_main.Text = "Jeste li sigurni da želite ažurirati djelatnika? ";
            ModalPopupExtender1.Show();

        }

        protected void BtnOdustani_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Odustajanje od ažuriranja djelatnika";
            lbl_main.Text = "Jeste li sigurni da želite odustati od ažuriranja djelatnika?";
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
            
                int idProjektzaUklanjanje = int.Parse(lbProjekti.SelectedValue);

                var itemUkloni = privremeniProjekti.Find(x => x.IDProjekt == idProjektzaUklanjanje);
           
            privremeniProjekti.Remove(itemUkloni);
            LoadLbProjekti();

        }

        protected void BtnDaSpremi_Click(object sender, EventArgs e)
        {

            if (lblheader.Text=="Ažuriranje djelatnika")
            {
                Djelatnik ažuriraniDjelatnik = new Djelatnik();
                ažuriraniDjelatnik.IDDjelatnik = int.Parse(ddlDjelatnik.SelectedValue);
                ažuriraniDjelatnik.Ime = tbIme.Text;
                ažuriraniDjelatnik.Prezime = tbPrezime.Text;
                ažuriraniDjelatnik.Email = tbEmail.Text;
                ažuriraniDjelatnik.Lozinka = tbLozinka.Text;
                ažuriraniDjelatnik.DatumZaposlenja = DateTime.Parse(tbDatumZaposlenja.Text);
                ažuriraniDjelatnik.TipDjelatnikaID = Repozitorij.GetTipDjelatnikaID(ddlTipDjelatnika.SelectedItem.Text);
                ažuriraniDjelatnik.TimID = int.Parse(ddlTim.SelectedValue);

                Repozitorij.UpdateDjelatnik(ažuriraniDjelatnik);
                ModalPopupExtender1.Hide();
                ddlDjelatnik.SelectedValue = ažuriraniDjelatnik.IDDjelatnik.ToString();

                AžurirajProjekteDjelatnika(ažuriraniDjelatnik.IDDjelatnik);
                PrikaziPodatkeODjelatniku();
                PrikaziDjelatnike();
                PopuniListu();
            }
            else
            {
                var ddlID = ddlDjelatnik.SelectedValue;
                ModalPopupExtender1.Hide();

                PrikaziPodatkeODjelatniku();
                PopuniListu();
                PrikaziDjelatnike();
                ddlDjelatnik.SelectedValue = ddlID;

              
            }
            
        }

        private void AžurirajProjekteDjelatnika(int iDDjelatnik)
        {
           
            List<Projekt> projektiDjelatnika = new List<Projekt>();
           projektiDjelatnika.AddRange(Repozitorij.GetProjektiDjelatnika(iDDjelatnik));
            List<Projekt> projektiZaDodati = privremeniProjekti;
            List<Projekt> projektiZaUkloniti = new List<Projekt>();
            List<Projekt> projektiDjelatnikaKojiOstaju = new List<Projekt>();

            foreach (Projekt projekt in projektiDjelatnika)
            {
               var projektKojiOstaje = privremeniProjekti.Find(x => x.IDProjekt == projekt.IDProjekt);
                if (projektKojiOstaje != null)
                {
                    projektiDjelatnikaKojiOstaju.Add(projektKojiOstaje);
                }
            }
            foreach (Projekt projekt in projektiDjelatnika)
            {
                var projektKojiNeOstaje = projektiDjelatnikaKojiOstaju.Find(x => x.IDProjekt == projekt.IDProjekt);
                if (projektKojiNeOstaje == null)
                {
                    projektiZaUkloniti.Add(projekt);
                }
            }


            foreach (Projekt projekt in projektiDjelatnika)
            {
              var itemZaBrisanje =  projektiZaDodati.Find(x => x.IDProjekt == projekt.IDProjekt);
                if (itemZaBrisanje != null )
                {
                    projektiZaDodati.Remove(itemZaBrisanje);
                }

            }
          
            if (projektiZaDodati.Count != 0)
            {
                foreach (Projekt projekt in projektiZaDodati)
                {
                    Repozitorij.InsertProjektDjelatnik(iDDjelatnik, projekt.IDProjekt);
                }
            }

            if (projektiZaUkloniti.Count != 0)
            {
                foreach (Projekt projekt in projektiZaUkloniti)
                {
                    Repozitorij.DeleteProjektDjelatnik(iDDjelatnik, projekt.IDProjekt);
                }
            }

        }
    }
}