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
        [Required(ErrorMessage = "{0} je obavezan")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} mora biti duljine {1} znakova")]
        public string Oib { get; set; }

        [Column("emailKorisnik")]
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        //nisam siguran jel treba tu staviti [column("ime kolone u tablici")]
        //u varijabli lozinke spremljene su lozinke iz liste,prije baze
        //public string Lozinka { get; set; }

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
        [Required]
        [NotMapped]
        public string LozinkaUnos { get; set; }

        //nisam siguran jel treba tu staviti [column("ime kolone u tablici")]
        [Display(Name = "Ponovljena lozinka")]
        [DataType(DataType.Password)]
        [Required]
        [NotMapped]
        [Compare("LozinkaUnos", ErrorMessage = "Lozinke moraju biti jednake")]
        public string LozinkaUnos2 { get; set; }

        [Column("mobKorisnik")]
        [Display(Name = "Telefon")]
        [Compare("Telefon", ErrorMessage = "Obavezno ispuniti broj telefona")]
        public int Telefon { get; set; }

        [Column("pbrMjesto")]
        [Display(Name = "Mjesto stanovanja")]
        [Required]
        [Compare("Mjesto", ErrorMessage = "Obavezno ispuniti mjesto")]
        public string Mjesto { get; set; }

        [Column("zupanijak")]
        [Display(Name = "Županija")]
        [Required]
        [Compare("Zupanija", ErrorMessage = "Obavezno ispuniti Županiju")]
        public string Zupanija { get; set; }

        [Column("drzavaK")]
        [Display(Name = "Država")]
        [Required]
        [Compare("Drzava", ErrorMessage = "Obavezno ispuniti Državu")]
        public string Drzava { get; set; }

        [Column("StatusStudenta")]
        [Display(Name = "Redovan student")]
        public bool StatusStudenta { get; set; }

        //nisam siguran koje validacije bi trebalo staviti
        //ime kolone je [Column("indikatorSA")]
        public bool InidikatorStudenta { get; set; }

        //doraditi model korisnik prema uputi-posto je odvjde vec vise manje sve gotovo preldazem da se unutar tablice korisnici u
        //bazi samo napravi dodatna kolona korisnicko ime ukoliko je to pametno te tu dodati samo metodu i potrebnu validaciju
        //ako ne onda iz ovog modela izbrisati email,lozinka,lozinka2,lozinkaunos2 i napraviti posebnu klasu odnosno model
        //moguce da validacija compare nece trebati na metodama drzava,zupanija,mjesto,telefon nego samo na lozinkama zasad nego ostane


    }
}