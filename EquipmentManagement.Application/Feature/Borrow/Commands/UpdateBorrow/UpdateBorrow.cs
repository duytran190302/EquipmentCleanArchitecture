using MediatR;

namespace EquipmentManagement.Application.Feature.Borrow.Commands.UpdateBorrow;

public class UpdateBorrow : IRequest<string>
{
	public string BorrowId { get; set; } = string.Empty;
	public DateTime BorrowedDate { get; set; }
	public DateTime RealReturnedDate { get; set; }
	public DateTime ReturnedDate { get; set; }

	public string Borrower { get; set; } = string.Empty;
	public string Reason { get; set; } = string.Empty;
	public bool OnSide { get; set; }

}
