using EquipmentManagement.Application.Contract.Email;
using EquipmentManagement.Application.Contract.Gmail;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Models.Email;
using EquipmentManagement.Application.Models.Gmail;
using EquipmentManagement.Infrastructure.EmailService;
using EquipmentManagement.Infrastructure.GmailService;
using EquipmentManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentManagement.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailSender, EmailSender>();

			services.Configure<GmailSettings>(configuration.GetSection("GmailSettings"));
			services.AddTransient<IGmailSender, GmailSender>();
			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
			return services;
		}
	}
}