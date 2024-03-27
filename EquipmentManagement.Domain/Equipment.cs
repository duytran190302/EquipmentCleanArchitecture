namespace EquipmentManagement.Domain
{
	public class Equipment
	{
		public string EquipmentId { get; set; } = string.Empty;
		public string EquipmentName { get; set; } = string.Empty;
		public DateTime YearOfSupply { get; set; }
		public string CodeOfManager { get; set; } = string.Empty;
		//
		public Location Location { get; set; }
		public Supplier Supplier { get; set; }
		public EquipmentStatus Status { get; set; }
		public EquipmentType EquipmentType { get; set; }

		public List<Borrow> Borrows { get; set; }


	}
}
