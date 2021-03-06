using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace StudentskiDom.Models
{
    [Table("korisnici")]
    public class Korisnik
    {
        [Column("IdKorisnik")]
        [Key]
        [Display(Name = "ID Korisnika")]
        public int Id { get; set; }

        [Column("imeKorisnik")]
        [Display(Name = "Ime")]
        [Required]
        public string Ime { get; set; }

        [Column("prezimeKorisnik")]
        [Display(Name = "Prezime")]
        [Required]
        public string Prezime { get; set; }

        [Column("oibKorisnik")]
        [Display(Name = "OIB")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} mora biti duljine {1} znakova")]
        public string Oib { get; set; }

        [Column("emailKorisnik")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} je obavezan")]
        [EmailAddress]
        public string Email { get; set; }
        //nisam siguran jel treba tu staviti [column("ime kolone u tablici")]
        //u varijabli lozinke spremljene su lozinke iz liste,prije baze
        public string Lozinka { get; set; }

        [Display(Name = "Ime i Prezime")]
        public string PrezimeIme
        {
            get
            {
                return Prezime + " " + Ime;
            }
        }

        [Column("godstudijaST")]
        [Display(Name = "Godina studija")]
        [Range(1, 5, ErrorMessage = "Vrijednost {0} mora biti između {1} i {2}")]
        public GodinaStudija GodinaStudija { get; set; }

        //nisam siguran jel treba tu staviti [column("ime kolone u tablici")]
        [Display(Name = "Lozinka")]
        [DataType(DataType.Password)]

        [NotMapped]
        public string LozinkaUnos { get; set; }

        //nisam siguran jel treba tu staviti [column("ime kolone u tablici")]
        [Display(Name = "Ponovljena lozinka")]
        [DataType(DataType.Password)]

        [NotMapped]
        [Compare("LozinkaUnos", ErrorMessage = "Lozinke moraju biti jednake")]
        public string LozinkaUnos2 { get; set; }

        [Column("mobKorisnik")]
        [Display(Name = "Telefon")]
        [Compare("Telefon", ErrorMessage = "Obavezno ispuniti broj telefona")]
        public string Telefon { get; set; }

        [Column("pbrMjesto")]
        [Display(Name = "Poštanski broj")]


        [ForeignKey("Mjesto")]

        public int pMjesto { get; set; }

        public virtual Mjesto Mjesto { get; set; }


        [Column("drzavaK")]
        [Display(Name = "Država")]

        [Compare("Drzava", ErrorMessage = "Obavezno ispuniti Državu")]
        public string Drzava { get; set; }

        [Column("StatusStudenta")]
        [Display(Name = "Redovan student")]
        public bool StatusStudenta { get; set; }

        //nisam siguran koje validacije bi trebalo staviti
        [Column("indikatorSA")]
        [Display(Name = "Indikator")]
         
         public bool InidikatorStudenta { get; set; }

        //doraditi model korisnik prema uputi-posto je odvjde vec vise manje sve gotovo preldazem da se unutar tablice korisnici u
        //bazi samo napravi dodatna kolona korisnicko ime ukoliko je to pametno te tu dodati samo metodu i potrebnu validaciju
        //ako ne onda iz ovog modela izbrisati email,lozinka,lozinka2,lozinkaunos2 i napraviti posebnu klasu odnosno model
        //moguce da validacija compare nece trebati na metodama drzava,zupanija,mjesto,telefon nego samo na lozinkama zasad nego ostane


    }
}