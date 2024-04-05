
using System.ComponentModel.DataAnnotations;

namespace EquipmentManagement.Domain
{
	public class EquipmentType 
	{
		public string EquipmentTypeId { get; set; } = string.Empty;
		public string EquipmentTypeName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		//
		[EnumDataType(typeof(Category))]
		public Category Category { get; set; }

		public List<Picture>? Pictures { get; set; }
		public List<Tag> Tags { get; set; }
		public List<Specification> Specifications { get; set; }
	}
}
