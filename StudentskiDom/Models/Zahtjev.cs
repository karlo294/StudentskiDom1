using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    public class Zahtjev
    {
        [Column("IdZahtjev")]
        [Key]
        [Display(Name = "ID Zahtjeva")]
        public int IdZahtjev { get; set; }
    }
}