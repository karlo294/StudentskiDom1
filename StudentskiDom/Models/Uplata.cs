using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    [Table("uplata")]
    public class Uplata
    {
        [Column("IdUplata")]
        [Key]
        [Display(Name = "ID Uplate")]
        public int IdUplata { get; set; }

        [Column("iznos")]
        [Display(Name = "iznos")]
        [Required]

        public int? iznosUplata { get; set; }

        [Column("datUplate")]
        [Display(Name = "Datum Uplate")]
       

        public DateTime? datumUplate { get; set; }

        [Column("statusPlacanja")]
        [Display(Name = "Plaćeno")]
        [Required]

        public bool statusPlacanja { get; set; }

        [Column("IdSoba")]
        [Display(Name = "Id Soba")]
        [ForeignKey("Soba")]
       
        public int? idSobe { get; set; }
        public virtual Sobe Soba { get; set; }

        [Column("opisUplata")]
        [Display(Name = "Opis uplate")]
        [Required]

        public string opisUplate { get; set; }

        [Column("zaRazdoblje")]
        [Display(Name = "Razdoblje")]
        [Required]

        public string razdobljeUplata { get; set; }

        [Column("IdKorisnik")]
        [Display(Name = "Id Korisnika")]
        [ForeignKey("Korisnik")]
        public int? idKorisnik { get; set; }

        public virtual Korisnik Korisnik { get; set; }



    }
}