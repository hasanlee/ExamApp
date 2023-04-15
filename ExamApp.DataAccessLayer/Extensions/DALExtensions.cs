using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ExamApp.DataAccessLayer.Context;
using ExamApp.DataAccessLayer.Repositories.Concretes;
using ExamApp.DataAccessLayer.Repositories.Contracts;
using ExamApp.DataAccessLayer.UnitOfWorks;

namespace ExamApp.DataAccessLayer.Extensions
{
    public static class DALExtensions
    {
        public static IServiceCollection GetDALExtensions(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MainDbConnection")));
            return services;
        } 
    }
}
