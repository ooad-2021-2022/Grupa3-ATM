using System.Collections.Generic;

namespace Obuci.me.Data
{
    public class Narudzba
    {
        public Narudzba() { }
        public int Id { get; set; }
        public List<Artikl> Artikli { get; set; }
        public Kupac Kupac { get; set; }
        public double Popust { get; set; }
    }
}
