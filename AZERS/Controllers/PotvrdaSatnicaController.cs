using AZERS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AZERS.Controllers
{
    public class PotvrdaSatnicaController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult ShowPodaci()
        {
            var model = Repozitorij.GetPoslaneSatnice(DateTime.Now.Date);
            ViewData["datum"] = DateTime.Now;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ShowPodaci(DateTime datum)
        {
            var model = Repozitorij.GetPoslaneSatnice(datum);
            ViewData["datum"] = datum;
            return View(model);
        }

        public ActionResult Detalji(DateTime DatumSatnica, int IDDjelatnik)
        {

            var model = Repozitorij.GetProjektiEvidencija(IDDjelatnik, DatumSatnica);
            ViewData["ImePrezime"] = Repozitorij.GetDjelatnik(IDDjelatnik).Ime + " " + Repozitorij.GetDjelatnik(IDDjelatnik).Prezime;

            return View(model);

        }
        public ActionResult Potvrdi(DateTime DatumSatnica, int IDDjelatnik, string Status)
        {

            Repozitorij.ChangeStatusSatnice(DatumSatnica, IDDjelatnik, Status);

            return new HttpStatusCodeResult(HttpStatusCode.OK);


        }
        public ActionResult Vrati(DateTime DatumSatnica, int IDDjelatnik, string Status)
        {

            Repozitorij.ChangeStatusSatnice(DatumSatnica, IDDjelatnik, Status);

            return new HttpStatusCodeResult(HttpStatusCode.OK);


        }

    }
}