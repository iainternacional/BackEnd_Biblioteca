using Biblioteca.BackEnd.Domain.Entities.Biblioteca;
using Biblioteca.BackEnd.Domain.Entities.Request.Biblioteca;
using Biblioteca.BackEnd.Infrastructure.Framework.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Application.Services.Biblioteca
{
    public class LibrosService : ILibrosService
    {
        readonly IRepositoryBiblioteca<Libro> _repositoryLibros;
        public LibrosService(IRepositoryBiblioteca<Libro> repositoryLibros)
        {
            this._repositoryLibros = repositoryLibros;
        }
        public async Task<IEnumerable<Libro>> ObtenerListadoLibrosAsync()
        {
            try
            {
                return await _repositoryLibros.GetListAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje", ex);
            }
        }
        public Task<Libro> ObtenerLibroPorId(int id)
        {
            try
            {
                return Task.FromResult(this._repositoryLibros.GetById(id));
            }
            catch (Exception ex)
            {

                throw new Exception("Mensaje", ex);
            }
        }
        public void ActualizarLibro(LibroRequest libroRequest, string codUsuario)
        {
            try
            {
                var libroModificado = _repositoryLibros.GetById((int)libroRequest.IdLibro);

                libroModificado.CodUsuarioModifica = codUsuario;
                libroModificado.FechaModifica = DateTime.Now;
                libroModificado.Anio = libroRequest.Anio;
                libroModificado.Titulo = libroRequest.Titulo;
                libroModificado.Genero = libroRequest.Genero;
                libroModificado.NumeroPaginas = libroRequest.NumeroPaginas;
                libroModificado.Autor = libroRequest.Autor;

                _repositoryLibros.Update(libroModificado);
                _repositoryLibros.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje", ex);
            }
        }
        public int InsertarNuevoLibro(LibroRequest libroRequest, string codUsuario)
        {
            try
            {
                var nuevoLibro = new Libro
                {
                    Titulo = libroRequest.Titulo,
                    Anio = libroRequest.Anio,
                    Genero = libroRequest.Genero,
                    NumeroPaginas = libroRequest.NumeroPaginas,
                    Autor = libroRequest.Autor,
                    FechaCrea = DateTime.Now,
                    CodUsuarioCrea = codUsuario
                };

                _repositoryLibros.Add(nuevoLibro);
                _repositoryLibros.Commit();

                return nuevoLibro.IdLibro;
            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje", ex);
            }
        }
    }
}
