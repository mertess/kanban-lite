using KanbanLite.Core.Db;
using KanbanLite.Core.Db.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KanbanLite.Core
{
    public class DiBootstrapper
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KanbanLiteDbContext>(contextBuilder =>
                contextBuilder.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    options => options.MigrationsAssembly("KanbanLite.Migrations")
                )
            );

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<BoardRepository>();
            services.AddScoped<StageRepository>();
            services.AddScoped<TaskRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
