using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces;

namespace TaskManagementSystem.Infrastructure
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

        public async Task<TEntity> GetAsync(int id)
        {
            var entity = await EntitySet.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entity = await EntitySet.ToListAsync();
            return entity;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return EntitySet.Where(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await EntitySet.AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            EntitySet.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
