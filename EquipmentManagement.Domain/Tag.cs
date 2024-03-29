

namespace EquipmentManagement.Domain
{
	public class Tag 
	{
		public string TagId { get; set; } = string.Empty;
		public string TagDetail { get; set; } = string.Empty;
		public List<EquipmentType> EquipmentTypes { get; set;}
	}
}
