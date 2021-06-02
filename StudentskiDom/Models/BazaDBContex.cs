using System;
using MySql.Data.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace StudentskiDom.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BazaDBContext : DbContext
    {
        public DbSet<Korisnik> PopisKorisnika { get; set; }

        public DbSet<Zahtjev> ZahtjevKorisnika { get; set; }

        public DbSet<Sobe> popisSobe { get; set; }

        public DbSet<Uplata> popisUplata { get; set; }

        
        //public DbSet<SlikeSoba> popisSlikeSobe { get; set; }

        //ovdje bi trebalo dodati jos dvije tablice(ovlast) i posebna tablica za prijavu korisnika(koja u bazi ima atribute-
        //prezime,ime,korisnickoime,email,ovlast,lozinkaunos,ponovljenalozinka)pratiti prezentaciju 11 ja u ovom slucaju necu napraviti
        //model za tu tablicu jer ne znam hocemo li se odluciti na taj nacin izrade u svakom slucaju potreban dogovor i pitati profesora!
        //u najgorem slucaju ukoliko ne stignemo napraviti aplikaciju do kraja u ovih tjedan i pol kaj nam je ostalo ici cemo na rok

    }
}