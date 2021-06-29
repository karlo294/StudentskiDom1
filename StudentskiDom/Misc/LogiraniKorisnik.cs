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
        public int Id { get; set; } //hmm nezz jel to dobro
     
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
            this.PrezimeIme = kor.PrezimeIme;
            this.Indikator = kor.InidikatorStudenta;
            this.Id = kor.Id;

        }
        public LogiraniKorisnik(string email)
        {
            this.Identity = new GenericIdentity(email);
            this.Email = email;
        }

    }
}