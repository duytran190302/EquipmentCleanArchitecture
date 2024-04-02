using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using EquipmentManagement.Persistence.Repository.Generic;

namespace EquipmentManagement.Persistence.Repository
{
	public class LocationRepository: RepositoryBase<Location,string>,ILocationRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public LocationRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}


	}


}
