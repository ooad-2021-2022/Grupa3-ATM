using System;

namespace Obuci.me.Data
{
    public class Kupac : Osoba
    {
        public Kupac() { }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string BrojRacuna { get; set; }
    }
}
