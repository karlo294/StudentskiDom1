using StudentskiDom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace StudentskiDom.Misc
{
    public class LogiraniKorisnik:IPrincipal
    {
        public string KorisnickoIme { get; set; }
        public string PrezimeIme { get; set; }
        public string Ovlast { get; set; }

        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (Ovlast == role) return true;
            return false;

        }
        public LogiraniKorisnik(Korisnik kor)
        {
            this.Identity = new GenericIdentity(kor.KorisnickoIme); //izbacuje error jer meotda korisniko ime ne postoji u modelu korisnik
            this.KorisnickoIme = kor.KorisnickoIme;
            this.PrezimeIme = kor.PrezimeIme; //tu ne izbacuje error jer metoda prezimeIme vec postoji u modelu korisnik
            this.Ovlast = kor.SifraOvlasti; //takoder izbacuje error iz istog razloga-potrebno doraditi ili kreirati novu tablicu

        }
        public LogiraniKorisnik(string korisnickoIme)
        {
            this.Identity = new GenericIdentity(korisnickoIme);
            this.KorisnickoIme = korisnickoIme;
        }

    }
}