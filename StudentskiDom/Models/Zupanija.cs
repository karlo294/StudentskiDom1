using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    [Table("zupanija")]
    public class Zupanija
    {
        [Column("zupanijak")]
        [Key]
        [Display(Name = "Šifra županije")]
       
        public int sifraZupanija { get; set; }

        [Column("nazivZupanija")]
        [Display(Name = "Županija")]
        [Required]
        [Compare("Zupanija", ErrorMessage = "Obavezno ispuniti Županiju")]
        public string nazivZupanija { get; set; }
       




    }
}