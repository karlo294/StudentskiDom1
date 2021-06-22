using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskiDom.Misc
{
    public class LogiraniKorisnikSerializeModel
    {
        public string Email { get; set; }
        public string PrezimeIme { get; set; }
        public bool Indikator{ get; set; }
        internal void CopyFromUser(LogiraniKorisnik user)
        {
            this.Email= user.Email;
            this.PrezimeIme = user.PrezimeIme;
            this.Indikator = user.Indikator;
        }
    }
}