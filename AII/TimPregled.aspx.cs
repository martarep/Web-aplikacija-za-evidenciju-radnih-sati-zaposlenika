using AII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AII
{
    public partial class TimPregled : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziTimove();
                PrikaziPodatkeOTimu();

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
        private void PrikaziPodatkeOTimu()
        {
            var timId = int.Parse(ddlTim.SelectedValue);

            Tim tim = Repozitorij.GetTim(timId);
            lblNaziv.Text = tim.Naziv;
            lblVoditelj.Text = Repozitorij.GetVoditeljTima(timId);
            lblDatumKreiranja.Text = tim.DatumKreiranja.ToShortDateString();
        

            PrikaziDjelatnikeTima(timId);
        }

        private void PrikaziDjelatnikeTima(int timId)
        {
            lbClanoviTima.DataSource = Repozitorij.GetDjelatniciTima(timId);
            lbClanoviTima.DataTextField = "ImePrezime";
            lbClanoviTima.DataValueField = "IDDjelatnik";
            lbClanoviTima.DataBind();
        }

        private void PrikaziTimove()
        {


            ddlTim.DataSource = Repozitorij.GetAktivniTimovi();
            ddlTim.DataTextField = "Naziv";
            ddlTim.DataValueField = "IDTim";
            ddlTim.DataBind();

        }


        protected void DdlTim_SelectedIndexChanged(object sender, EventArgs e) => PrikaziPodatkeOTimu();
        
    }


}
