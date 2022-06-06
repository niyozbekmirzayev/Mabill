using Mabill.Data.DbContexts;
using Mabill.Data.IRepositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Data.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MabillDbContext context;
        private readonly DbSet<T> dbSet;
        private IQueryable<T> query;

        public GenericRepository(MabillDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            this.query = dbSet;
        }

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            T entity = await dbSet.FirstOrDefaultAsync(expression);
            if (entity == null)
                return false;

            dbSet.Remove(entity);
            await SaveChangesAsync();

            return true;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    string includeString = null, bool disableTracking = true)
        {
            if (disableTracking)
                query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString))
                query = query.Include(includeString);

            if (orderBy != null)
                query = orderBy(query);

            return expression == null ? query : query.Where(expression);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, string includeString = null,
                                      bool disableTracking = true)
        {
            if (disableTracking)
                query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString))
                query = query.Include(includeString);

            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entry = await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<T> UpdateAsync(T entity, bool disableTracking = false)
        {
            if (disableTracking)
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var entry = dbSet.Update(entity).Entity;
            await context.SaveChangesAsync();

            return entry;
        }
    }
}
