using Biblioteca.BackEnd.Domain.Entities.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Domain.Entities.Request.Biblioteca
{
    public class LibroRequest
    {
        public int IdLibro { get; set; }
        public string? Titulo { get; set; }
        public int Anio { get; set; }
        public string? Genero { get; set; }
        public int NumeroPaginas { get; set; }
        public Autor? Autor { get; set; }
        public DateTime FechaCrea { get; set; }
        public string? CodUsuarioCrea { get; set; }
        public DateTime? FechaModifica { get; set; }
        public string? CodUsuarioModifica { get; set; }
    }
}
