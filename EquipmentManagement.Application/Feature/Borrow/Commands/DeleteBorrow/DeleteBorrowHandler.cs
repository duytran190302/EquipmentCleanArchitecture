using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Feature.Equipment.Commands.DeleteEquipment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Borrow.Commands.DeleteBorrow;
public class DeleteBorrowHandler : IRequestHandler<DeleteBorrow, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteBorrowHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(DeleteBorrow request, CancellationToken cancellationToken)
	{


		var borrowToDelete = await _unitOfWork.borrowRepository.GetByIdAsync(request.BorrowId);
		_unitOfWork.borrowRepository.Remove(borrowToDelete);
		await _unitOfWork.SaveChangeAsync();



		return request.BorrowId;
	}
}