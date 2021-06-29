using StudentskiDom.Misc;
using StudentskiDom.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace StudentskiDom.Controllers
{
    [Authorize(Roles = OvlastiKorisnik.Administrator + "," + OvlastiKorisnik.Korisnik)]
    public class SobeController : Controller
    {
        private BazaDBContext bazaPodataka = new BazaDBContext();
        // GET: Sobe
        public ActionResult Index()
        {
            return View(bazaPodataka.popisSobe.OrderBy(x => x.IdSoba).ToList());
        }

        public ActionResult Detalji(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            Sobe soba = bazaPodataka.popisSobe.FirstOrDefault(x => x.IdSoba == id);

            if (soba == null)
            {
                return RedirectToAction("Index");
            }
            SlikeSoba slikeSoba = bazaPodataka.popisSlikeSobe.FirstOrDefault(x => x.idSlika == soba.IdSlika); //pokusaj kreiranja prikaza slika uz korištenje baze podataka-neuspjelo

            //  Sobe slike = (Sobe)bazaPodataka.popisSlikeSobe.Where(x => x.IdSoba_Slika == soba.IdSlika);
            return View(soba);
        }
        public ActionResult Azuriraj(int? id)
        {
            Sobe soba = null;

            if (!id.HasValue)
            {
                soba = new Sobe();
                


                ViewBag.Novi = true;

            }
            // vucemo podatke iz baze
            else
            {
                soba = bazaPodataka.popisSobe.FirstOrDefault(x => x.IdSoba == id);
                //korisnik = bazaPodataka.PopisKorisnika.FirstOrDefault(x => x.pMjesto == mjesto);//Mislim da bi ovdje trebalo staviti tablicu zahtjev da se taj podatak posalje u tu tablicu
                //ukoliko pokusam staviti korisnik = bazaPodataka.ZahtjevKorisnik.FirstOrDefault(x => x.Id == id) stavi mi error da zahtjevkorisnik ne sadrzi Id
                //skuziti kak to popraviti
                if (soba == null)
                {
                    //ako nema korisnika
                    return HttpNotFound();
                }

                ViewBag.Title = "Ažuriranje podataka o sobama";
                ViewBag.Novi = false;

            }
            return View(soba);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(Sobe s)
        {
            if (ModelState.IsValid)
            {
                if (s.IdSoba != 0)
                {
                    bazaPodataka.Entry(s).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    bazaPodataka.popisSobe.Add(s);
                }
                bazaPodataka.SaveChanges();
                return RedirectToAction("Index");


            }

            if (s.IdSoba != 0)
            {
                ViewBag.Title = "Ažuriranje podataka o sobama";

                ViewBag.Novi = false;
            }
            else
            {
                ViewBag.Title = "Kreiranje nove sobe";
                ViewBag.Novi = true;

            }
            return View(s);

        }

        public ActionResult Brisi(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Sobe s = bazaPodataka.popisSobe.FirstOrDefault(x => x.IdSoba == id);
            if (s == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = " Potvrda brisanja uplate";
            return View(s);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Brisi(int id)
        {
            Sobe s = bazaPodataka.popisSobe.FirstOrDefault(x => x.IdSoba == id);
            if (s == null)
            {
                return HttpNotFound();

            }
            bazaPodataka.popisSobe.Remove(s);
            bazaPodataka.SaveChanges();
            return View("BrisiStatus");
        }
    }


}



    

