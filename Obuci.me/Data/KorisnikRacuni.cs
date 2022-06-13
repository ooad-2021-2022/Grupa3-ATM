using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obuci.me.Data
{
    public class KorisnikRacuni
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        [ForeignKey("Racun")]
        public int RacunId { get; set; }

        public Racun Racun { get; set; }
    }
}
