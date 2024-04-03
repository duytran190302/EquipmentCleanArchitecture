using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.Supplier.Commands.DeleteSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.EquipmentType.Commands.DeleteET;
public class DeleteETHandler : IRequestHandler<DeleteET, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteETHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(DeleteET request, CancellationToken cancellationToken)
	{


		var picToDelete =  _unitOfWork.pictureRepository.FindByCondition(x=>x.EquipmentTypeId==request.EquipmentTypeId);
		_unitOfWork.pictureRepository.RemoveRange(picToDelete);
		var specToDelete = _unitOfWork.specificationRepository.FindByCondition(x=>x.EquipmentTypeId== request.EquipmentTypeId);
		_unitOfWork.specificationRepository.RemoveRange(specToDelete);
		var etToDelete= await _unitOfWork.equipmentTypeRepository.GetByIdAsync(request.EquipmentTypeId);
		_unitOfWork.equipmentTypeRepository.Remove(etToDelete);
		await _unitOfWork.SaveChangeAsync();



		return request.EquipmentTypeId;
	}
}
