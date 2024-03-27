using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;

namespace EquipmentManagement.Persistence.Repository
{
	public class ProjectRepository: GenericRepository<Project>,IProjectRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public ProjectRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}
	}


}
