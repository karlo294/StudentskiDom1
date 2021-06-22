using StudentskiDom.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace StudentskiDom.Controllers
{
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
    }
}