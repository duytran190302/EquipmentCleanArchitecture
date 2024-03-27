using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;

namespace EquipmentManagement.Persistence.Repository
{
	public class SupplierRepository: GenericRepository<Supplier>,ISupplierRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public SupplierRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}
	}


}
