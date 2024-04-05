using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Domain;
using FluentValidation;
using MediatR;

namespace EquipmentManagement.Application.Feature.Borrow.Commands.CreateBorrow;

public class CreateBorrowHandler : IRequestHandler<CreateBorrow, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateBorrowHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(CreateBorrow request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CreateBorrowValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid", validatorResult);
		}
		//convert
		var project = await _unitOfWork.projectRepository.GetByIdAsync(request.ProjectName);
		if (project.Approved == true)
		{
			var equipFromProject = _unitOfWork.equipmentRepository.FindByCondition(x => x.Project.ProjectName == request.ProjectName, trackChanges: true).ToList();
			var equipToBorrow = equipFromProject.Where(x => request.Equipments.Any(equip => equip == x.EquipmentId)).ToList();
			equipToBorrow= equipToBorrow.Where(x=>x.Status==EquipmentStatus.Active).ToList();
			var borrow = new Domain.Borrow()
			{
				ProjectName = request.ProjectName,
				Equipments = equipToBorrow,
				BorrowedDate = request.BorrowedDate,
				Borrower = request.Borrower,
				BorrowId = request.BorrowId,
				OnSide = request.OnSide,
				Project = await _unitOfWork.projectRepository.GetByIdAsync(request.ProjectName),
				Reason = request.Reason,
				ReturnedDate = request.ReturnedDate
				
			};

			_unitOfWork.borrowRepository.Add(borrow);
			foreach (var equip in equipToBorrow)
			{
				equip.Status=EquipmentStatus.Inactive;
				_unitOfWork.equipmentRepository.Update(equip);
			}
			await _unitOfWork.SaveChangeAsync();
		}
		else
		{
			throw new BadRequestException("Invalid", validatorResult);
		}

		//return 
		return request.ProjectName;
	}
}
