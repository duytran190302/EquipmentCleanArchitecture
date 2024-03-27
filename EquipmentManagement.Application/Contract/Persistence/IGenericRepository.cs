using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Persistence
{
	public interface IGenericRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
		Task CreateAsync(T entity);
		Task DeleteAsync(T entity);
		Task<T> GetAsync(Expression<Func<T, bool>> filter = null);
	}


}
