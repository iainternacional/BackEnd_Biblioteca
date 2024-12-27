using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Domain.Entities.Biblioteca
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        public string? NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? CiudadProcedencia { get; set; }
        public string? CorreoElectronico { get; set; }
        public DateTime FechaCrea { get; set; }
        public string? CodUsuarioCrea { get; set; }
        public DateTime? FechaModifica { get; set; }
        public string? CodUsuarioModifica { get; set; }
    }
}
