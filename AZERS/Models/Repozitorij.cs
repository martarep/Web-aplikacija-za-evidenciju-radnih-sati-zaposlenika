using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AZERS.Models
{
    public static class Repozitorij
    {
        private static PRA_RWA_Baza_FinEntities1 db = new PRA_RWA_Baza_FinEntities1();

        public static Djelatnik GetKorisnik()
        {

            ApplicationUser korisnik = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());
            string email = korisnik.Email;

            Djelatnik djelatnik = db.Djelatniks.Where(d => email == d.Email).First();

            return djelatnik;
        }

        internal static string GetTimKorisnika()
        {
            Djelatnik djelatnik = GetKorisnik();

            string tim = djelatnik.Tim.Naziv;

            return tim;
        }

        internal static string GetTipDjelatnikaKorisnika()
        {

            Djelatnik djelatnik = GetKorisnik();

            string tipDjelatnika = djelatnik.TipDjelatnika.Naziv;

            return tipDjelatnika;
        }

        

        internal static IEnumerable<PoslanaSatnica> GetPoslaneSatnice(DateTime datumSatnice)
        {
            List<PoslanaSatnica> poslaneSatnice = new List<PoslanaSatnica>();

            
            foreach (var djelatnik in db.Djelatniks.ToList())
            {
                List<Satnica> satniceCekanje = new List<Satnica>();
                List<int> idProjekata = new List<int>();
                var idProjektiDjelatnika = djelatnik.ProjektDjelatniks.ToList();

                foreach (var projektDjelatnik in idProjektiDjelatnika)
                {
                    idProjekata.Add(projektDjelatnik.ProjektID);
                }
              
                foreach (var id in idProjekata)
                {
                    Satnica satnica = FindSatnica(djelatnik.IDDjelatnik, id, datumSatnice);
                    if (satnica.StatusSatnice == "Čekanje")
                    {
                        satniceCekanje.Add(satnica);
                    }

                }
                if (satniceCekanje.Count >0)
                {
                    Satnica satnic = satniceCekanje[0];
                    
                    PoslanaSatnica poslanaSatnica = new PoslanaSatnica
                    {
                        IDDjelatnik = djelatnik.IDDjelatnik,
                        DatumSatnice = datumSatnice,
                        DatumSlanja = (DateTime)satnic.DatumSlanjaSatnice,
                        VrijemeSlanja = (TimeSpan)satnic.VrijemeSlanjaSatnice,
                        ImePrezime = djelatnik.Ime + " " + djelatnik.Prezime
                    };
                    poslaneSatnice.Add(poslanaSatnica);
                }
             
               
            }

            return poslaneSatnice;
        }




        public static Djelatnik GetDjelatnik(int idDjelatnik)
        {
            Djelatnik djelatnik = db.Djelatniks.Where(d => idDjelatnik == d.IDDjelatnik).First();

            return djelatnik;
        }
        public static TimeSpan StripMilliseconds( TimeSpan time)
        {
            return new TimeSpan(time.Days, time.Hours, time.Minutes, time.Seconds);
        }
        internal static void SaveChangesSatnica(List<ProjektEvidencija> projektiEvidencija, int idDjelatnik, DateTime datumSatnice)
        {
            foreach (var projekt in projektiEvidencija)
            {
                Satnica satnica = FindSatnica(idDjelatnik, projekt.IDProjekt, datumSatnice);
                satnica.BrojZabiljezenihSati = projekt.BrojZabiljezenihSati;
                satnica.BrojRedovnihSati = projekt.BrojRedovnihSati;
                satnica.BrojPrekovremenihSati = projekt.BrojPrekovremenihSati;
                satnica.StopVrijeme= TimeSpan.Parse("00:00:00");
                satnica.StartVrijeme= TimeSpan.Parse("00:00:00");
                db.SaveChanges();
            }
           
        }

        public static Satnica FindSatnica(int idDjelatnik, int idProjekt,  DateTime datumSatnice)
        {
           List< Satnica> satnice = db.Satnicas.Where(p => p.DjelatnikID == idDjelatnik).ToList();
            Satnica trazenaSatnica = new Satnica();
            foreach(var satnica in satnice)
            {
                if(satnica.ProjektID == idProjekt && satnica.DatumSatnice.Date == datumSatnice.Date)
                {
                    trazenaSatnica = satnica;
                }
            }

            return trazenaSatnica;
        }

        internal static void ChangeStatusIDatumSlanjaSatnice(DateTime datumSatnica, int iDDjelatnik, string status, DateTime datumSlanja)
        {
            Djelatnik djelatnik = db.Djelatniks.Where(d => iDDjelatnik == d.IDDjelatnik).First();
            List<int> idProjekata = new List<int>();
            var idProjektiDjelatnika = djelatnik.ProjektDjelatniks.ToList();
            foreach (var projektDjelatnik in idProjektiDjelatnika)
            {
                idProjekata.Add(projektDjelatnik.ProjektID);
            }

            foreach (var id in idProjekata)
            {
                Satnica satnica = FindSatnica(iDDjelatnik, id, datumSatnica);
                satnica.StatusSatnice = status;
                satnica.DatumSlanjaSatnice = datumSlanja;
                satnica.VrijemeSlanjaSatnice = datumSlanja.TimeOfDay;
                db.SaveChanges();
            }
   
        }


        internal static void ChangeStatusSatnice(DateTime datumSatnica, int iDDjelatnik, string status)
        {
            Djelatnik djelatnik = db.Djelatniks.Where(d => iDDjelatnik == d.IDDjelatnik).First();
            List<int> idProjekata = new List<int>();
            var idProjektiDjelatnika = djelatnik.ProjektDjelatniks.ToList();
            foreach (var projektDjelatnik in idProjektiDjelatnika)
            {
                idProjekata.Add(projektDjelatnik.ProjektID);
            }

            foreach (var id in idProjekata)
            {
                Satnica satnica = FindSatnica(iDDjelatnik, id, datumSatnica);
                satnica.StatusSatnice = status;
                db.SaveChanges();
            }

        }

        internal static void SetStartVrijeme(int idDjelatnik, int idProjekt, TimeSpan startVrijeme, DateTime datumSatnice)
        {
            Satnica satnica = FindSatnica(idDjelatnik, idProjekt, datumSatnice);
            db.Satnicas.Find(satnica.IDSatnica).StartVrijeme = startVrijeme;
            db.SaveChanges();
        }

        internal static void SetStopVrijeme(int idDjelatnik, int idProjekt, TimeSpan stopVrijeme, DateTime datumSatnice)
        {
            Satnica satnica = FindSatnica(idDjelatnik, idProjekt, datumSatnice);
           db.Satnicas.Find(satnica.IDSatnica).StopVrijeme = stopVrijeme;
            db.SaveChanges();
        }

        public static ProjektEvidencijaVM GetProjektiEvidencija(int idDjelatnik, DateTime datumSatnice)
        {
            Djelatnik djelatnik = db.Djelatniks.Where(d => idDjelatnik == d.IDDjelatnik).First();

            var idProjektiDjelatnika = djelatnik.ProjektDjelatniks.ToList();
            List<Projekt> projekti = new List<Projekt>();
            List<ProjektEvidencija> projektiEvidencija = new List<ProjektEvidencija>();
            string statusSatnice ="";
            TimeSpan ukupnoRS = new TimeSpan();
            TimeSpan ukupnoPS = new TimeSpan();
            foreach (var projektDjelatnik in idProjektiDjelatnika)
            {
                var projekt = db.Projekts.Find(projektDjelatnik.ProjektID);
                projekti.Add(projekt); 
            }

            foreach (var projekt in projekti)
            {
                ProjektEvidencija projektEvidencija = new ProjektEvidencija();
                projektEvidencija.NazivProjekta = projekt.Naziv;
                projektEvidencija.IDProjekt = projekt.IDProjekt;

                Satnica satnica = new Satnica();
                satnica = GetSatnica(idDjelatnik, datumSatnice, djelatnik, projekt, satnica);

                if (satnica.BrojRedovnihSati != null)
                {
                    projektEvidencija.BrojRedovnihSati = (TimeSpan)satnica.BrojRedovnihSati;
                
                    ukupnoRS += (TimeSpan) satnica.BrojRedovnihSati;
                   
                }
                if (satnica.BrojPrekovremenihSati != null)
                {
                  
                    projektEvidencija.BrojPrekovremenihSati = (TimeSpan)satnica.BrojPrekovremenihSati;
                 
                    ukupnoPS += (TimeSpan)satnica.BrojPrekovremenihSati;
                }
                if ( satnica.BrojZabiljezenihSati != null)
                {
                    projektEvidencija.BrojZabiljezenihSati = (TimeSpan)satnica.BrojZabiljezenihSati;
 
                }


                statusSatnice = satnica.StatusSatnice;

                projektiEvidencija.Add(projektEvidencija);
            }


            ProjektEvidencijaVM projektiEvidencijaVM = new ProjektEvidencijaVM { IdDjelatnik = idDjelatnik, ProjektiEvidencija = projektiEvidencija, DatumSatnice= datumSatnice , StatusSatnice =statusSatnice, UkupnoPrekovremenihSati= ukupnoPS,UkupnoRedovnihSati=ukupnoRS };

            return projektiEvidencijaVM;
        }

        private static Satnica GetSatnica(int idDjelatnik, DateTime datumSatnice, Djelatnik djelatnik, Projekt projekt, Satnica satnica)
        {
            try
            {
                satnica = projekt.Satnicas.Where(s => s.DatumSatnice.Date == datumSatnice.Date).First();
            }
            catch (Exception)
            {
                satnica.DjelatnikID = idDjelatnik;
                satnica.DatumSatnice = datumSatnice.Date;
                satnica.StatusSatnice = "Evidentiranje";
                satnica.ProjektID = projekt.IDProjekt;
                satnica.KlijentID = projekt.KlijentID;
                satnica.TimID = (int)djelatnik.TimID;
                db.Satnicas.Add(satnica);
                db.SaveChanges();

            }

            return satnica;
        }

        internal static void ChangePassword(int iDDjelatnik, string newPassword)
        {
            var korisnik = db.Djelatniks.Find(iDDjelatnik);
            korisnik.Lozinka = newPassword;
            db.SaveChanges();
        }
    }

}