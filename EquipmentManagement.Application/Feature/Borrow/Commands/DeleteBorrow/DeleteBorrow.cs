using MediatR;

namespace EquipmentManagement.Application.Feature.Borrow.Commands.DeleteBorrow;

public class DeleteBorrow : IRequest<string>
{
	public string BorrowId { get; set; } = string.Empty;
}
