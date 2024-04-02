using EquipmentManagement.Infrastructure;
using EquipmentManagement.Persistence;
using EquipmentManagement.Application;
using EquipmentManagement.API.Middleware;
using Microsoft.Extensions.DependencyInjection;
using EquipmentManagement.Infrastructure.Communication;
using Buffer = EquipmentManagement.API.Worker.Buffer;
using EquipmentManagement.API.Hubs;
using EquipmentManagement.API.Worker;

namespace EquipmentManagement.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddApplicationServices();
			builder.Services.AddInfrastructureServices(builder.Configuration);
			builder.Services.AddPersistenceServices(builder.Configuration);



			builder.Services.AddControllers();
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAll",
					builder =>
					{
						builder
						//.AllowAnyOrigin()
						.WithOrigins("localhost",
						"http://localhost:5173",
						"http://localhost:3000",
						"http://192.168.123.199:3000")
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials();
					});
			});
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.Configure<MqttOptions>(builder.Configuration.GetSection("MqttOptions"));

			builder.Services.AddSignalR();
			builder.Services.AddSingleton<ManagedMqttClient>();
			builder.Services.AddSingleton<Buffer>();
			builder.Services.AddHostedService<ScadaHost>();
			var app = builder.Build();
			// check exception
			app.UseMiddleware<ExceptionMiddleware>();


			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();
			app.UseCors("AllowAll");

			app.MapControllers();
			app.MapHub<NotificationHub>("/notificationHub");
			app.Run();
		}
	}
}