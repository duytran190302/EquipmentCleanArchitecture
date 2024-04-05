using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Persistence.Repository.Generic;

public class UnitOfWork : IUnitOfWork 
{
	private readonly ManageEquipmentDbContext _context;

	public UnitOfWork(ManageEquipmentDbContext context)
	{
		_context = context;
		borrowRepository = new BorrowRepository(context);
		equipmentRepository = new EquipmentRepository(context);
		equipmentTypeRepository = new EquipmentTypeRepository(context);
		locationRepository = new LocationRepository(context);
		pictureRepository= new PictureRepository(context);
		projectRepository= new ProjectRepository(context);
		specificationRepository = new SpecificationRepository(context);
		supplierRepository = new SupplierRepository(context);
		tagRepository= new TagRepository(context);

	}
	public IBorrowRepository borrowRepository { get; private set; }
	public IEquipmentRepository equipmentRepository { get; private set; }
	public IEquipmentTypeRepository	equipmentTypeRepository { get; private set; }
	public ILocationRepository locationRepository { get; private set; }
	public IPictureRepository pictureRepository { get; private set; }
	public IProjectRepository projectRepository { get; private set; }
	public ISpecificationRepository specificationRepository { get; private set; }
	public ISupplierRepository supplierRepository { get; private set; }
	public ITagRepository tagRepository { get; private set; }

	public async Task<int> CommitAsync()
	{
		return await _context.SaveChangesAsync();
	}

	public void Dispose()
	{
		_context.Dispose();
	}

	public async Task SaveChangeAsync()
	{
		await _context.SaveChangesAsync();
	}
}
