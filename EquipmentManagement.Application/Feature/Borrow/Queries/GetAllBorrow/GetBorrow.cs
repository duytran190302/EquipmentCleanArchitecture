using MediatR;

namespace EquipmentManagement.Application.Feature.Borrow.Queries.GetAllBorrow;

public class GetBorrow : IRequest<List<GetBorrowDTO>>
{
	public string? ProjectName { get; set; } = string.Empty;
	public string? Borrower { get; set; } = string.Empty;
	public bool? OnSide { get; set; }
	public string? BorrowId { get; set; } = string.Empty;
	public DateTime? BorrowedDate { get; set; }

	public DateTime? ReturnedDate { get; set; }
}
