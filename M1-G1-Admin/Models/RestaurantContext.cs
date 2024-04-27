using M1_G1_Admin.Pages;
using Microsoft.EntityFrameworkCore;

namespace M1_G1_Admin.Models
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options){}
        public DbSet<Cargo> cargo { get; set; }
        public DbSet<Combos> combos { get; set; } 
        public DbSet<Categoria_Platos> categorias_platos { get; set; }
        public DbSet<Mesa> mesa { get; set; }
        public  DbSet<Platos> platos { get; set; }
        public DbSet<Promociones> promociones { get; set;}
        public DbSet<Empleado> empleado { get; set; }

        public DbSet<PromocionesPlatos> promociones_platos { get; set; }
        public DbSet<CombosPlatos> combos_platos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CombosPlatos>()
                .HasKey(entidad => new { entidad.combo_id, entidad.plato_id });
            modelBuilder.Entity<PromocionesPlatos>()
               .HasKey(entidad => new { entidad.promocion_id, entidad.plato_id });
        }

    }
}
