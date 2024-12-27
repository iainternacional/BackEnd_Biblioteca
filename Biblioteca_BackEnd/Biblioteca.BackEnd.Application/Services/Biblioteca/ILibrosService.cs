using Biblioteca.BackEnd.Domain.Entities.Biblioteca;
using Biblioteca.BackEnd.Domain.Entities.Request.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Application.Services.Biblioteca
{
    public interface ILibrosService
    {
        Task<IEnumerable<Libro>> ObtenerListadoLibrosAsync();
        Task<Libro> ObtenerLibroPorId(int id);
        void ActualizarLibro(LibroRequest libroRequest, string codUsuario);
        int InsertarNuevoLibro(LibroRequest libroRequest, string codUsuario);
    }
}
