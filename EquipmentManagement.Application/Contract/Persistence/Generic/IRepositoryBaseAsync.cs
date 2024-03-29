
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Contract.Persistence.Generic;

public interface IRepositoryQueryBase<T,Key>
	where T: class 
{
	IQueryable<T> FindAll(bool trackChanges = false);
	IQueryable<T> FindAll(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
	IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
	IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false,
		params Expression<Func<T, object>>[] includeProperties);

	Task<T?> GetByIdAsync(Key id);

}

public interface IRepositoryBaseAsync<T, K> : IRepositoryQueryBase<T, K>
	where T: class
{
	void Update(T entity);
	void Add(T entity);
	void AddRange(IEnumerable<T> entities);
	void Remove(T entity);
	void RemoveRange(IEnumerable<T> entities);

	//K Create(T entity);
	//Task<K> CreateAsync(T entity);
	//IList<K> CreateList(IEnumerable<T> entities);
	//Task<IList<K>> CreateListAsync(IEnumerable<T> entities);
	//void Update(T entity);
	//Task UpdateAsync(T entity);
	//void UpdateList(IEnumerable<T> entities);
	//Task UpdateListAsync(IEnumerable<T> entities);
	//void Delete(T entity);
	//Task DeleteAsync(T entity);
	//void DeleteList(IEnumerable<T> entities);
	//Task DeleteListAsync(IEnumerable<T> entities);
	//Task<int> SaveChangesAsync();


	//Task<IDbContextTransaction> BeginTransactionAsync();
	//Task EndTransactionAsync();
	//Task RollbackTransactionAsync();
	//Task SaveAsync();
	//void Save();
}



