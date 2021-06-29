using StudentskiDom.Misc;
using StudentskiDom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentskiDom.Controllers
{
    [Authorize(Roles = OvlastiKorisnik.Administrator + "," + OvlastiKorisnik.Korisnik)]
    public class UplataController : Controller
    {
        private BazaDBContext bazaPodataka = new BazaDBContext();
        // GET: Uplata
        public ActionResult Index()
        {
            LogiraniKorisnik k = User as LogiraniKorisnik;
            if (k != null)
            {
                ViewBag.Korisnik = k.Id;
            }
            return View(bazaPodataka.popisUplata.OrderBy(x=>x.IdUplata).ToList());
        }

        public ActionResult Detalji(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            Uplata uplate = bazaPodataka.popisUplata.FirstOrDefault(x => x.IdUplata == id);
            if (uplate == null)
            {
                return RedirectToAction("Index");
            }
            return View(uplate);
        }

        public ActionResult Brisi(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Uplata u = bazaPodataka.popisUplata.FirstOrDefault(x => x.IdUplata == id);
            if (u == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = " Potvrda brisanja uplate";
            return View(u);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Brisi(int id)
        {
            Uplata u = bazaPodataka.popisUplata.FirstOrDefault(x => x.IdUplata == id);
            if (u == null)
            {
                return HttpNotFound();

            }
            bazaPodataka.popisUplata.Remove(u);
            bazaPodataka.SaveChanges();
            return View("BrisiStatus");
        }

        public ActionResult Azuriraj(int? id)
        {
            Uplata uplata = null;

            if (!id.HasValue)
            {
                uplata = new Uplata();


                ViewBag.Novi = true;

            }
            // vucemo podatke iz baze
            else
            {
                uplata = bazaPodataka.popisUplata.FirstOrDefault(x => x.IdUplata == id);
                //korisnik = bazaPodataka.PopisKorisnika.FirstOrDefault(x => x.pMjesto == mjesto);//Mislim da bi ovdje trebalo staviti tablicu zahtjev da se taj podatak posalje u tu tablicu
                //ukoliko pokusam staviti korisnik = bazaPodataka.ZahtjevKorisnik.FirstOrDefault(x => x.Id == id) stavi mi error da zahtjevkorisnik ne sadrzi Id
                //skuziti kak to popraviti
                if (uplata == null)
                {
                    //ako nema korisnika
                    return HttpNotFound();
                }

                ViewBag.Title = "Ažuriranje podataka o uplati";
                ViewBag.Novi = false;

            }
            return View(uplata); //zaboravil sam jel se view radi na obicnoj metodi ili na http post metodi
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(Uplata u)
        {



            // z = bazaPodataka.PopisKorisnika.FirstOrDefault(x => x.pMjesto == m);

            if (ModelState.IsValid)
            {


                if (u.IdUplata != 0)
                {
                    bazaPodataka.Entry(u).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    bazaPodataka.popisUplata.Add(u);
                }

                bazaPodataka.SaveChanges();//eh
                return RedirectToAction("Index");
            }
            
            if (u.IdUplata != 0)
            {
                ViewBag.Title = "Ažuriranje podataka o uplati";

                ViewBag.Novi = false;
            }
            else
            {
                ViewBag.Title="Kreiranje nove uplate";
                ViewBag.Novi = true;
               
            }
            return View(u);

        }


    }
}