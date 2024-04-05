using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Borrow.Commands.Return;

public class ReturnHandler : IRequestHandler<Return, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public ReturnHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(Return request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new ReturnValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid ", validatorResult);
		}
		//convert
		var borrow = await _unitOfWork.borrowRepository.GetByIdAsync(request.BorrowId);
		borrow.RealReturnedDate = request.RealReturnedDate;
		_unitOfWork.borrowRepository.Update(borrow);
		var equipTochange = _unitOfWork.equipmentRepository.FindByCondition(x=>x.Borrows.Any(x=>x.BorrowId==request.BorrowId), true, o=>o.Borrows).ToList();
		foreach (var equip in equipTochange)
		{
			equip.Status = Domain.EquipmentStatus.Active;
			_unitOfWork.equipmentRepository.Update(equip);
		}
		await _unitOfWork.SaveChangeAsync();
		//return 
		return request.BorrowId;
	}
}
