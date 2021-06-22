using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentskiDom.Models;

namespace StudentskiDom.Controllers
{
    [AllowAnonymous]
    public class SlikaSobeController : Controller
    {
        // GET: SlikaSobe
        public ActionResult Index()
        {
            return View();
            //slike ću prikazati uz pomoć bootsrap i css djela aplikacije samo kroz view zbog toga što ne znam kako se slike prikazuju iz baze podataka
        }
    }
}