namespace FamousQuoteQuizGame.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using FamousQuoteQuizGame.Data.Models;

    public class DbRepository<T> : IDbRepository<T> where T : BaseModel
    {
        private readonly IDbSet<T> dbSet;

        public DbRepository(IDbSet<T> dbSet)
        {
            this.dbSet = dbSet;
        }
        public void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Add(entity);
            }
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public T FirstOrDefault()
        {
            return this.dbSet.FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T,bool>> predicate)
        {
            return this.dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return this.dbSet.Where(x => !x.IsDeleted);
        }
        public IQueryable<T> GetAllWithDeleted()
        {
            return this.dbSet;
        }

        public T GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void PermanentRemove(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public void Remove(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Remove(entity);
            }
        }

        public void Remove(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            this.dbSet.Remove(entity);
        }
    }
}
