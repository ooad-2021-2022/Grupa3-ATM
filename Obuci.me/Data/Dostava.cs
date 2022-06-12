using System;

namespace Obuci.me.Data
{
    public class Dostava
    {
        public Dostava() { }
        public int id { get; set; }
        public string Firma { get; set; }
        public string AdresaDostave { get; set; }
        public double CijenaDostave { get; set; }
        public DateTime VrijemeIsporuke { get; set; }
    }
}
