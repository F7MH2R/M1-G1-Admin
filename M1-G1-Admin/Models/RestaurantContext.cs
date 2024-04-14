using Microsoft.EntityFrameworkCore;

namespace M1_G1_Admin.Models
{
    public class RestaurantContext:DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options): base (options)
        {


        }

    }
}
