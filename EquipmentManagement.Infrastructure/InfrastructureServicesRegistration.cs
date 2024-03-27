using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentManagement.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
			return services;
		}
	}
}