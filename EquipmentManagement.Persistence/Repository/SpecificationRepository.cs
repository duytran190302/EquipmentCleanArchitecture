using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;

namespace EquipmentManagement.Persistence.Repository
{
	public class SpecificationRepository: GenericRepository<Specification>,ISpecificationRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public SpecificationRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}
	}


}
