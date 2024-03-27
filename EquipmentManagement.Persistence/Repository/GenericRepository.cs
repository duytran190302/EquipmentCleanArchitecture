using EquipmentManagement.Application.Persistence;
using EquipmentManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Persistence.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		internal DbSet<T> dbSet;
		public GenericRepository(ManageEquipmentDbContext manageEquipmentDbContext)
        {
			_manageEquipmentDbContext = manageEquipmentDbContext;
			this.dbSet = _manageEquipmentDbContext.Set<T>();
		}
        public async Task CreateAsync(T entity)
		{
			await dbSet.AddAsync(entity);
			await SaveAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			dbSet.Remove(entity);
			await SaveAsync();
		}

		public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
		{
			IQueryable<T> query = dbSet;
			query = query.AsNoTracking();
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query.ToListAsync();
			//return await _manageEquipmentDbContext.Set<T>().AsNoTracking().ToListAsync();
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null)
		{
			IQueryable<T> query = dbSet;

				query = query.AsNoTracking();
			
			if (filter != null)
			{
				query = query.Where(filter);
			}


			return await query.FirstOrDefaultAsync();
		}



		public async Task SaveAsync()
		{
			await _manageEquipmentDbContext.SaveChangesAsync();
		}
	}


}
