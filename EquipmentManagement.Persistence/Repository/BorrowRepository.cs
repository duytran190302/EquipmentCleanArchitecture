using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using EquipmentManagement.Persistence.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManagement.Persistence.Repository
{
	public class BorrowRepository : RepositoryBase<Borrow,string>, IBorrowRepository
	{
		public BorrowRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
		}


	}


}
