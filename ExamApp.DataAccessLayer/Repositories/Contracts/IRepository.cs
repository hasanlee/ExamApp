using System.Linq.Expressions;
using ExamApp.Common.Entities;

namespace ExamApp.DataAccessLayer.Repositories.Contracts
{
    public interface IRepository<T> where T : class,IBaseEntity, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includePropertires);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includePropertires);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

    }
}
