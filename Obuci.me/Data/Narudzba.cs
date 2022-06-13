using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obuci.me.Data
{
    public class Narudzba
    {
        public Narudzba() { }

        [Key]
        public int Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public string KupacId { get; set; }
        public double Popust { get; set; }
        public double Iznos { get; set; }
    }
}
