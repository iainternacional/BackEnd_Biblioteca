using Biblioteca.BackEnd.Domain.Entities.Biblioteca;
using Biblioteca.BackEnd.Domain.Entities.Request.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Application.Services.Biblioteca
{
    public interface IAutorService
    {
        Task<Autor> ObtenerAutorPorId(int id);
        int InsertarAutor(AutorRequest autorRequest);
        void ActualizarAutor(AutorRequest autorRequest, string codUsuario);
    }
}
