using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Contract.Persistence
{
	public interface IBorrowRepository : IRepositoryBaseAsync<Borrow,string>
	{
	}
}
