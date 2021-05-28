using PagedList;
using StudentskiDom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentskiDom.Controllers
{
    public class KorisniciController : Controller
    {
        BazaDBContext bazaPodataka = new BazaDBContext();
        // GET: Korisnici
        public ActionResult Index()
        {
            ViewBag.Title = "Studentski dom";
            ViewBag.Fakultet = "Međimursko veleučilište u Čakovcu";
            return View();
        }
        public ActionResult PopisKorisnika(string naziv) //posto smo u view napravili pretragu po nazivu onda u parametar stavljam samo naziv
        {
            //instaciramo klasu koja sadrzava listu
            var korisnici = bazaPodataka.PopisKorisnika.ToList(); //izbacuje error System.NullReferenceException treba skuziti ako ne skuzimo pitati profesora 
            //filtriranje
            if(!String.IsNullOrWhiteSpace(naziv))
            {
                korisnici = korisnici.Where(x => x.PrezimeIme.ToUpper().Contains(naziv.ToUpper())).ToList();
            }
            return View(korisnici); //hmm pojma nemam zasto to ne radi, treba skuziti i popraviti
        }
        public ActionResult PopisKorisnikaPartial(string naziv, string sort, int? page)
        {
            //System.Threading.Thread.Sleep(200); //simulacija duže obrade zahtjeva
            //u buducnosti moci nadograditi,ukoliko se odluci na to pratiti prezentaciju(10.AJAX)

            ViewBag.Sortiranje = sort;
            ViewBag.NazivSort = String.IsNullOrEmpty(sort) ? "naziv_desc" : "";
            ViewBag.Naziv = naziv;

            var korisnici = bazaPodataka.PopisKorisnika.ToList();

            //filtriranje
            if (!String.IsNullOrWhiteSpace(naziv))
            {
                korisnici = korisnici.Where(x => x.PrezimeIme.ToUpper().Contains(naziv.ToUpper())).ToList();
            }

            switch (sort)
            {
                case "naziv_desc":
                    korisnici = korisnici.OrderByDescending(k => k.PrezimeIme).ToList();
                    break;
                default:
                    korisnici = korisnici.OrderBy(k => k.PrezimeIme).ToList();
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return PartialView("_PartialPopisKorisnika", korisnici.ToPagedList(pageNumber, pageSize));
        }
            
            
        public ActionResult Detalji(int? id)
        { 
            if (!id.HasValue)
            {
                return RedirectToAction("PopisKorisnika");
            }
            Korisnik korisnici = bazaPodataka.PopisKorisnika.FirstOrDefault(x => x.Id == id);
            if (korisnici == null)
            {
                return RedirectToAction("PopisKorisnika");
            }

            return View(korisnici);

        }
        // GET: Azuriraj
        public ActionResult Azuriraj(int? id)
        {
            Korisnik korisnik = null;
            if (!id.HasValue)
            {
                korisnik = new Korisnik();
                ViewBag.Title = "Kreiranje novog zahtjeva za smještaj u domu"; 
                ViewBag.Novi = true;

            }
            // vucemo podatke iz baze
            else
            {
                korisnik = bazaPodataka.PopisKorisnika.FirstOrDefault(x => x.Id == id); //Mislim da bi ovdje trebalo staviti tablicu zahtjev da se taj podatak posalje u tu tablicu
                //ukoliko pokusam staviti korisnik = bazaPodataka.ZahtjevKorisnik.FirstOrDefault(x => x.Id == id) stavi mi error da zahtjevkorisnik ne sadrzi Id
                //skuziti kak to popraviti
                if (korisnik == null)
                {
                    //ako nema korisnika
                    return HttpNotFound();
                }

                ViewBag.Title = "Ažuriranje podataka o korisniku";
                ViewBag.Novi = false;

            }
            return View(korisnik);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(Korisnik k)
        {
            if(!Oib.CheckOIB(k.Oib)) //provjera oiba
            {
                ModelState.AddModelError("Oib", "Neispravan OIB");
            }
            if(ModelState.IsValid)
            {
                if(k.Id!=0)
                {
                    bazaPodataka.Entry(k).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    bazaPodataka.PopisKorisnika.Add(k);
                }
                bazaPodataka.SaveChanges();
                return RedirectToAction("PopisKorisnika");
            }
            //takoder je vjerojatno krivo jer radim s tablicom korisnik a vjv bi trebalo sa zahtjevom pitati profesora ili probati sami skuziti
            if(k.Id==0)
            {
                ViewBag.Title("Kreiranje novog zahtjeva za smještaj");
                ViewBag.Novi = true;
            }
            else
            {
                ViewBag.Title = "Ažuriranje podataka o korisniku";
                ViewBag.Novi = false;
            }
            return View(k);
        }

        //GET brisi
        public ActionResult Brisi(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("PopisKorisnika");
            }
            Korisnik k = bazaPodataka.PopisKorisnika.FirstOrDefault(x => x.Id == id);
            if (k == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = " Potvrda brisanja korisnika";
            return View(k);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Brisi(int id)
        {
            Korisnik k = bazaPodataka.PopisKorisnika.FirstOrDefault(x => x.Id == id);
            if(k==null)
            {
                return HttpNotFound();

            }
            bazaPodataka.PopisKorisnika.Remove(k);
            bazaPodataka.SaveChanges();
            return View("BrisiStatus");
        }



    }
}