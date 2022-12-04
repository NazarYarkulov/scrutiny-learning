using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scrunity.Learning.Services;
using Scrunity.Learning.Services.Queries;

namespace Scrunity.Learning.Persistance
{
    public static class Bootstrap
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetStudentsQuery).Assembly);
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
