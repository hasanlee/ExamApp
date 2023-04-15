using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ExamApp.Common.Entities;
using ExamApp.DataAccessLayer.Context;
using ExamApp.DataAccessLayer.Repositories.Contracts;

namespace ExamApp.DataAccessLayer.Repositories.Concretes
{
    public class Repository<T>: IRepository<T> where T : class,IBaseEntity,new()
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> table = null;

        public Repository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            table = _dbContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate = null, params Expression<Func<T, object>>[] includePropertires)
        {
            IQueryable<T> query = table;
            if(predicate != null) 
                query = query.Where(predicate);
            if (includePropertires.Any())
                foreach (var item in includePropertires)
                    query = query.Include(item);
            
            return await query.ToListAsync();
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includePropertires)
        {
            IQueryable<T> query = table;
            query = query.Where(predicate);

            if (includePropertires.Any())
                foreach (var item in includePropertires)
                    query = query.Include(item);

            return await query.SingleAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await table.AddAsync(entity);
        }

        public T Update(T entity)
        {
            table.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
           return await table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is not null)
                return await table.CountAsync(predicate);
            return await table.CountAsync();
        }
    }
}
