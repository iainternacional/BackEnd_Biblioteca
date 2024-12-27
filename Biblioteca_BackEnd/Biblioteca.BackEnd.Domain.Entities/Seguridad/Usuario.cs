using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Domain.Entities.Seguridad
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(5)]
        public string? CodUsuario { get; set; }
        public int CambiaClave { get; set; }
        [Required]
        [StringLength(8000)]
        public string? Clave1 { get; set; }
        public int? IdEstado { get; set; }

        public DateTime FechaCrea { get; set; }

        public DateTime? FechaModifica { get; set; }
        [Required]
        [StringLength(5)]
        public string? CodUsuarioCrea { get; set; }
        [StringLength(5)]
        public string? CodUsuarioModifica { get; set; }
    }
}
