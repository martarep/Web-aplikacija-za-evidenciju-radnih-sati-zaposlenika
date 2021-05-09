using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class ProjektUnos : System.Web.UI.Page
    {
        private static List<Djelatnik> privremeniDjelatnici;
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

            ddlVoditeljProjekta.DataSource = Repozitorij.GetVoditeljiTima();
            ddlVoditeljProjekta.DataTextField = "ImePrezime";
            ddlVoditeljProjekta.DataValueField = "IDDjelatnik";
            ddlVoditeljProjekta.DataBind();

            ddlKlijent.DataSource = Repozitorij.GetSviKlijenti();
            ddlKlijent.DataTextField = "Naziv";
            ddlKlijent.DataValueField = "IDKlijent";
            ddlKlijent.DataBind();
            privremeniDjelatnici = new List<Djelatnik>();
            PrikaziDjelatnike();
        }

        private void PrikaziDjelatnike()
        {
            ddlDjelatnici.DataSource = Repozitorij.GetAktivniDjelatnici();
            ddlDjelatnici.DataTextField = "ImePrezime";
            ddlDjelatnici.DataValueField = "IDDjelatnik";
            ddlDjelatnici.DataBind();
        }

        protected void BtnUnesi_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Unos novog projekta";
            lbl_main.Text = "Jeste li sigurni da želite unijeti novi projekt? ";
            ModalPopupExtender1.Show();

        }

        protected void BtnOdustani_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Odustajanje od unosa novog projekta";
            lbl_main.Text = "Jeste li sigurni da želite odustati od unosa novog projekta?";
            ModalPopupExtender1.Show();

        }

        protected void BtnDaUnesi_Click(object sender, EventArgs e)
        {
            if (lblheader.Text == "Unos novog projekta")
            {
                Projekt projekt = new Projekt();
                projekt.Naziv = tbNaziv.Text;
                projekt.DatumOtvaranja = DateTime.Parse(tbDatumOtvaranja.Text);
                projekt.KlijentID = int.Parse(ddlKlijent.SelectedValue);
                projekt.VoditeljProjektaID = int.Parse(ddlVoditeljProjekta.SelectedValue);
                Djelatnik voditelj = Repozitorij.GetDjelatnik(projekt.VoditeljProjektaID);
                if (!privremeniDjelatnici.Contains(voditelj))
                {
                    privremeniDjelatnici.Add(voditelj);
                }
        
                Repozitorij.InsertProjekt(projekt);
                ModalPopupExtender1.Hide();

                int idUnesenogProjekta = Repozitorij.GetProjektId(projekt);
  
                    AžurirajProjekteDjelatnika(idUnesenogProjekta);

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
            tbDatumOtvaranja.Text = "";
            PrikaziPodatkeDdl();

            ClearLbDjelatnici();

        }

        private void AžurirajProjekteDjelatnika(int idProjekt)
        {
            if (privremeniDjelatnici.Count == 0)
            {
                return;
            }

            foreach (Djelatnik djelatnik in privremeniDjelatnici)
            {
                Repozitorij.InsertProjektDjelatnik(djelatnik.IDDjelatnik, idProjekt);
            }

        }

        private void ClearLbDjelatnici()
        {
            privremeniDjelatnici.Clear();
            LoadLbDjelatnici();
        }

        protected void BtnDodaj_Click(object sender, EventArgs e)
        {
            int idDjelatnikZaDodavanje = int.Parse(ddlDjelatnici.SelectedValue);

            Djelatnik djelatnikDodaj = Repozitorij.GetDjelatnik(idDjelatnikZaDodavanje);

            privremeniDjelatnici.Add(djelatnikDodaj);
            LoadLbDjelatnici();
        }

        private void LoadLbDjelatnici()
        {
            lbDjelatnik.DataSource = privremeniDjelatnici;
            lbDjelatnik.DataTextField = "ImePrezime";
            lbDjelatnik.DataValueField = "IDDjelatnik";
            lbDjelatnik.DataBind();
            PrikaziDjelatnike();
            RemoveDuplikatiIzDdlDjelatnici();

        }

        private void RemoveDuplikatiIzDdlDjelatnici()
        {
            foreach (Djelatnik djelatnik in privremeniDjelatnici)
            {
                var djelatnikDuplikat = ddlDjelatnici.Items.FindByValue(djelatnik.IDDjelatnik.ToString());
                if (djelatnikDuplikat != null)
                {
                    ddlDjelatnici.Items.Remove(djelatnikDuplikat);
                }

            }
        }

        protected void BtnUkloni_Click(object sender, EventArgs e)
        {
            if (lbDjelatnik.SelectedValue == string.Empty)
            {
                return;
            }

            int idDjelatnikzaUklanjanje = int.Parse(lbDjelatnik.SelectedValue);

            var itemUkloni = privremeniDjelatnici.Find(x => x.IDDjelatnik == idDjelatnikzaUklanjanje);
            privremeniDjelatnici.Remove(itemUkloni);
            LoadLbDjelatnici();
        }
    }
}