﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Infrastructure.Framework.RepositoryPattern
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entityList);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(params object[] id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        IEnumerable<T> GetQueryable(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetListAllAsync();
        IEnumerable<T> GetAllQueryable();
        int Commit();
        void ExecuteSqlCommand(string procedureName, object parameteres);
        DataSet ExecuteStoreProcedure(string sqlQuery, List<DbParameter> parameters);
        IEnumerable<TEntityVO> ExecuteStoreProcedure<TEntityVO>(string procedureName, object parameters);
    }
}
