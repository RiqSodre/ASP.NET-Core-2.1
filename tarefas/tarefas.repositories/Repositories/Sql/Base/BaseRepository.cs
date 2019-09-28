using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tarefas.repositories.Repositories.Interfaces;

namespace tarefas.repositories.Repositories.Sql.Base
{
    public abstract class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>  where TContext : DbContext where TEntity : class
    {
        protected DbSet<TEntity> dbSet { get; set; }
        protected TContext context { get; set; }

        public BaseRepository(TContext context, DbSet<TEntity> dbSet)
        {
            this.dbSet = dbSet;
            this.context = context;
        }

        public async Task Create(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
