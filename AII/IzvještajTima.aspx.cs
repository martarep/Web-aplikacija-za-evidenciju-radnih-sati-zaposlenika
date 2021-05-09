using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class IzvještajTima : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPrijava();
            if (!IsPostBack)
            {
                PrikaziDdlIDatume();
                PopuniTablicu();
            }
        }

        private void PopuniTablicu()
        {
            idTim.Text = ddlTim.SelectedItem.ToString();
            idDatumOd.Text = tbDatumOd.Text;
            idDatumDo.Text = tbDatumDo.Text;

            idtbody.InnerHtml = "";

            DateTime datumOd = DateTime.Parse(tbDatumOd.Text);
            DateTime datumDo = DateTime.Parse(tbDatumDo.Text);

            var razlikaDana = (datumDo - datumOd).TotalDays;
            List<DateTime> datumi = new List<DateTime>();

            for (int i = 1; i < razlikaDana; i++)
            {
                datumi.Add(datumOd);
                datumOd.AddDays(1);
            }


            foreach (var item in Repozitorij.GetNazivProjektiTima(int.Parse(ddlTim.SelectedValue)))
            {
                TimeSpan brRS = new TimeSpan();
                TimeSpan brPS = new TimeSpan();
                TimeSpan uRS = new TimeSpan();
                foreach (var datum in datumi)
                {
                     brRS = Repozitorij.GetRedovniSatiTimaNaProjektu(item.IDProjekt, int.Parse(ddlTim.SelectedValue), datum);
                     brPS = Repozitorij.GetPrekovremeniSatiTimaNaProjektu(item.IDProjekt, int.Parse(ddlTim.SelectedValue), datum);
                     uRS = brRS + brPS;
                }
               

                idtbody.InnerHtml += $"<tr><td></td><td class='tabledata'>{item.Naziv}</td><td class='tabledata'>{brRS}</td> <td class='tabledata'>{brPS}</td><td class='tabledata'>{uRS}</td><td></td></tr>";

            }

        }

        private void PrikaziDdlIDatume()
        {

            ddlTim.DataSource = Repozitorij.GetAktivniTimovi(); 
            ddlTim.DataTextField = "Naziv";
            ddlTim.DataValueField = "IDTim";
            ddlTim.DataBind();

            tbDatumOd.Text = DateTime.Now.ToString("yyyy-MM-dd");
            tbDatumDo.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        private void CheckPrijava()
        {
            Djelatnik korisnik = (Djelatnik)Session["korisnik"];

            if (korisnik == null)
            {
                Response.Redirect("Prijava.aspx");
            }

        }


        protected void BtnPrikazi_Click(object sender, EventArgs e)
        {
            PopuniTablicu();
        }

    }
}