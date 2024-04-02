using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using EquipmentManagement.Persistence.Repository.Generic;

namespace EquipmentManagement.Persistence.Repository
{
	public class PictureRepository: RepositoryBase<Picture,int>,IPictureRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public PictureRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}
	}


}
