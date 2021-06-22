using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    [Table("slike")]
    public class SlikeSoba
    {
        [Column("idSlika")]
        [Key]
        [Display(Name = "ID Slike")]
        public int idSlika { get; set; }
        
        
        [Column("slikaPut")]
        [Display(Name = "Slika")]
        public string Slika { get; set; }


    }
}