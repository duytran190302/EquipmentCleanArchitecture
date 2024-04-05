using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.ChangeEquipmentStatus;

public class ChangeEquipmentStatusHandler : IRequestHandler<ChangeEquipmentStatus, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public ChangeEquipmentStatusHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(ChangeEquipmentStatus request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new ChangeEquipmentStatusValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid ET", validatorResult);
		}
		//convert
		foreach (var id in request.Equipments)
		{
			var equipToChange = await _unitOfWork.equipmentRepository.GetByIdAsync(id);
			equipToChange.Status = request.Status;
			_unitOfWork.equipmentRepository.Update(equipToChange);
		}

		await _unitOfWork.SaveChangeAsync();
		//return 
		return request.Equipments.First();
	}
			
}
