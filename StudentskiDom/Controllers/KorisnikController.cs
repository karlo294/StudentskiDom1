﻿using StudentskiDom.Models;
using StudentskiDom.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace StudentskiDom.Controllers
{
    [Authorize(Roles =  OvlastiKorisnik.Administrator)]
    public class KorisnikController : Controller
    {
        BazaDBContext bazaPodataka = new BazaDBContext();
        // GET: Korisnik
        public ActionResult Index()
        {
            var listaKorisnik = bazaPodataka.PopisKorisnika.OrderBy(x => x.InidikatorStudenta).ThenBy(x => x.Prezime).ToList();
            return View(listaKorisnik);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Prijava(string returnUrl)
        {
            PrijavaKorisnika model = new PrijavaKorisnika();
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Prijava(PrijavaKorisnika model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
               
                var korisnikBaza = bazaPodataka.PopisKorisnika.FirstOrDefault(x => x.Email == model.Email);
                //provjeravamo hash lozinke iz baze i izračunati hash na temelju upisane lozinke na login formi
                bool passwordOK = korisnikBaza.Lozinka == Misc.PasswordHelper.IzracunajHash(model.Lozinka);

                if (passwordOK)
                {
                    LogiraniKorisnik prijavljeniKorisnik = new LogiraniKorisnik(korisnikBaza);
                    LogiraniKorisnikSerializeModel serializeModel = new LogiraniKorisnikSerializeModel();
                    serializeModel.CopyFromUser(prijavljeniKorisnik);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string korisnickiPodaci = serializer.Serialize(serializeModel);

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1,
                        prijavljeniKorisnik.Identity.Name,
                        DateTime.Now,
                        DateTime.Now.AddDays(1),
                        false,
                        korisnickiPodaci);

                    string ticketEncrypted = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                        ticketEncrypted);
                    Response.Cookies.Add(cookie);

                    //ako postoji url kojem je korisnik prvotno pristupao tada preusmjeravamo na taj url
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Neispravno korisničko ime ili lozinka");
            return View(model);
        }

        [OverrideAuthorization]
        [Authorize]
        public ActionResult Odjava()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registracija()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registracija(Korisnik model)
        {
            
            if (!String.IsNullOrWhiteSpace(model.Email))
            {
                var emailZauzet = bazaPodataka.PopisKorisnika.Any(x => x.Email == model.Email);
                if (emailZauzet)
                {
                    ModelState.AddModelError("Email", "Email je već zauzet");
                }
            }

            if (ModelState.IsValid)
            {
                model.Lozinka = Misc.PasswordHelper.IzracunajHash(model.LozinkaUnos);
                model.InidikatorStudenta = false;

                bazaPodataka.PopisKorisnika.Add(model);
                bazaPodataka.SaveChanges();

                return View("RegistracijaOK");
            }

         

            return View(model);
        }
    }
}
