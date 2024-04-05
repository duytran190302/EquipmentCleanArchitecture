using MediatR;

namespace EquipmentManagement.Application.Feature.Borrow.Commands.CreateBorrow;

public class CreateBorrow : IRequest<string>
{
	public string BorrowId { get; set; } = string.Empty;
	public DateTime BorrowedDate { get; set; }

	public DateTime ReturnedDate { get; set; }

	public string Borrower { get; set; } = string.Empty;
	public string Reason { get; set; } = string.Empty;
	public bool OnSide { get; set; }
	public List<string>? Equipments { get; set; }
	public string ProjectName { get; set; } = string.Empty;
}
