using EquipmentManagement.Application.Contract.Persistence.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManagement.Persistence.DatabaseContext;
using System.Linq.Expressions;

namespace EquipmentManagement.Persistence.Repository.Generic;

public class RepositoryBase<T, Key> : RepositoryQueryBase<T, Key>,
	IRepositoryBaseAsync<T, Key>
	where T : class
{
	protected readonly ManageEquipmentDbContext _context;

	public RepositoryBase(ManageEquipmentDbContext context) : base(context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(_context));

	}

	public void Add(T entity)
	{
		_context.Set<T>().AddAsync(entity);
	}
	public void AddRange(IEnumerable<T> entities)
	{
		_context.Set<T>().AddRangeAsync(entities);
	}
	
	public void Remove(T entity)
	{
	   _context.Set<T>().Remove(entity);
	}
	public void RemoveRange(IEnumerable<T> entities)
	{
		_context.Set<T>().RemoveRange(entities);
	}

	public void Update(T entity)
	{
		_context.Set<T>().Update(entity);
	}
}
