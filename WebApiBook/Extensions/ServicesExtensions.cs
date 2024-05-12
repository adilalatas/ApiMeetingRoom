using Microsoft.EntityFrameworkCore;
using Presentation.Controller.ActionFilters;
using Repository.Contracts;
using Repository.EFCore;
using Services;
using Services.Contracts;

namespace WebApiBook.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSglContext(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<RepositoryContext>(op => op.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerService, LoggerManager>();
        public static void ConfigureActionFilters(this IServiceCollection services) {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();

        }
    }
}
