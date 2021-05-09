using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;


namespace AII.Models
{
    public class Repozitorij
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static IEnumerable<Djelatnik> GetAktivniDjelatnici()
        {
            var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "GetAktivniDjelatnici").Tables[0];

            foreach (DataRow row in tblDjelatnici.Rows)
            {
                yield return new Djelatnik
                {

                    IDDjelatnik = (int)row["IDDjelatnik"],
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    Lozinka = row["Lozinka"].ToString(),
                    Aktivan = row["Aktivan"].ToString(),
                    DatumZaposlenja = (DateTime)row["DatumZaposlenja"],
                    TipDjelatnikaID = (int)row["TipDjelatnikaID"],
                    Jezik = row["Jezik"].ToString(),
                    ImePrezime = row["Ime"].ToString() + " " + row["Prezime"].ToString()

                };

            }

        }

        internal static IEnumerable<Projekt> GetNazivProjektiKlijenta(int idKlijent)
        {
            var tbl = SqlHelper.ExecuteDataset(cs, "GetNazivProjektiKlijenta", idKlijent).Tables[0];

            foreach (DataRow row in tbl.Rows)
            {

                yield return new Projekt
                {
                    IDProjekt = (int)row["IDProjekt"],
                    Naziv = row["Naziv"].ToString()
                };


            }
        }

        internal static TimeSpan GetSatiNaProjektuKlijenta(int idProjekt, int idKlijent, DateTime datum)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetSatiNaProjektuKlijenta", idProjekt, idKlijent, datum).Tables[0];
            DataRow row = tbl.Rows[0];

            return (TimeSpan)row["BrojSati"];
        }

        internal static IEnumerable<Projekt> GetNazivProjektiTima(int idTim)
        {
            var tbl = SqlHelper.ExecuteDataset(cs, "GetNazivProjektiTima", idTim).Tables[0];

            foreach (DataRow row in tbl.Rows)
            {

                yield return new Projekt
                {
                    IDProjekt = (int)row["IDProjekt"],
                    Naziv = row["Naziv"].ToString()
                };
              

            }
        }


        internal static TimeSpan GetPrekovremeniSatiTimaNaProjektu(int idProjekt, int idTim, DateTime datumSatnice)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetPrekovremeniSatiTimaNaProjektu", idProjekt,idTim,datumSatnice).Tables[0];
            DataRow row = tbl.Rows[0];

            return (TimeSpan)row["BrojPrekovremenihSati"];
        }
        internal static TimeSpan GetRedovniSatiTimaNaProjektu(int idProjekt, int idTim, DateTime datumSatnice)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetRedovniSatiTimaNaProjektu", idProjekt, idTim, datumSatnice).Tables[0];
            DataRow row = tbl.Rows[0];

            return (TimeSpan)row["BrojRedovnihSati"];
        }


        internal static void UpdateDjelatnikJezik(int iDDjelatnik, string jezik)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateDjelatnikJezik", iDDjelatnik, jezik);
        }

        internal static int GetPrijavaRezultat(string email, string lozinka)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetPrijavaRezultat", email, lozinka).Tables[0];
            DataRow row = tbl.Rows[0];

            return (int)row["Rezultat"];
        }

        internal static Djelatnik GetPrijavaDjelatnik(string email, string lozinka)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetPrijavaDjelatnik", email,lozinka).Tables[0];
            DataRow row = tbl.Rows[0];
            return new Djelatnik
            {

                IDDjelatnik = (int)row["IDDjelatnik"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                Email = row["Email"].ToString(),
                Lozinka = row["Lozinka"].ToString(),
                Aktivan = row["Aktivan"].ToString(),
                DatumZaposlenja = (DateTime)row["DatumZaposlenja"],
                TipDjelatnikaID = (int)row["TipDjelatnikaID"],
                Jezik = row["Jezik"].ToString(),
                ImePrezime = row["Ime"].ToString() + " " + row["Prezime"].ToString()

            };
        }

        internal static string GetAktivnostKlijenta(int idKlijent)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetAktivnostKlijenta", idKlijent).Tables[0];
            DataRow row = tbl.Rows[0];

            return row["Aktivan"].ToString();
        }

        internal static IEnumerable<Projekt> GetProjektiKlijenta(int klijentId)
        {
            var tbl = SqlHelper.ExecuteDataset(cs, "GetProjektiKlijenta",klijentId).Tables[0];

            foreach (DataRow row in tbl.Rows)
            {
                yield return new Projekt
                {
                    IDProjekt = (int)row["IDProjekt"],
                    Naziv = row["Naziv"].ToString(),
                    KlijentID = (int)row["KlijentID"],
                    VoditeljProjektaID = (int)row["VoditeljProjektaID"],
                    Aktivan = row["Aktivan"].ToString(),
                    DatumOtvaranja = (DateTime)row["DatumOtvaranja"],

                };

            }
        }

        internal static void UpdateAktivnostKlijenta(int idKlijent, string status)
        {
           SqlHelper.ExecuteNonQuery(cs, "UpdateAktivnostKlijenta", idKlijent, status);
        }

        internal static int GetKlijentId(string naziv)
        {
           
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetKlijentId", naziv).Tables[0];
            DataRow row = tbl.Rows[0];

            return (int)row["IDKlijent"];
        }

        internal static int InsertKlijent(Klijent klijent)
        {
           return  SqlHelper.ExecuteNonQuery(cs, "InsertKlijent", klijent.Naziv);
          
        }

        internal static Klijent GetKlijent(int klijentId)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetKlijent", klijentId).Tables[0];
            DataRow row = tbl.Rows[0];
           
               return new Klijent
                {
                    Naziv = row["Naziv"].ToString(),
                    IDKlijent = (int)row["IDKlijent"],
                    Aktivan = row["Aktivan"].ToString()
                };
       
        }

        internal static IEnumerable<Projekt> GetSviProjekti()
        {
            var tbl = SqlHelper.ExecuteDataset(cs, "GetSviProjekti").Tables[0];

            foreach (DataRow row in tbl.Rows)
            {
                yield return new Projekt
                {
                    IDProjekt=  (int)row["IDProjekt"],
                    Naziv = row["Naziv"].ToString(),
                    KlijentID = (int)row["KlijentID"],
                  VoditeljProjektaID = (int)row["VoditeljProjektaID"],
                    Aktivan = row["Aktivan"].ToString(),
                    DatumOtvaranja = (DateTime)row["DatumOtvaranja"],

                };

            }
        }

        internal static string GetAktivnostProjekta(int idProjekt)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetAktivnostProjekta", idProjekt).Tables[0];
            DataRow row = tbl.Rows[0];

            return row["Aktivan"].ToString();
        }

        internal static IEnumerable<Djelatnik> GetVoditeljiTima()
        {
            var tbl = SqlHelper.ExecuteDataset(cs, "GetVoditeljiTima").Tables[0];

            foreach (DataRow row in tbl.Rows)
            {
                yield return new Djelatnik
                {

                    IDDjelatnik = (int)row["IDDjelatnik"],
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    Lozinka = row["Lozinka"].ToString(),
                    Aktivan = row["Aktivan"].ToString(),
                    DatumZaposlenja = (DateTime)row["DatumZaposlenja"],
                    TipDjelatnikaID = (int)row["TipDjelatnikaID"],
                    Jezik = row["Jezik"].ToString(),
                    ImePrezime = row["Ime"].ToString() + " " + row["Prezime"].ToString()

                };

            }
        }

        internal static void UpdateAktivnostProjekta(int idProjekt, string status)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateAktivnostProjekta", idProjekt, status);
        }

        internal static IEnumerable<Djelatnik> GetDjelatniciNaProjektuVoditeljiTima(int projektId)
        {
            var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "GetDjelatniciNaProjektuVoditeljiTima", projektId).Tables[0];

            foreach (DataRow row in tblDjelatnici.Rows)
            {
                yield return new Djelatnik
                {

                    IDDjelatnik = (int)row["IDDjelatnik"],
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    Lozinka = row["Lozinka"].ToString(),
                    Aktivan = row["Aktivan"].ToString(),
                    DatumZaposlenja = (DateTime)row["DatumZaposlenja"],
                    TipDjelatnikaID = (int)row["TipDjelatnikaID"],
                    Jezik = row["Jezik"].ToString(),
                    ImePrezime = row["Ime"].ToString() + " " + row["Prezime"].ToString()

                };

            }
        }

        internal static void UpdateKlijent(Klijent ažuriraniKlijent)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateKlijent", ažuriraniKlijent.IDKlijent, ažuriraniKlijent.Naziv);
        }

        internal static void InsertProjekt(Projekt projekt)
        {
            SqlHelper.ExecuteNonQuery(cs, "InsertProjekt", projekt.Naziv,projekt.KlijentID,projekt.DatumOtvaranja,projekt.VoditeljProjektaID);
        }

        internal static int GetProjektId(Projekt projekt)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetProjektId", projekt.Naziv,projekt.KlijentID,projekt.DatumOtvaranja,projekt.VoditeljProjektaID).Tables[0];
            DataRow row = tbl.Rows[0];

            return (int)row["IDProjekt"];
        }

        internal static IEnumerable<Klijent> GetAktivniKlijenti()
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetAktivniKlijenti").Tables[0];

            foreach (DataRow row in tbl.Rows)
            {

                yield return new Klijent
                {
                    Naziv = row["Naziv"].ToString(),
                    IDKlijent = (int)row["IDKlijent"],
                    Aktivan = row["Aktivan"].ToString()
                };
            }
        }

        internal static IEnumerable<Klijent> GetSviKlijenti()
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetSviKlijenti").Tables[0];
       
            foreach (DataRow row in tbl.Rows)
            {

                yield return new Klijent
                {
                    Naziv = row["Naziv"].ToString(),
                    IDKlijent = (int)row["IDKlijent"],
                    Aktivan = row["Aktivan"].ToString()
                };
            }
        }

        internal static void UpdateProjektKlijentId(int idKlijent, int iDProjekt)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateProjektKlijentId", idKlijent, iDProjekt);

        }

        internal static IEnumerable<Djelatnik> GetDjelatniciNaProjektu(int projektId)
        {
            var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "GetDjelatniciNaProjektu", projektId).Tables[0];

            foreach (DataRow row in tblDjelatnici.Rows)
            {
                yield return new Djelatnik
                {

                    IDDjelatnik = (int)row["IDDjelatnik"],
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    Lozinka = row["Lozinka"].ToString(),
                    Aktivan = row["Aktivan"].ToString(),
                    DatumZaposlenja = (DateTime)row["DatumZaposlenja"],
                    TipDjelatnikaID = (int)row["TipDjelatnikaID"],
                    Jezik = row["Jezik"].ToString(),
                    ImePrezime = row["Ime"].ToString() + " " + row["Prezime"].ToString()

                };

            }
        }

        internal static Klijent GetKlijentProjekta(int projektId)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetKlijentProjekta", projektId).Tables[0];
            DataRow row = tbl.Rows[0];

         return new Klijent
            {
                Naziv = row["Naziv"].ToString(),
                IDKlijent = (int)row["IDKlijent"],
                Aktivan = row["Aktivan"].ToString()
            };

        }

        internal static int GetVoditeljProjektaId(int projektId)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetVoditeljProjektaId", projektId).Tables[0];
            DataRow row = tbl.Rows[0];

            return (int) row["VoditeljProjektaID"];
        }

        internal static int GetKlijentProjektaId(int projektId)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetKlijentProjektaId", projektId).Tables[0];
            DataRow row = tbl.Rows[0];

            return (int)row["KlijentID"];
        }

        internal static string GetVoditeljProjekta(int projektId)
        {
                DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetVoditeljProjekta", projektId).Tables[0];
                DataRow row = tbl.Rows[0];
                string ImePrezime = row["Ime"].ToString() + " " + row["Prezime"].ToString();

                return ImePrezime;
         
        }

        internal static IEnumerable<Tim> GetSviTimovi()
        {
            var tblTimovi = SqlHelper.ExecuteDataset(cs, "GetSviTimovi").Tables[0];

            foreach (DataRow row in tblTimovi.Rows)
            {
                yield return new Tim
                {

                    IDTim = (int)row["IDTim"],
                    Naziv = row["Naziv"].ToString(),
                    Aktivan = row["Aktivan"].ToString(),
                    DatumKreiranja = (DateTime)row["DatumKreiranja"]

                };

            }
        }

        internal static string GetAktivnostTima(int idTim)
        {
            DataTable tbl = SqlHelper.ExecuteDataset(cs, "GetAktivnostTima", idTim).Tables[0];
            DataRow row = tbl.Rows[0];

            return row["Aktivan"].ToString();
        }

        internal static IEnumerable<Djelatnik> GetZaposlenici()
        {
            var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "GetZaposlenici").Tables[0];

            foreach (DataRow row in tblDjelatnici.Rows)
            {
                yield return new Djelatnik
                {

                    IDDjelatnik = (int)row["IDDjelatnik"],
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    Lozinka = row["Lozinka"].ToString(),
                    Aktivan = row["Aktivan"].ToString(),
                    DatumZaposlenja = (DateTime)row["DatumZaposlenja"],
                    TipDjelatnikaID = (int)row["TipDjelatnikaID"],
                    Jezik = row["Jezik"].ToString(),
                    ImePrezime = row["Ime"].ToString() + " " + row["Prezime"].ToString()

                };

            }
        }

        internal static void UpdateAktivnostTima(int idTim, string status)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateAktivnostTima", idTim, status);

        }

        internal static void InsertTim(Tim tim)
        {
            SqlHelper.ExecuteNonQuery(cs, "InsertTim", tim.Naziv, tim.DatumKreiranja);
        }

        internal static IEnumerable<Tim> GetAktivniTimovi()
        {
            var tblTimovi = SqlHelper.ExecuteDataset(cs, "GetAktivniTimovi").Tables[0];

            foreach (DataRow row in tblTimovi.Rows)
            {
                yield return new Tim 
                {

                    IDTim = (int)row["IDTim"],
                    Naziv = row["Naziv"].ToString(),
                    Aktivan = row["Aktivan"].ToString(),
                    DatumKreiranja = (DateTime)row["DatumKreiranja"]
  
                };

            }
        }

        internal static int GetVoditeljTimaID(int timId)
        {
            try
            {
                DataTable tblVoditeljTima = SqlHelper.ExecuteDataset(cs, "GetVoditeljTima", timId).Tables[0];
                DataRow rowVoditeljTima = tblVoditeljTima.Rows[0];

                return (int)rowVoditeljTima["IDDjelatnik"];
            }
            catch (Exception)
            {
                return 0;
            }
        }

        internal static void UpdateProjekt(Projekt projekt)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateProjekt", projekt.IDProjekt, projekt.Naziv,projekt.DatumOtvaranja,projekt.KlijentID,projekt.VoditeljProjektaID);
        }


        internal static IEnumerable<Djelatnik> GetDjelatniciTima(int timId)
        {
            var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "GetDjelatniciTima", timId).Tables[0];

            foreach (DataRow row in tblDjelatnici.Rows)
            {
                yield return new Djelatnik
                {

                    IDDjelatnik = (int)row["IDDjelatnik"],
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    Lozinka = row["Lozinka"].ToString(),
                    Aktivan = row["Aktivan"].ToString(),
                    DatumZaposlenja = (DateTime)row["DatumZaposlenja"],
                    TipDjelatnikaID = (int)row["TipDjelatnikaID"],
                    Jezik = row["Jezik"].ToString(),
                    ImePrezime = row["Ime"].ToString() + " " + row["Prezime"].ToString()

                };

            }
        }

        internal static string GetVoditeljTima(int timId)
        {
            try
            {

                DataTable tblVoditeljTima = SqlHelper.ExecuteDataset(cs, "GetVoditeljTima", timId).Tables[0];
                DataRow rowVoditeljTima = tblVoditeljTima.Rows[0];

                string ImePrezimeVT = rowVoditeljTima["Ime"].ToString() + " " + rowVoditeljTima["Prezime"].ToString();

                return ImePrezimeVT;
            }
            catch (Exception)
            {

                return "Nema voditelja";
            }
        }

        internal static Tim GetTim(int timId)
        {
            DataTable tblTim = SqlHelper.ExecuteDataset(cs, "GetTim", timId).Tables[0];
            DataRow row = tblTim.Rows[0];

            return new Tim
            {
                IDTim = (int)row["IDTim"],
                Naziv = row["Naziv"].ToString(),
                Aktivan = row["Aktivan"].ToString(),
                DatumKreiranja = (DateTime)row["DatumKreiranja"]
            };
        }

        internal static IEnumerable<Djelatnik> GetSviDjelatnici()
        {
            var tblDjelatnici = SqlHelper.ExecuteDataset(cs, "GetSviDjelatnici").Tables[0];

            foreach (DataRow row in tblDjelatnici.Rows)
            {
                yield return new Djelatnik
                {

                    IDDjelatnik = (int)row["IDDjelatnik"],
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString(),
                    Email = row["Email"].ToString(),
                    Lozinka = row["Lozinka"].ToString(),
                    Aktivan = row["Aktivan"].ToString(),
                    DatumZaposlenja = (DateTime)row["DatumZaposlenja"],
                    TipDjelatnikaID = (int)row["TipDjelatnikaID"],
                    Jezik = row["Jezik"].ToString(),
                    ImePrezime = row["Ime"].ToString() + " " + row["Prezime"].ToString()

                };

            }
        }

        internal static void UpdateAktivnostDjelatnika(int idDjelatnika, string status)
        {
        SqlHelper.ExecuteNonQuery(cs, "UpdateAktivnostDjelatnika", idDjelatnika,status);

        }

        internal static IEnumerable<Tim> GetSviAktivniTimovi()
        {
            var tblTimovi = SqlHelper.ExecuteDataset(cs, "GetSviAktivniTimovi").Tables[0];

            foreach (DataRow row in tblTimovi.Rows)
            {
                yield return new Tim
                {
                    IDTim = (int)row["IDTim"],
            Naziv= row["Naziv"].ToString(),
                DatumKreiranja = (DateTime)row["DatumKreiranja"],
                    Aktivan = row["Aktivan"].ToString()
                };

            }
        }

        internal static void UpdateTipDjelatika(int timId,int djelatnikId, int tipDjelatnikaId)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateTipDjelatika", timId, djelatnikId, tipDjelatnikaId);
        }

        internal static void UpdateTim(Tim tim)
        {
          SqlHelper.ExecuteNonQuery(cs, "UpdateTim", tim.IDTim,tim.Naziv,tim.DatumKreiranja);

        }

        internal static IEnumerable<TipDjelatnika> GetSviTipoviDjelatnika()
        {
            var tblTipoviDjelatnika = SqlHelper.ExecuteDataset(cs, "GetSviTipoviDjelatnika").Tables[0];

            foreach (DataRow row in tblTipoviDjelatnika.Rows)
            {
                yield return new TipDjelatnika
                {
                    IDTipDjelatnika = (int)row["IDTipDjelatnika"],
                    Naziv = row["Naziv"].ToString()
                };

            }
        }

        internal static string GetTipDjelatnika(int djelatnikId)
        {
            DataTable tblTipDjelatnika = SqlHelper.ExecuteDataset(cs, "GetTipDjelatnika", djelatnikId).Tables[0];
            DataRow rowTipDjelatnika = tblTipDjelatnika.Rows[0];

            return rowTipDjelatnika["Naziv"].ToString();
        }
        internal static string GetAktivnostDjelatnika(int djelatnikId)
        {
            DataTable tblTipDjelatnika = SqlHelper.ExecuteDataset(cs, "GetTipDjelatnika", djelatnikId).Tables[0];
            DataRow rowTipDjelatnika = tblTipDjelatnika.Rows[0];

            return rowTipDjelatnika["Aktivan"].ToString();
        }
        internal static string GetTimDjelatnika(int djelatnikId)
        {
            try
            {
                DataTable tblDjelatnik = SqlHelper.ExecuteDataset(cs, "GetTimDjelatnika", djelatnikId).Tables[0];
                DataRow rowDjelatnik = tblDjelatnik.Rows[0];

                return rowDjelatnik["Naziv"].ToString();
            }
            catch (Exception)
            {
                return "Nije u timu";
            }
            
        }
        public static Djelatnik GetDjelatnik(int djelatnikId)
        {
            DataTable tblDjelatnik = SqlHelper.ExecuteDataset(cs, "GetDjelatnik", djelatnikId).Tables[0];
            DataRow rowDjelatnik = tblDjelatnik.Rows[0];

            return new Djelatnik
            {
                Ime = rowDjelatnik["Ime"].ToString(),
                Prezime = rowDjelatnik["Prezime"].ToString(),
                Email = rowDjelatnik["Email"].ToString(),
                Lozinka = rowDjelatnik["Lozinka"].ToString(),
                Aktivan = rowDjelatnik["Aktivan"].ToString(),
                DatumZaposlenja = (DateTime)rowDjelatnik["DatumZaposlenja"],
                IDDjelatnik = (int)rowDjelatnik["IDDjelatnik"],
                Jezik = rowDjelatnik["Jezik"].ToString(),
                TipDjelatnikaID = (int)rowDjelatnik["TipDjelatnikaID"],
                ImePrezime = rowDjelatnik["Ime"].ToString() + " " + rowDjelatnik["Prezime"].ToString()
            };

        }

        internal static void UpdateDjelatnikTimId(int idTim, int iDDjelatnik)
        {

         SqlHelper.ExecuteNonQuery(cs, "UpdateDjelatnikTimId",iDDjelatnik,idTim);

        }

        internal static Projekt GetProjekt(int idProjekt)
        {
            DataTable tblProjekt= SqlHelper.ExecuteDataset(cs, "GetProjekt", idProjekt).Tables[0];
            DataRow row = tblProjekt.Rows[0];

            return new Projekt
            {
                IDProjekt = (int)row["IDProjekt"],
                Naziv = row["Naziv"].ToString(),
                KlijentID = (int)row["KlijentID"],
                DatumOtvaranja = (DateTime)row["DatumOtvaranja"],
                VoditeljProjektaID = (int)row["VoditeljProjektaID"],
                Aktivan = row["Aktivan"].ToString()
            } ;

        }

        public static IEnumerable<Projekt> GetProjektiDjelatnika(int djelatnikId)
        {
            var tblProjekti = SqlHelper.ExecuteDataset(cs, "GetProjektiDjelatnika", djelatnikId).Tables[0];

            foreach (DataRow row in tblProjekti.Rows)
            {
                yield return new Projekt
                {

                    IDProjekt = (int)row["IDProjekt"],
                    Naziv = row["Naziv"].ToString(),
                    KlijentID = (int)row["KlijentID"],
                    DatumOtvaranja = (DateTime)row["DatumOtvaranja"],
                    VoditeljProjektaID = (int)row["VoditeljProjektaID"],
                    Aktivan = row["Aktivan"].ToString()

                };

            }

        }


        public static IEnumerable<Projekt> GetAktivniProjekti()
        {
            var tblProjekti = SqlHelper.ExecuteDataset(cs, "GetAktivniProjekti").Tables[0];

            foreach (DataRow row in tblProjekti.Rows)
            {
                yield return new Projekt
                {

                    IDProjekt = (int)row["IDProjekt"],
                    Naziv = row["Naziv"].ToString(),
                    KlijentID = (int)row["KlijentID"],
                    DatumOtvaranja = (DateTime)row["DatumOtvaranja"],
                    VoditeljProjektaID = (int)row["VoditeljProjektaID"],
                    Aktivan = row["Aktivan"].ToString()

                };

            }

        }

        public static int DeleteProjektDjelatnik(int djelatnikId, int projektId)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteProjektDjelatnik", djelatnikId, projektId);

        }

        public static int InsertProjektDjelatnik(int djelatnikId, int projektId)
        {
            return SqlHelper.ExecuteNonQuery(cs, "InsertProjektDjelatnik", djelatnikId, projektId);

        }

        public static int UpdateDjelatnik (Djelatnik djelatnik)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateDjelatnik",djelatnik.IDDjelatnik, djelatnik.Ime, djelatnik.Prezime, djelatnik.Email,djelatnik.DatumZaposlenja,djelatnik.Lozinka,djelatnik.TipDjelatnikaID,djelatnik.TimID );

        }

        public static int GetTipDjelatnikaID(string naziv)
        {
            DataTable tblTipDjelatnika = SqlHelper.ExecuteDataset(cs, "GetTipDjelatnikaID", naziv).Tables[0];
            DataRow rowTipDjelatnika = tblTipDjelatnika.Rows[0];

            return (int)rowTipDjelatnika["IDTipDjelatnika"];
        }

        public static int GetTimID(string naziv)
        {
            DataTable tblTipDjelatnika = SqlHelper.ExecuteDataset(cs, "GetTimID", naziv).Tables[0];
            DataRow rowTipDjelatnika = tblTipDjelatnika.Rows[0];

            return (int)rowTipDjelatnika["IDTim"];
        }

        public static int GetDjelatnikID(Djelatnik djelatnik)
        {
           
                DataTable tblDjelatnik = SqlHelper.ExecuteDataset(cs, "GetDjelatnikID", djelatnik.Ime, djelatnik.Prezime, djelatnik.Email, djelatnik.DatumZaposlenja, djelatnik.Lozinka, djelatnik.TipDjelatnikaID, djelatnik.TimID).Tables[0];
                DataRow rowDjelatnik = tblDjelatnik.Rows[0];
                return (int)rowDjelatnik["IDDjelatnik"];
          
     
        }

        public static int InsertDjelatnik(Djelatnik djelatnik)
        {
            return SqlHelper.ExecuteNonQuery(cs, "InsertDjelatnik", djelatnik.Ime, djelatnik.Prezime, djelatnik.Email, djelatnik.DatumZaposlenja, djelatnik.Lozinka, djelatnik.TipDjelatnikaID, djelatnik.TimID);

        }
    }

}