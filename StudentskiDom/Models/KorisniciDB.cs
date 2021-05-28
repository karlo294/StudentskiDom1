using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskiDom.Models
{
    public class KorisniciDB
    {
        private static List<Korisnik> lista = new List<Korisnik>();
        private static bool listaInicijalizirana = false;
        //Lista-za provjeru
       
        public KorisniciDB()
        {
            if(listaInicijalizirana==true)
            {
                lista.Add(new Korisnik()
                {
                    Id = 1,
                    Prezime = "Zuki",
                    Ime = "Zeljko",
                    Oib = "12345678911",
                    Email = "zeljko.zuki@mev.hr",
                    //Lozinka = "florijan77",
                    Telefon = 0998418678,
                    Mjesto = "Vinkovci",
                    Zupanija = "Vukovarsko-Srijemska",
                    Drzava = "Hrvatska",
                    GodinaStudija = GodinaStudija.Treca,
                    StatusStudenta = false,
                    InidikatorStudenta = true

                });

                lista.Add(new Korisnik()
                {
                    Id = 2,
                    Prezime = "Anticevic-Marinkovic",
                    Ime = "Ingrid",
                    Oib = "12345678912",
                    Email = "ingrid.antimari@mev.hr",
                    //Lozinka = "piplmusttrustast",
                    Telefon = 0982356675,
                    Mjesto = "Zagreb",
                    Zupanija = "Zagrebacka zupanija",
                    Drzava = "Hrvatska",
                    GodinaStudija = GodinaStudija.Prva,
                    StatusStudenta = true,
                    InidikatorStudenta = true

                });

                lista.Add(new Korisnik()
                {
                    Id = 3,
                    Prezime = "Kmica",
                    Ime = "Anka",
                    Oib = "12345678939",
                    Email = "anka.mrak@mev.hr",
                   // Lozinka = "kmicakmicacrnimrak",
                    Telefon = 0918438679,
                    Mjesto = "Split",
                    Zupanija = "Splitsko-Dalmatinska",
                    Drzava = "Hrvatska",
                    GodinaStudija = GodinaStudija.Druga,
                    StatusStudenta = true,
                    InidikatorStudenta = true

                });
            }
        }

        //vracamo listu studenta
        public List<Korisnik> VratiListu()
        {
            return lista;
        }
        
        public void AzurirajKorisnika(Korisnik korisnik)
        {
            int korisnikIndex = lista.FindIndex(x => x.Id == korisnik.Id);
            lista[korisnikIndex] = korisnik;
        }
    }
}