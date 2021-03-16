using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VSTrain.Core.Contracts;
using VSTrain.Persistence.Repos;

namespace VSTrain.Persistence.Extensions
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VSTrainDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("VSTrainConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICourseRepository), typeof(CourseRepository));
            //services.AddScoped<ICourseRepository, CourseRepository>();
            return services;
        }
    }
}