
using System.ComponentModel.DataAnnotations;

namespace EquipmentManagement.Domain
{
	public class Equipment
	{
		public string EquipmentId { get; set; } = string.Empty;
		public string EquipmentName { get; set; } = string.Empty;
		public DateTime YearOfSupply { get; set; }
		public string CodeOfManager { get; set; } = string.Empty;
		//
		//public string LocationId { get; set; } = string.Empty;
		public Location Location { get; set; }

		//public string SupplierName { get; set; } = string.Empty;
		public Supplier Supplier { get; set; }

		[EnumDataType(typeof(EquipmentStatus))]
		public EquipmentStatus Status { get; set; }

		public string EquipmentTypeId { get; set; } = string.Empty;
		public EquipmentType EquipmentType { get; set; }

		public List<Borrow>? Borrows { get; set; }

		public Project? Project { get; set; }
	}
}
