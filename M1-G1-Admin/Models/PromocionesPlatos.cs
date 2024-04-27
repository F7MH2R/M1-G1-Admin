using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class PromocionesPlatos : DbContext
    {
        [Key]
        public int promocion_id { get; set; }
        public string plato_id { get; set; }
    }
}
