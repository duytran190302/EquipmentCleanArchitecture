using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.DeleteEquipment;

public class DeleteEquipmentHandler : IRequestHandler<DeleteEquipment, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteEquipmentHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(DeleteEquipment request, CancellationToken cancellationToken)
	{


		var equipmentToDelete = await _unitOfWork.equipmentRepository.GetByIdAsync(request.EquipmentId);
		_unitOfWork.equipmentRepository.Remove(equipmentToDelete);
		await _unitOfWork.SaveChangeAsync();



		return request.EquipmentId;
	}
}