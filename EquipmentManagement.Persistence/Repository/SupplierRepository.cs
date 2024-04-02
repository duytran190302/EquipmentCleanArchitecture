using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using EquipmentManagement.Persistence.Repository.Generic;

namespace EquipmentManagement.Persistence.Repository
{
	public class SupplierRepository: RepositoryBase<Supplier,string>,ISupplierRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public SupplierRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}
	}


}
