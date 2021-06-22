using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    [Table("mjesto")]
    public class Mjesto
    {
        [Column("pbrMjesto")]
        [Key]
        [Display(Name = "Poštanski broj")]
        
        public int pbrmjesto { get; set; }

        [Column("nazivMjesto")]
        [Display(Name = "Mjesto stanovanja")]
        
        public string nazivMjesto { get; set; }

        [Column("zupanijak")]
        [Display(Name = "Županija")]
        [ForeignKey("Zupanija")]

        public int sifraZupanija { get; set; }
        public virtual Zupanija Zupanija { get; set; }

    }
}