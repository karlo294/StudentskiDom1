using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentskiDom.Models;

namespace StudentskiDom.Controllers
{
    [Authorize]
    public class ZahtjeviController : Controller
    {

        private BazaDBContext bazaPodataka = new BazaDBContext();

        // GET: Zahtjevi
        public ActionResult Index()
        {


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


            // vucemo podatke iz baze


            zahtjev = bazaPodataka.ZahtjevKorisnika.Where(c => c.IdZahtjev == id).FirstOrDefault();

            ViewBag.Title = "Ažuriranje podataka o korisniku";
            ViewBag.Novi = false;


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
            return View(z);


        }

    }
}
    
