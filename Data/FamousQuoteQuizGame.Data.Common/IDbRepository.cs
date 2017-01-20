namespace FamousQuoteQuizGame.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using FamousQuoteQuizGame.Data.Models;

    public interface IDbRepository<T> where T: BaseModel 
    {
        void Add(T entity);

        void Add(IEnumerable<T> entities);

        void Remove(T entity);

        void Remove(IEnumerable<T> entities);

        void PermanentRemove(T entity);

        T GetById(int id);

        T FirstOrDefault();

        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithDeleted();
    }
}
