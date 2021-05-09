using AZERS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AZERS.Controllers
{
    public class EvidencijaController : Controller
    {
     
        [Authorize]
        [HttpGet]
        public ActionResult ShowPodaci()
        {
         var model =   Repozitorij.GetProjektiEvidencija(Repozitorij.GetKorisnik().IDDjelatnik,DateTime.Now);
            model.SaveOrDate = "date";
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public ActionResult ShowPodaci(ProjektEvidencijaVM projektiEvidencijaVM)
        {
            if ( projektiEvidencijaVM.SaveOrDate == "save")
            {

              Repozitorij.SaveChangesSatnica(projektiEvidencijaVM.ProjektiEvidencija, projektiEvidencijaVM.IdDjelatnik, projektiEvidencijaVM.DatumSatnice);
              var model =  Repozitorij.GetProjektiEvidencija(Repozitorij.GetKorisnik().IDDjelatnik, projektiEvidencijaVM.DatumSatnice);
                return View(model);
            }
            else
            {
                var model = Repozitorij.GetProjektiEvidencija(Repozitorij.GetKorisnik().IDDjelatnik, projektiEvidencijaVM.DatumSatnice);
                return View(model);
            }

            
        }
        public ActionResult Spremi(DateTime DatumSatnica, int IDDjelatnik, string ProjektiEvidencija)
        {
            ProjektEvidencijaVM projektiEvidencijaVM = new ProjektEvidencijaVM();
            projektiEvidencijaVM.ProjektiEvidencija = JsonConvert.DeserializeObject<List<ProjektEvidencija>>(ProjektiEvidencija);
            projektiEvidencijaVM.DatumSatnice = DatumSatnica;
            projektiEvidencijaVM.IdDjelatnik = IDDjelatnik;



                Repozitorij.SaveChangesSatnica(projektiEvidencijaVM.ProjektiEvidencija, projektiEvidencijaVM.IdDjelatnik, projektiEvidencijaVM.DatumSatnice);
                return new HttpStatusCodeResult(HttpStatusCode.OK);


        }
        public ActionResult Predaj(DateTime DatumSatnica, int IDDjelatnik , string Status, DateTime DatumSlanja)
        {

            Repozitorij.ChangeStatusIDatumSlanjaSatnice(DatumSatnica, IDDjelatnik,Status, DatumSlanja);

            return new HttpStatusCodeResult(HttpStatusCode.OK);


        }
        public ActionResult Start(SatnicaPodaci podaci)
        {
          
                Repozitorij.SetStartVrijeme(podaci.IDDjelatnik, podaci.IDProjekt, podaci.Vrijeme, podaci.DatumSatnica);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
          
            //catch (Exception)
            //{

            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
                    
        }

        public ActionResult Stop(SatnicaPodaci podaci)
        {
            try
            {
                Repozitorij.SetStopVrijeme(podaci.IDDjelatnik, podaci.IDProjekt, podaci.Vrijeme, podaci.DatumSatnica);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}