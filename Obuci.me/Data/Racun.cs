using System;

namespace Obuci.me.Data
{
    public class Racun
    {
        public Racun() { }
        public int id { get; set; }
        public Narudzba Narudzba { get; set; }
        public double Iznos { get; set; }
        public DateTime DatumKupovine { get; set; }
        public Dostava Dostava { get; set; }
        public string Status { get; set; }
    }
}
