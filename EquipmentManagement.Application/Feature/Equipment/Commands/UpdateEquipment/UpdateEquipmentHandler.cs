using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.Equipment.Commands.CreateEquipment;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.UpdateEquipment;
public class UpdateEquipmentHandler : IRequestHandler<UpdateEquipment, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateEquipmentHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(UpdateEquipment request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new UpdateEquipmentValidation();
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
		_unitOfWork.equipmentRepository.Update(equipment);
		await _unitOfWork.SaveChangeAsync();
		//return 
		return request.EquipmentTypeId;
	}
}

