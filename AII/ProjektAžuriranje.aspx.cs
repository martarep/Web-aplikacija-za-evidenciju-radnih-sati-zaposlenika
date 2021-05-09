using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class ProjektAžuriranje : System.Web.UI.Page
    {
        private static List<Djelatnik> privremeniDjelatnici;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    PrikaziDdlProjekte();
                PrikaziVoditeljIKlijent();
                PrikaziPodatkeOProjektu();
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

                var projektId = int.Parse(ddlProjekt.SelectedValue);
                privremeniDjelatnici = new List<Djelatnik>();
            privremeniDjelatnici.AddRange(Repozitorij.GetDjelatniciNaProjektu(projektId));
                PrikaziDjelatnike();
                RemoveDuplikatiIzDdlDjelatnici();

            }

            private void PrikaziVoditeljIKlijent()
            {
            var projektId = int.Parse(ddlProjekt.SelectedValue);
            ddlVoditeljProjekta.DataSource = Repozitorij.GetVoditeljiTima();
            ddlVoditeljProjekta.DataTextField = "ImePrezime";
            ddlVoditeljProjekta.DataValueField = "IDDjelatnik";
            ddlVoditeljProjekta.DataBind();

            ddlKlijent.DataSource = Repozitorij.GetSviKlijenti();
            ddlKlijent.DataTextField = "Naziv";
            ddlKlijent.DataValueField = "IDKlijent";
            ddlKlijent.DataBind();
            }

            private void PrikaziDjelatnike()
            {
                ddlDjelatnici.DataSource = Repozitorij.GetAktivniDjelatnici();
            ddlDjelatnici.DataTextField = "ImePrezime";
                ddlDjelatnici.DataValueField = "IDDjelatnik";
                ddlDjelatnici.DataBind();
            }

            private void PrikaziPodatkeOProjektu()
            {
                var projektId = int.Parse(ddlProjekt.SelectedValue);



                Projekt projekt = Repozitorij.GetProjekt(projektId);
                tbNaziv.Text = projekt.Naziv;
                tbDatumOtvaranja.Text = projekt.DatumOtvaranja.ToString("yyyy-MM-dd");
            ddlKlijent.SelectedValue = Repozitorij.GetKlijentProjektaId(projektId).ToString();
                ddlVoditeljProjekta.SelectedValue = Repozitorij.GetVoditeljProjektaId(projektId).ToString();
           
            PrikaziDjelatnikeNaProjektu(projektId);
            }

            private void PrikaziDjelatnikeNaProjektu(int projektId)
            {

                lbDjelatnici.DataSource = Repozitorij.GetDjelatniciNaProjektu(projektId);
            lbDjelatnici.DataTextField = "ImePrezime";
            lbDjelatnici.DataValueField = "IDDjelatnik";
            lbDjelatnici.DataBind();

            }


            private void PrikaziDdlProjekte()
            {

                ddlProjekt.DataSource = Repozitorij.GetAktivniProjekti();
            ddlProjekt.DataTextField = "Naziv";
            ddlProjekt.DataValueField = "IDProjekt";
            ddlProjekt.DataBind();

            }
            protected void DdlProjekt_SelectedIndexChanged(object sender, EventArgs e)
            {
            PrikaziVoditeljIKlijent();
                PrikaziPodatkeOProjektu();
                PopuniListu();
            }


            protected void BtnSpremi_Click(object sender, EventArgs e)
            {
                lblheader.Text = "Ažuriranje projekta";
                lbl_main.Text = "Jeste li sigurni da želite ažurirati projekt? ";
                ModalPopupExtender1.Show();

            }

            protected void BtnOdustani_Click(object sender, EventArgs e)
            {
                lblheader.Text = "Odustajanje od ažuriranja projekta";
                lbl_main.Text = "Jeste li sigurni da želite odustati od ažuriranja projekta?";
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

                int idDjelatnikzaUklanjanje = int.Parse(lbDjelatnici.SelectedValue);

                var itemUkloni = privremeniDjelatnici.Find(x => x.IDDjelatnik == idDjelatnikzaUklanjanje);

                privremeniDjelatnici.Remove(itemUkloni);
                LoadLbDjelatnici();

            }

            protected void BtnDaSpremi_Click(object sender, EventArgs e)
            {

                if (lblheader.Text == "Ažuriranje projekta")
                {
                    Projekt ažuriraniProjekt = new Projekt();
                ažuriraniProjekt.IDProjekt = int.Parse(ddlProjekt.SelectedValue);
                ažuriraniProjekt.Naziv = tbNaziv.Text;
                ažuriraniProjekt.DatumOtvaranja = DateTime.Parse(tbDatumOtvaranja.Text);
                ažuriraniProjekt.KlijentID =int.Parse(ddlKlijent.SelectedValue);
                ažuriraniProjekt.VoditeljProjektaID = int.Parse(ddlVoditeljProjekta.SelectedValue);
                Djelatnik voditelj = Repozitorij.GetDjelatnik(ažuriraniProjekt.VoditeljProjektaID);
                if (!privremeniDjelatnici.Contains(voditelj))
                {
                    privremeniDjelatnici.Add(voditelj);
                }
                Repozitorij.UpdateProjekt(ažuriraniProjekt);
                    ModalPopupExtender1.Hide();
                    ddlProjekt.SelectedValue = ažuriraniProjekt.IDProjekt.ToString();

                    AžurirajDjelatnikeProjekta(ažuriraniProjekt.IDProjekt);
                    PrikaziPodatkeOProjektu();
                    PrikaziDdlProjekte();
                    PopuniListu();
                }
                else
                {
                    var ddlID = ddlProjekt.SelectedValue;
                    ModalPopupExtender1.Hide();

                    PrikaziPodatkeOProjektu();
                    PopuniListu();
                    PrikaziDdlProjekte();
                    ddlProjekt.SelectedValue = ddlID;


                }

            }

            private void AžurirajDjelatnikeProjekta(int idProjekt)
            {

                List<Djelatnik> djelatniciNaProjektu = new List<Djelatnik>();
                djelatniciNaProjektu.AddRange(Repozitorij.GetDjelatniciNaProjektu(idProjekt));
                List<Djelatnik> djelatniciZaDodati = privremeniDjelatnici;
                List<Djelatnik> djelatniciZaUkloniti = new List<Djelatnik>();
                List<Djelatnik> djelatniciNaProjektimaKojiOstaju = new List<Djelatnik>();

                foreach (Djelatnik djelatnik in djelatniciNaProjektu)
                {
                    var djelatnikKojiOstaje = privremeniDjelatnici.Find(x => x.IDDjelatnik == djelatnik.IDDjelatnik);
                    if (djelatnikKojiOstaje != null)
                    {
                        djelatniciNaProjektimaKojiOstaju.Add(djelatnikKojiOstaje);
                    }
                }
                foreach (Djelatnik djelatnik in djelatniciNaProjektu)
                {
                    var djelatnikKojiNeOstaje = djelatniciNaProjektimaKojiOstaju.Find(x => x.IDDjelatnik == djelatnik.IDDjelatnik);
                    if (djelatnikKojiNeOstaje == null)
                    {
                        djelatniciZaUkloniti.Add(djelatnik);
                    }
                }


                foreach (Djelatnik djelatnik in djelatniciNaProjektu)
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
                        Repozitorij.InsertProjektDjelatnik(djelatnik.IDDjelatnik, idProjekt);
                    }
                }


                if (djelatniciZaUkloniti.Count != 0)
                {

                    foreach (Djelatnik djelatnik in djelatniciZaUkloniti)
                    {
                    if (djelatnik.IDDjelatnik == int.Parse(ddlVoditeljProjekta.SelectedValue))
                    {
                        lblError.Text = "Nije moguće obrisati djelatnika koji je voditelj tima";
                    }
                    else
                    {
                        Repozitorij.DeleteProjektDjelatnik(djelatnik.IDDjelatnik, idProjekt);
                    }
                      
                    }
                }

            }
        }
    }