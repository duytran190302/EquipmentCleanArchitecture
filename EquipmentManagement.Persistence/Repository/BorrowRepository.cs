using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Persistence;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManagement.Persistence.Repository
{
	public class BorrowRepository : GenericRepository<Borrow>, IBorrowRepository
	{
		private readonly  ManageEquipmentDbContext _manageEquipmentDbContext;
		public BorrowRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}


	}


}
