using Microsoft.Extensions.DependencyInjection;
using Fights.Core.Repositories.Cities;
using Fights.Core.Repositories.Comments;
using Fights.Core.Repositories.Organizers;
using Fights.Core.Repositories.Protests;

namespace Fights.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IProtestRepository, ProtestRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IOrganizerRepository, OrganizerRepository>();
        }
    }
}