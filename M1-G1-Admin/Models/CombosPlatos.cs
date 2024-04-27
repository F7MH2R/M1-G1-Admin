using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M1_G1_Admin.Models
{
    public class CombosPlatos
    {
        [Key, Column(Order = 0)]
        public int combo_id {  get; set; }
        [Key, Column(Order = 1)]
        public int plato_id { get; set; }
    }
}
