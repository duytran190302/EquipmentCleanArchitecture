using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetET;
using EquipmentManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETEnhanced;
public class GetETEnhancedDTO
{
	public string EquipmentTypeId { get; set; } = string.Empty;
	public string EquipmentTypeName { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	//
	[EnumDataType(typeof(Category))]
	public Category Category { get; set; }
	public List<string>? Tags { get; set; }
}
