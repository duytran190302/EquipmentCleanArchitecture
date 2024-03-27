using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;

namespace EquipmentManagement.Persistence.Repository
{
	public class EquipmentTypeRepository: GenericRepository<EquipmentType>,IEquipmentTypeRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public EquipmentTypeRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}
	}


}
