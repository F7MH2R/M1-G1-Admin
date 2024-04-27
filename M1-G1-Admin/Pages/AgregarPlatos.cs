using M1_G1_Admin.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace M1_G1_Admin.Pages
{
    public class AgregarPlatos : PageModel
    {
        public Combos combo {  get; set; }
        public int idPlato { get; set; }
        public IEnumerable<Platos> platosXCombo { get; set; }
        public IEnumerable<Platos> platos { get; set; }
    }
}
