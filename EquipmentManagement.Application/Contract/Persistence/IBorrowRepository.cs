using EquipmentManagement.Application.Persistence;
using EquipmentManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Contract.Persistence
{
	public interface IBorrowRepository : IGenericRepository<Borrow>
	{
	}
}
