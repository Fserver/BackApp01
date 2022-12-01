using System.ComponentModel.DataAnnotations;

namespace ProyectoFrontBack.Models
{
    public class Inspeccion
    {
        public int Id { get; set; }
        public int EstadoId { get; set; }
        public Estado? Estado { get; set; }
        [StringLength(200)]
        public string Comentarios { get; set; }
        public int TipoInspeccionId { get; set; }
        public TipoInspeccion? TipoInspeccion { get; set; }

    }
}
