using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.CreateEquipment;

public class CreateEquipmentHandler : IRequestHandler<CreateEquipment, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateEquipmentHandler( IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(CreateEquipment request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CreateEquipmentValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid ET", validatorResult);
		}
		//convert
		var equipment = new Domain.Equipment()
		{
			EquipmentId = request.EquipmentId,
			EquipmentTypeId = request.EquipmentTypeId,
			CodeOfManager = request.CodeOfManager,
			YearOfSupply = request.YearOfSupply,
			EquipmentName = request.EquipmentName,
			Location = await _unitOfWork.locationRepository.GetByIdAsync(request.LocationId),
			Status = request.Status,
			Supplier = await _unitOfWork.supplierRepository.GetByIdAsync(request.SupplierName)
			
		};
		_unitOfWork.equipmentRepository.Add(equipment);
		await _unitOfWork.SaveChangeAsync();
		//return 
		return request.EquipmentTypeId;
	}
}
