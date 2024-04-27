using M1_G1_Admin.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace M1_G1_Admin.Pages
{
    public class MostrarPlato : PageModel
    {
        public int promocion_id { get; set; }

        public IEnumerable<Platos> listadeplatos { get; set; }
        
    }
}
