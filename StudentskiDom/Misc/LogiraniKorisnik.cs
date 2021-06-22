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
        public string Email { get; set; }
        public string PrezimeIme { get; set; }
        public bool Indikator { get; set; }
     
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (Indikator.ToString() == role) return true;
            return false;
        }



        public LogiraniKorisnik(Korisnik kor)
        {
            this.Identity = new GenericIdentity(kor.Email); 
            this.Email = kor.Email;
            this.PrezimeIme = kor.PrezimeIme; //tu ne izbacuje error jer metoda prezimeIme vec postoji u modelu korisnik
            this.Indikator = kor.InidikatorStudenta; //takoder izbacuje error iz istog razloga-potrebno doraditi ili kreirati novu tablicu

        }
        public LogiraniKorisnik(string email)
        {
            this.Identity = new GenericIdentity(email);
            this.Email = email;
        }

    }
}