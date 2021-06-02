using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    public class Uplata
    {
        [Column("IdUplata")]
        [Key]
        [Display(Name = "ID Uplate")]
        public int IdUplata { get; set; }
    }
}