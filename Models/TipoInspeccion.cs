using System.ComponentModel.DataAnnotations;

namespace ProyectoFrontBack.Models
{
    public class TipoInspeccion
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }

    }
}
