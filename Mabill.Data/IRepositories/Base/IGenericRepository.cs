using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Data.IRepositories.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> expression, bool disableTracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool disableTracking = true);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity, bool disableTracking = false);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        Task SaveChangesAsync();
    }
}
