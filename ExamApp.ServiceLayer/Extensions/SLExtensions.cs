using ExamApp.ServiceLayer.Services.Concretes;
using ExamApp.ServiceLayer.Services.Contracts;
using ExamApp.ServiceLayer.Validations;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExamApp.ServiceLayer.Extensions
{
    public static class SLExtensions
    {
        public static IServiceCollection GetSLExtensions(this IServiceCollection services)
        {
            services.AddScoped<IExamService,ExamService>();
            services.AddScoped<IStudentService,StudentService>();
            services.AddScoped<ILessonService,LessonService>();
            services.AddScoped<IDashboardService,DashboardService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddControllersWithViews().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<LessonValidator>();
                options.DisableDataAnnotationsValidation = true;
            });
            return services;
        }
    }
}
