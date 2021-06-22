using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    [Table("zahtjev")]
    public class Zahtjev
    {
        [Column("IdZahtjev")]
        [Key]
        [Display(Name = "ID Zahtjeva")]
        public int IdZahtjev { get; set; }

        [Column("statusZahtjeva")]
        [Display(Name ="Status zahtjeva")]
        public bool statusZahtjeva { get; set; }

        [Column("datPodnosenjaZahtjeva")]
        [Display(Name = "Datum podnošenja zahtjeva")]
        [Required]
        public DateTime? datumZahtjeva { get; set; }

        [Column("datUseljenja")]
        [Display(Name = "Datum useljenja")]
        
        public DateTime? datumUseljenja { get; set; }

        [Column("datIseljenja")]
        [Display(Name = "Datum iseljenja")]
        public DateTime? datumIseljenja { get; set; }

        [Column("IdKorisnik")]
        [Display(Name = "Id Korisnika")]
        [ForeignKey("Korisnik")]
        public int? idKorisnik { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        

        [Column("IdSoba")]
        [Display(Name = "Id Soba")]
        [ForeignKey("Soba")]
        public int? idSoba { get; set; }

        public virtual Sobe Soba { get; set; }

    }
}