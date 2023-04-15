using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Common.Entities;
using ExamApp.DataAccessLayer.Repositories.Contracts;

namespace ExamApp.DataAccessLayer.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class,IBaseEntity,new();
        Task<int> SaveAsync();
        int Save();
    }
}
