using EquipmentManagement.Application.Persistence;
using EquipmentManagement.Domain;
namespace EquipmentManagement.Application.Contract.Persis
{
	public interface ILocationRepository : IGenericRepository<Location>
	{
		Task<Location> UpdateAsync(Location entity);
	}
}
