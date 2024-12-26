using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Domain.Entities.Biblioteca
{
    public class Libro
    {
        public string? Titulo { get; set; }
        public int Anio { get; set; }
        public string? Genero { get; set; }
        public int NumeroPaginas { get; set; }

        public Autor? Autor { get; set; }
    }
}
