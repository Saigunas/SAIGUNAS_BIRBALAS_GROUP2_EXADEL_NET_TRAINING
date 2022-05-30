using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task5.DataAccessLayer.Persistence.Repositories
{
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected DbSet<TEntity> EntitySet;

        public Repository(DbContext context)
        {
            Context = context;
            EntitySet = context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return EntitySet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return EntitySet.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return EntitySet.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            EntitySet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            EntitySet.Remove(entity);
        }
    }
}
