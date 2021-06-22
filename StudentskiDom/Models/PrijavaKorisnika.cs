using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    public class PrijavaKorisnika
    {
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        [Display(Name = "Lozinka")]
        [Required]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }
    }
}