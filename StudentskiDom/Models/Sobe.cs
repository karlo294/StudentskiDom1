using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    public class Sobe
    {
        [Column("IdSoba")]
        [Key]
        [Display(Name = "ID Sobe")]
        public int IdSoba { get; set; }
    }
}