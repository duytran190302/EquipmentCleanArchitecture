using EquipmentManagement.Application.Contract.Persis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Contract.Persistence.Generic;

public interface IUnitOfWork<TContext> : IDisposable 
{
	IBorrowRepository BorrowRepository { get; }
	IEquipmentRepository EquipmentRepository { get; }
	ILocationRepository LocationRepository { get; }
	IEquipmentTypeRepository EquipmentTypeRepository { get; }
	IPictureRepository PictureRepository { get; }
	IProjectRepository ProjectRepository { get; }
	ISpecificationRepository SpecificationRepository { get; }
	ISupplierRepository SupplierRepository { get; }
	ITagRepository TagRepository { get; }
	Task<int> CommitAsync();

	Task SaveChangeAsync();
}