using Microsoft.Extensions.DependencyInjection;
using Parking.Api.Services;
using Parking.Core.Repositories;

namespace Parking.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            // repositories
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IParkingSpaceRepository, ParkingSpaceRepository>();
            services.AddScoped<IParkingTypeRepository, ParkingTypeRepository>();
            services.AddScoped<IPaymentPanelRepository, PaymentPanelRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();
            services.AddScoped<IParkedRepository, ParkedRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();

            // services
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}