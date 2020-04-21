using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using School.DataAccess.Entities;
using School.DataAccess.Contracts;

namespace School.DataAccess.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class , IEntity
    {
        #region ' variables and properties '

        protected SchoolContext _schoolContext; 

        #endregion

        #region ' methods '

        /// <summary>
        /// Constructor, initializes an instance of <see cref="BaseRepository{T}"/>
        /// </summary>
        /// <param name="schoolContext"></param>

        public BaseRepository(SchoolContext schoolContext)
        {
           this._schoolContext = schoolContext;
        }

        /// <inheritdoc <see cref="IRepository{T}">
        public IEnumerable<T> GetAll()
        {
            return this._schoolContext.Set<T>();
        }

        /// <inheritdoc <see cref="IRepository{T}">
        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return this._schoolContext.Set<T>().Where(filter);
        }

        /// <inheritdoc <see cref="IRepository{T}">
        public void Create(T entity)
        {
            this._schoolContext.Set<T>().Add(entity);
        }

        /// <inheritdoc <see cref="IRepository{T}">
        public void Delete(T entity)
        {
            this._schoolContext.Set<T>().Remove(entity);
        }

        /// <inheritdoc <see cref="IRepository{T}">
        public void Update(T entity)
        {
            this._schoolContext.Set<T>().Update(entity);
        } 

        #endregion
    }
}
