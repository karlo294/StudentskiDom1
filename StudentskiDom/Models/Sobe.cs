using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    [Table("soba")]
    public class Sobe
    {
        [Column("IdSoba")]
        [Key]
        [Display(Name = "ID Sobe")]
        public int IdSoba { get; set; }

        [Column("brojKreveta")]
        [Display(Name ="Broj kreveta")]
        public int BrojKreveta { get; set; }

        [Column("velicinaSoba")]
        [Display(Name ="Veličina sobe u m2")]
        public int VelicinaSobe { get; set; }

        [Column("opisSobe")]
        [Display(Name ="Opis sobe")]
        public string Opis { get; set; }

        [Column("idSlika")]
        [Display(Name = "ID Slike")]
        public int? IdSlika { get; set; }
        public virtual SlikeSoba SlikeSoba { get; set; }
    }
}