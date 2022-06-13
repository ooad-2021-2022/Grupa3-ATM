using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obuci.me.Data
{
    public class Racun
    {
        public Racun() { }
        [Key]
        public int id { get; set; }

        [ForeignKey("Narudzba")]
        public int NarudzbaId { get; set; }

        [ForeignKey("Dostava")]
        public int DostavaId { get; set; }
        public double Iznos { get; set; }
        public DateTime DatumKupovine { get; set; }

        public Narudzba Narudzba { get; set; }
        public Dostava Dostava { get; set; }
    }
}
