using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Infrastructure.Framework.RepositoryPattern
{
    public interface IRepositoryBiblioteca<T> : IRepository<T> where T : class
    {
    }
}
