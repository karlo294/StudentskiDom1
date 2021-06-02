using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    public class SlikeSoba
    {
        [Column("IdSlika")]
        [Key]
        [Display(Name = "ID Slike")]
        public int IdSoba_Slika { get; set; }
    }
}