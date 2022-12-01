using System.ComponentModel.DataAnnotations;

namespace ProyectoFrontBack.Models
{
    public class Estado
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string OpcionEstado { get; set; }

    }
}
