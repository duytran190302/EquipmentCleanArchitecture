
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Contract.Persis
{
	public interface IEquipmentTypeRepository : IRepositoryBaseAsync<EquipmentType, string>
	{
		object FindAll(bool trackChanges, Func<object, object> includeProperties, Func<object, object> value);
	}


}
