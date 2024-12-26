using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Domain.Entities.Biblioteca
{
    public class Autor
    {
        public string? NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? CiudadProcedencia { get; set; }
        public string? CorreoElectronico { get; set; }
    }
}
