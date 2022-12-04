using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Scrunity.Learning.Persistance
{
    public static class Bootstrap
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
