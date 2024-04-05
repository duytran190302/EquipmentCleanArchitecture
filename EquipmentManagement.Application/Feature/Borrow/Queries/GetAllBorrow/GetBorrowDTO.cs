namespace EquipmentManagement.Application.Feature.Borrow.Queries.GetAllBorrow;

public class GetBorrowDTO
{
	public string BorrowId { get; set; } = string.Empty;
	public DateTime BorrowedDate { get; set; }

	public DateTime ReturnedDate { get; set; }
	public DateTime? RealReturnedDate { get; set; }

	public string Borrower { get; set; } = string.Empty;
	public string Reason { get; set; } = string.Empty;
	public bool OnSide { get; set; }
	public string ProjectName { get; set; } = string.Empty;
	public List<string> Equipments { get; set; }
}
