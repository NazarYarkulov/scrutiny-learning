using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Persistance
{
    public static class Bootstrap
    {
        public static void AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ILearningDbContext, LearningDbContext>(
                builder => builder.UseNpgsql(connectionString));
        }
    }
}
