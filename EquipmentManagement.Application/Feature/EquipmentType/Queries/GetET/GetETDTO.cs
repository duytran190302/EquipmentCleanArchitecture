using EquipmentManagement.Domain;
using System.ComponentModel.DataAnnotations;

namespace EquipmentManagement.Application.Feature.EquipmentType.Queries.GetET;

public class GetETDTO
{
	public string EquipmentTypeId { get; set; } = string.Empty;
	public string EquipmentTypeName { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	//
	[EnumDataType(typeof(Category))]
	public Category Category { get; set; }
	public List<string>? Tags {  get; set; }
}
