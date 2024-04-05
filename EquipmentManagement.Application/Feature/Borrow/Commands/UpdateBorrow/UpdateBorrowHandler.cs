using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Borrow.Commands.UpdateBorrow;

public class UpdateBorrowHandler : IRequestHandler<UpdateBorrow, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateBorrowHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(UpdateBorrow request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new UpdateBorrowValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid ", validatorResult);
		}
		//convert
		var borrow = await _unitOfWork.borrowRepository.GetByIdAsync(request.BorrowId);
		borrow.BorrowedDate = request.BorrowedDate;
		borrow.RealReturnedDate= request.RealReturnedDate;
		borrow.Borrower= request.Borrower;
		borrow.Reason= request.Reason;
		borrow.OnSide= request.OnSide;
		borrow.RealReturnedDate = request.RealReturnedDate;
		_unitOfWork.borrowRepository.Update(borrow);
		await _unitOfWork.SaveChangeAsync();
		//return 
		return request.BorrowId;
	}
}
