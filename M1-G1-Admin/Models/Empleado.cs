using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Empleado
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? dui { get; set; }
        public string? fecha_nacimiento { get; set; }
        public string?  telefono { get; set; }
        public string? direccion { get; set; }
        public string? telefono_referencia { get; set; }
        public int cargo_id { get; set; }
        public int estado_id { get; set; }
        public decimal salario { get; set; }
        public string? fecha_concentracion { get; set; }

    }
}
