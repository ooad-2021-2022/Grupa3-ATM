using System.ComponentModel.DataAnnotations;

namespace Obuci.me.Data
{
    public enum Kategorija
    {
        [Display(Name = "Majice")]
        Majice,
        [Display(Name = "Jakne")]
        Jakne,
        [Display(Name = "Obuća")]
        Obuća,
        [Display(Name = "Košulje")]
        Košulje,
        [Display(Name = "Haljine")]
        Haljine,
        [Display(Name = "Suknje")]
        Suknje,
        [Display(Name = "Dodaci")]
        Dodaci
    }
}
