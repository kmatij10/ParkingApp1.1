using Microsoft.Extensions.DependencyInjection;
using Parking.Core.Repositories.Cars;
using Parking.Core.Repositories.Drivers;
using Parking.Core.Repositories.Payments;
using Parking.Core.Repositories.ParkingSpaces;
using Parking.Core.Repositories.ParkingTypes;
using Parking.Core.Repositories.PaymentPanels;
using Parking.Core.Repositories.Rates;
using Parking.Core.Repositories.RequestStatuses;
using Parking.Core.Repositories.Parkings;

namespace Parking.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IParkingSpaceRepository, ParkingSpaceRepository>();
            services.AddScoped<IParkingTypeRepository, ParkingTypeRepository>();
            services.AddScoped<IPaymentPanelRepository, PaymentPanelRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();
            services.AddScoped<IParkedRepository, ParkedRepository>();
        }
    }
}