//using StudentskiDom.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace StudentskiDom.Controllers
//{ 
//    //ovoc je kontorler koji sluzi samo za ispis svih korisnika koji su registrirani u aplikaciji,bit ce napravljen tako da njemu pristup ima
//    //jedino admin i zbog toga sto pratim prezentaciju vrlo vjerojatno ce trebati napraviti jos tu jednu posebnu tablicu unutar baze 
//    //obavezno pratiti uputu i komentare unutar koda 
//    public class KorisnikController : Controller
//    {
//        BazaDBContext bazaPodataka = new BazaDBContext();
//        // GET: Korisnik
//        public ActionResult Index()
//        {
//            //var listaKorisnik=bazaPodataka.PopisKorisnik.OrderBy(x=>x.SifraOvlasti).ThenBy(x=>x.Prezime).ToList();
//            //return View(listaKorisnik);
//        }
//    }
//}