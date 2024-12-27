using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Domain.Entities.Response.Biblioteca
{
    public class LibroResponse
    {
        public int IdLibro { get; set; }
        public Boolean Exito { get; set; }
        public string? MensajeError { get; set; }
    }
}
