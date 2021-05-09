using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class TimUnos : System.Web.UI.Page
    {
        private static List<Djelatnik> privremeniDjelatnici;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziDDlVoditeljTima();
                PrikaziDjelatnike();
                privremeniDjelatnici = new List<Djelatnik>();
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
        private void PrikaziDDlVoditeljTima()
        {
            ddlVoditeljTima.DataSource = Repozitorij.GetZaposlenici();
            ddlVoditeljTima.DataTextField = "ImePrezime";
            ddlVoditeljTima.DataValueField = "IDDjelatnik";
            ddlVoditeljTima.DataBind();
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
            lblheader.Text = "Unos novog tima";
            lbl_main.Text = "Jeste li sigurni da želite unijeti novi tim? ";
            ModalPopupExtender1.Show();

        }

        protected void BtnOdustani_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Odustajanje od unosa novog tima";
            lbl_main.Text = "Jeste li sigurni da želite odustati od unosa novog tima?";
            ModalPopupExtender1.Show();

        }

        protected void BtnDaUnesi_Click(object sender, EventArgs e)
        {
            if (lblheader.Text == "Unos novog tima")
            {

                Tim tim = new Tim();
                tim.Naziv = tbNaziv.Text;
                tim.DatumKreiranja = DateTime.Parse(tbDatumKreiranja.Text);
                int voditeljTimaId = int.Parse(ddlVoditeljTima.SelectedValue);
                Repozitorij.InsertTim(tim);
                int idUnesenogTima = Repozitorij.GetTimID(tim.Naziv);
                Repozitorij.UpdateTipDjelatika(idUnesenogTima, voditeljTimaId, 2);

                ModalPopupExtender1.Hide();

                AžurirajDjelatnikeTima(idUnesenogTima);

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
            tbDatumKreiranja.Text = "";
            
            PrikaziDDlVoditeljTima();
            PrikaziDjelatnike();

            ClearLbDjelatnici();
        }

        private void AžurirajDjelatnikeTima(int idTim)
        {
            if (privremeniDjelatnici.Count == 0)
            {
                return;
            }

            foreach (Djelatnik djelatnik in privremeniDjelatnici)
            {
                Repozitorij.UpdateDjelatnikTimId(idTim, djelatnik.IDDjelatnik);
            }

        }

        private void ClearLbDjelatnici()
        {
            privremeniDjelatnici.Clear();
            LoadLbProjekti();
        }

        protected void BtnDodaj_Click(object sender, EventArgs e)
        {
            int idDjelatnikZaDodavanje = int.Parse(ddlDjelatnici.SelectedValue);

            Djelatnik djelatnikDodaj = Repozitorij.GetDjelatnik(idDjelatnikZaDodavanje);

            privremeniDjelatnici.Add(djelatnikDodaj);
            LoadLbProjekti();
        }

        private void LoadLbProjekti()
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

            int idDjelatnikZaUklanjanje = int.Parse(lbDjelatnik.SelectedValue);

            var itemUkloni = privremeniDjelatnici.Find(x => x.IDDjelatnik == idDjelatnikZaUklanjanje);
            privremeniDjelatnici.Remove(itemUkloni);
            LoadLbProjekti();
        }
    }
}