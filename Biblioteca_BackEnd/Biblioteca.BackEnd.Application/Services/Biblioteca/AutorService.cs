using Biblioteca.BackEnd.Domain.Entities.Biblioteca;
using Biblioteca.BackEnd.Domain.Entities.Request.Biblioteca;
using Biblioteca.BackEnd.Infrastructure.Framework.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Application.Services.Biblioteca
{
    public class AutorService : IAutorService
    {
        readonly IRepositoryBiblioteca<Autor> repositoryAutor;

        public AutorService(IRepositoryBiblioteca<Autor> repositoryAutor)
        {
            this.repositoryAutor = repositoryAutor;
        }
        public Task<Autor> ObtenerAutorPorId(int id)
        {
            try
            {
                return Task.FromResult(this.repositoryAutor.GetById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int InsertarAutor(AutorRequest autorRequest)
        {
            try
            {
                var nuevoAutor = new Autor()
                {
                    NombreCompleto = autorRequest.NombreCompleto,
                    CiudadProcedencia = autorRequest.CiudadProcedencia,
                    CorreoElectronico = autorRequest.CorreoElectronico,
                    FechaNacimiento = autorRequest.FechaNacimiento
                };

                repositoryAutor.Add(nuevoAutor);
                repositoryAutor.Commit();

                return nuevoAutor.IdAutor;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ActualizarAutor(AutorRequest autorRequest, string codUsuario)
        {
            try
            {
                var autorModificado = repositoryAutor.GetById((int)autorRequest.IdAutor);

                autorModificado.CodUsuarioModifica = codUsuario;
                autorModificado.FechaModifica = DateTime.Now;
                autorModificado.CiudadProcedencia = autorRequest.CiudadProcedencia;
                autorModificado.FechaNacimiento = autorRequest.FechaNacimiento;
                autorModificado.CorreoElectronico = autorRequest.CorreoElectronico;
                autorModificado.NombreCompleto = autorRequest.NombreCompleto;

                repositoryAutor.Update(autorModificado);
                repositoryAutor.Commit();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
