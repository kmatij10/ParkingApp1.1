using Microsoft.Extensions.DependencyInjection;
using Protests.Core.Repositories.Cities;
using Protests.Core.Repositories.Comments;
using Protests.Core.Repositories.Protests;

namespace Protests.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IProtestRepository, ProtestRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
        }
    }
}