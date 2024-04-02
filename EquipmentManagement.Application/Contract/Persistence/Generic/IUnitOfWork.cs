using EquipmentManagement.Application.Contract.Persis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Contract.Persistence.Generic;

public interface IUnitOfWork 
{
	IBorrowRepository borrowRepository { get; }
	IEquipmentRepository equipmentRepository { get; }
	ILocationRepository locationRepository { get; }
	IEquipmentTypeRepository equipmentTypeRepository { get; }
	IPictureRepository pictureRepository { get; }
	IProjectRepository projectRepository { get; }
	ISpecificationRepository specificationRepository { get; }
	ISupplierRepository supplierRepository { get; }
	ITagRepository tagRepository { get; }
	Task<int> CommitAsync();

	Task SaveChangeAsync();
}