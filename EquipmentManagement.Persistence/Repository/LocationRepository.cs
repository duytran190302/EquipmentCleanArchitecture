using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;

namespace EquipmentManagement.Persistence.Repository
{
	public class LocationRepository: GenericRepository<Location>,ILocationRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public LocationRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}

		public async Task<Location> UpdateAsync(Location entity)
		{
			_manageEquipmentDbContext.Location.Update(entity);
			await _manageEquipmentDbContext.SaveChangesAsync();
			return entity;
		}
	}


}
