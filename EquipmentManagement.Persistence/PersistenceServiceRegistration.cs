using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using EquipmentManagement.Persistence.Repository;
using EquipmentManagement.Persistence.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentManagement.Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<ManageEquipmentDbContext>(options => {
				options.UseSqlServer(configuration.GetConnectionString("Fablab"));
			});

			services.AddScoped(typeof(IRepositoryBaseAsync<,>), typeof(RepositoryBase<,>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IBorrowRepository, BorrowRepository>();
			services.AddScoped<IEquipmentRepository, EquipmentRepository>();
			services.AddScoped<IEquipmentTypeRepository, EquipmentTypeRepository>();
			services.AddScoped<ILocationRepository, LocationRepository>();
			services.AddScoped<IPictureRepository, PictureRepository>();
			services.AddScoped<ISpecificationRepository, SpecificationRepository>();
			services.AddScoped<ISupplierRepository, SupplierRepository>();
			services.AddScoped<ITagRepository, TagRepository>();

			return services;
		}
	}

}