namespace EquipmentManagement.Domain
{
	public class Specification
	{
		public string Name { get; set; } = string.Empty;
		public string Value { get; set; } = string.Empty;
		public string Unit { get; set; } = string.Empty;
		public EquipmentType EquipmentType { get; set; }

	}
}
