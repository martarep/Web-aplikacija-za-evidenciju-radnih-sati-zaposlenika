using AZERS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace AZERS.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        [Authorize]
        [HttpGet]
        public ActionResult ShowPodaci()
        {

            var model = Repozitorij.GetKorisnik();
            model.DatumZaposlenja = DateTime.Parse(model.DatumZaposlenja.ToShortDateString());
            ViewData["TipDjelatnika"] = Repozitorij.GetTipDjelatnikaKorisnika();
            ViewData["Tim"] = Repozitorij.GetTimKorisnika();
            return View(model);
        }


        [HttpGet, Authorize]
        public ActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isPasswordChanged;

                try
                {

                    isPasswordChanged = WebSecurity.ChangePassword(WebSecurity.CurrentUserName, model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    isPasswordChanged = false;
                }


                if (isPasswordChanged)
                {
                    var korisnik = Repozitorij.GetKorisnik();
                    Repozitorij.ChangePassword(korisnik.IDDjelatnik, model.NewPassword);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("CurrentPassword", "Stara lozinka nije ispravno unesena.");
                }
            }

            return View();
        }
    }
}