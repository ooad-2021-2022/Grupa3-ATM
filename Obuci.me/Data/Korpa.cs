using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obuci.me.Data
{
    public class Korpa
    {
        public Korpa() { }
        [Key]
        public int Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        [ForeignKey("Artikl")]
        public int ArtiklId { get; set; }

        public Artikl Artikl { get; set; }
    }
}
