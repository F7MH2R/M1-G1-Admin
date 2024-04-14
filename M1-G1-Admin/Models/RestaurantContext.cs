using Microsoft.EntityFrameworkCore;

namespace M1_G1_Admin.Models
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {


        }
        public DbSet<Cargo> cargo { get; set; }
        public DbSet<Combos> combos { get; set; } 
        public DbSet<Categoria_Platos> categorias_platos { get; set; }
        public DbSet<Mesa> mesa { get; set; }
        public  DbSet<Platos> platos { get; set; }
        public DbSet<Promociones> promociones { get; set;}
        public DbSet<Estado> estado { get; set; }
        public DbSet<Empleado> empleados { get; set; }

    }
}
