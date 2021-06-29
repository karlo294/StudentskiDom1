using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentskiDom.Misc;
using StudentskiDom.Models;

namespace StudentskiDom.Controllers
{
    [Authorize(Roles =OvlastiKorisnik.Administrator+","+OvlastiKorisnik.Korisnik)]
    public class ZahtjeviController : Controller
    {

        private BazaDBContext bazaPodataka = new BazaDBContext();

        // GET: Zahtjevi
        public ActionResult Index()
        {
            LogiraniKorisnik k = User as LogiraniKorisnik;
            if(k!=null)
            {
                ViewBag.Korisnik = k.Id;
            }
            return View(bazaPodataka.ZahtjevKorisnika.OrderBy(x => x.IdZahtjev).ToList());
            
        }
        public ActionResult Detalji(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            Zahtjev zahtjevi = bazaPodataka.ZahtjevKorisnika.FirstOrDefault(x => x.IdZahtjev == id);
            if (zahtjevi == null)
            {
                return RedirectToAction("Index");
            }
            return View(zahtjevi);
        }


        public ActionResult Brisi(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Zahtjev k = bazaPodataka.ZahtjevKorisnika.FirstOrDefault(x => x.IdZahtjev == id);
            if (k == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = " Potvrda brisanja zahtjeva";
            return View(k);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Brisi(int id)
        {
            Zahtjev k = bazaPodataka.ZahtjevKorisnika.FirstOrDefault(x => x.IdZahtjev == id);
            if (k == null)
            {
                return HttpNotFound();

            }
            bazaPodataka.ZahtjevKorisnika.Remove(k);
            bazaPodataka.SaveChanges();
            return View("BrisiStatus");
        }

        public ActionResult Azuriraj(int? id)
        {
            Zahtjev zahtjev = new Zahtjev();
            if (!id.HasValue)
            {
                zahtjev = new Zahtjev();
                ViewBag.Title = "Kreiranje novog zahtjeva";
                ViewBag.Novi = true;

            }
            // vucemo podatke iz baze
            else
            {
                zahtjev = bazaPodataka.ZahtjevKorisnika.Where(c => c.IdZahtjev == id).FirstOrDefault();

                if (zahtjev == null)
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                    //Ili skraćeno
                    return HttpNotFound();
                }
                ViewBag.Title = "Ažuriranje podataka o korisniku";
                ViewBag.Novi = false;
            }
            //mislim da to treba tako napraviti ali nisam siguran-taj dio bi bio za dropdown listu korisnika
            //a sljedeći takav dio bio bi za dropdown listu soba
            var korisnici = bazaPodataka.PopisKorisnika.OrderBy(x => x.Id).ToList();
            korisnici.Insert(0, new Korisnik {Id=0, Ime="Nedefinirano" });
            ViewBag.Korisnici = korisnici;

            var sobe = bazaPodataka.popisSobe.OrderBy(x => x.IdSoba).ToList();
            sobe.Insert(0, new Sobe { IdSoba = 0 }); //kod soba ne želi prikazati dropdown listu sa id nego prikazuje StudentskiDom.Models.Sobe ne znam kako to popraviti
            ViewBag.Sobe = sobe;

            return View(zahtjev);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(Zahtjev z)
        {


            if (ModelState.IsValid)
            {
                z = new Zahtjev();
                UpdateModel<Zahtjev>(z);
                bazaPodataka.ZahtjevKorisnika.Add(z);
                bazaPodataka.SaveChanges();

                return RedirectToAction("Index");
            }
            if (z.IdZahtjev != 0)
            {
                ViewBag.Title = "Ažuriranje podataka o zahtjevu";

                ViewBag.Novi = false;
            }
            else
            {
                ViewBag.Title = "Kreiranje novog zahtjeva";
                ViewBag.Novi = true;

            }
            //mislim da to treba tako napraviti ali nisam siguran-taj dio bi bio za dropdown listu korisnika
            //a sljedeći takav dio bio bi za dropdown listu soba
            var korisnici = bazaPodataka.PopisKorisnika.OrderBy(x => x.PrezimeIme).ToList();
            korisnici.Insert(0, new Korisnik { Id = 0, Ime = "Nedefinirano" });
            ViewBag.Korisnici = korisnici;

            var sobe = bazaPodataka.popisSobe.OrderBy(x => x.IdSoba).ToList();
            sobe.Insert(0, new Sobe { IdSoba = 0 });
            ViewBag.Sobe = sobe;
            return View(z);


        }

    }
}
    
