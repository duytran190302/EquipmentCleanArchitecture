using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using EquipmentManagement.Persistence.Repository.Generic;

namespace EquipmentManagement.Persistence.Repository
{
	public class EquipmentTypeRepository: RepositoryBase<EquipmentType,string>,IEquipmentTypeRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public EquipmentTypeRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}
	}


}
