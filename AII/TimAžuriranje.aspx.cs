using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class TimAžuriranje : System.Web.UI.Page
    {
        private static List<Djelatnik> privremeniDjelatnici;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziTim();
                PrikaziPodatkeOTimu();
                PrikaziVoditeljTima();
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

            int timId = int.Parse(ddlTim.SelectedValue);
             privremeniDjelatnici= new List<Djelatnik>();
            privremeniDjelatnici.AddRange(Repozitorij.GetDjelatniciTima(timId));
            PrikaziDjelatnike();
            RemoveDuplikatiIzDdlDjelatnici();

        }

        private void PrikaziVoditeljTima()
        {
            int timId = int.Parse(ddlTim.SelectedValue);
            ddlVoditeljTima.DataSource = Repozitorij.GetDjelatniciTima(timId);
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

        private void PrikaziPodatkeOTimu()
        {
            int timId = int.Parse(ddlTim.SelectedValue);

            Tim tim = Repozitorij.GetTim(timId);
            tbNaziv.Text = tim.Naziv;
            tbDatumKreiranja.Text = tim.DatumKreiranja.ToString("yyyy-MM-dd");
            PrikaziVoditeljTima();
            if (Repozitorij.GetVoditeljTimaID(timId) != 0)
            {
                ddlVoditeljTima.SelectedValue = Repozitorij.GetVoditeljTimaID(timId).ToString();
            }
           
     
            PrikaziDjelatnikeTima(timId);
        }

        private void PrikaziDjelatnikeTima(int timId)
        {

            lbDjelatnici.DataSource = Repozitorij.GetDjelatniciTima(timId);
            lbDjelatnici.DataTextField = "ImePrezime";
            lbDjelatnici.DataValueField = "IDDjelatnik";
            lbDjelatnici.DataBind();

        }


        private void PrikaziTim()
        {

            ddlTim.DataSource = Repozitorij.GetAktivniTimovi();
            ddlTim.DataTextField = "Naziv";
            ddlTim.DataValueField = "IDTim";
            ddlTim.DataBind();

        }
        protected void DdlTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziPodatkeOTimu();
            PopuniListu();
        }


        protected void BtnSpremi_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Ažuriranje tima";
            lbl_main.Text = "Jeste li sigurni da želite ažurirati tim? ";
            ModalPopupExtender1.Show();

        }

        protected void BtnOdustani_Click(object sender, EventArgs e)
        {
            lblheader.Text = "Odustajanje od ažuriranja tima";
            lbl_main.Text = "Jeste li sigurni da želite odustati od ažuriranja tima?";
            ModalPopupExtender1.Show();

        }

        protected void BtnDodaj_Click(object sender, EventArgs e)
        {

            int idDjelatnikZaDodavanje = int.Parse(ddlDjelatnici.SelectedValue);

            Djelatnik djelatnikDodaj = Repozitorij.GetDjelatnik(idDjelatnikZaDodavanje);

            privremeniDjelatnici.Add(djelatnikDodaj);
            LoadLbDjelatnici();
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

        private void LoadLbDjelatnici()
        {

            lbDjelatnici.DataSource = privremeniDjelatnici;
            lbDjelatnici.DataTextField = "ImePrezime";
            lbDjelatnici.DataValueField = "IDDjelatnik";
            lbDjelatnici.DataBind();
            PrikaziDjelatnike();
            RemoveDuplikatiIzDdlDjelatnici();
        }

        protected void BtnUkloni_Click(object sender, EventArgs e)
        {

            if (lbDjelatnici.SelectedValue == string.Empty)
            {
                return;
            }


            List<Djelatnik> djelatniciTima = new List<Djelatnik>();
            djelatniciTima.AddRange(Repozitorij.GetDjelatniciTima(int.Parse(ddlTim.SelectedValue)));


            int idDjelatnikZaUklanjanje = int.Parse(lbDjelatnici.SelectedValue);

            var itemUkloni = privremeniDjelatnici.Find(x => x.IDDjelatnik == idDjelatnikZaUklanjanje);
            var itemPostoji = new Djelatnik();
            foreach (Djelatnik djelatnik in djelatniciTima)
            {
                itemPostoji = djelatniciTima.Find(x => x.IDDjelatnik == idDjelatnikZaUklanjanje);

            }
            if (itemPostoji != null)
            {
                ModalPopupExtender2.Show();
            }
            else
            {
                privremeniDjelatnici.Remove(itemUkloni);
                LoadLbDjelatnici();
            }


        }

        protected void BtnDaSpremi_Click(object sender, EventArgs e)
        {

            if (lblheader.Text == "Ažuriranje tima")
            {
                Tim ažuriraniTim = new Tim();
                ažuriraniTim.IDTim = int.Parse(ddlTim.SelectedValue);
                ažuriraniTim.Naziv = tbNaziv.Text;
                ažuriraniTim.DatumKreiranja = DateTime.Parse(tbDatumKreiranja.Text);
              int voditeljTimaId =  int.Parse(ddlVoditeljTima.SelectedValue);
                int trenutniVoditeljTimaId = Repozitorij.GetVoditeljTimaID(int.Parse(ddlTim.SelectedValue));
                int tipdjelatnikaVTId = 2;
                int tipdjelatnikaZId = 3;
                Repozitorij.UpdateTipDjelatika(ažuriraniTim.IDTim,trenutniVoditeljTimaId, tipdjelatnikaZId);
                Repozitorij.UpdateTipDjelatika(ažuriraniTim.IDTim,voditeljTimaId, tipdjelatnikaVTId);
          
               
                Repozitorij.UpdateTim(ažuriraniTim);
                ModalPopupExtender1.Hide();
                ddlTim.SelectedValue = ažuriraniTim.IDTim.ToString();

                AžurirajDjelatnikeTima(ažuriraniTim.IDTim);
                PrikaziPodatkeOTimu();
                PrikaziTim();
                PopuniListu();
            }
            else
            {
                var ddlID = ddlTim.SelectedValue;
                ModalPopupExtender1.Hide();

                PrikaziPodatkeOTimu();
                PopuniListu();
                PrikaziTim();
                ddlTim.SelectedValue = ddlID;


            }

        }

        private void AžurirajDjelatnikeTima(int idTim)
        {

            List<Djelatnik> djelatniciTima = new List<Djelatnik>();
            djelatniciTima.AddRange(Repozitorij.GetDjelatniciTima(idTim));
            List<Djelatnik> djelatniciZaDodati = privremeniDjelatnici;
            List<Djelatnik> djelatniciZaUkloniti = new List<Djelatnik>();
            List<Djelatnik> djelatniciTimaKojiOstaju = new List<Djelatnik>();

            foreach (Djelatnik djelatnik in djelatniciTima)
            {
                var projektKojiOstaje = privremeniDjelatnici.Find(x => x.IDDjelatnik == djelatnik.IDDjelatnik);
                if (projektKojiOstaje != null)
                {
                    djelatniciTimaKojiOstaju.Add(projektKojiOstaje);
                }
            }
            foreach (Djelatnik djelatnik in djelatniciTima)
            {
                var djelatnikKojiNeOstaje = djelatniciTimaKojiOstaju.Find(x => x.IDDjelatnik == djelatnik.IDDjelatnik);
                if (djelatnikKojiNeOstaje == null)
                {
                    djelatniciZaUkloniti.Add(djelatnik);
                }
            }


            foreach (Djelatnik djelatnik in djelatniciTima)
            {
                var itemZaBrisanje = djelatniciZaDodati.Find(x => x.IDDjelatnik == djelatnik.IDDjelatnik);
                if (itemZaBrisanje != null)
                {
                    djelatniciZaDodati.Remove(itemZaBrisanje);
                }

            }

            if (djelatniciZaDodati.Count != 0)
            {
                foreach (Djelatnik djelatnik in djelatniciZaDodati)
                {
                    Repozitorij.UpdateDjelatnikTimId(idTim, djelatnik.IDDjelatnik);
                }
            }

            if (djelatniciZaUkloniti.Count != 0)
            {
                foreach (Djelatnik djelatnik in djelatniciZaUkloniti)
                {
                    Repozitorij.UpdateDjelatnikTimId(0, djelatnik.IDDjelatnik);
                }
            }

        }
    }
}
