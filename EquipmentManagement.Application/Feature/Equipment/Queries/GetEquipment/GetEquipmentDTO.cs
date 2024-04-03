using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetET;
using EquipmentManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipment;
public class GetEquipmentDTO
{
	public string EquipmentId { get; set; } = string.Empty;
	public string EquipmentName { get; set; } = string.Empty;
	public DateTime YearOfSupply { get; set; }
	public string CodeOfManager { get; set; } = string.Empty;
	[EnumDataType(typeof(EquipmentStatus))]
	public EquipmentStatus Status { get; set; } 
	public string EquipmentTypeId { get; set; } = string.Empty;
	public string LocationId { get; set; } = string.Empty;
	public string SupplierName { get; set; } = string.Empty;
	public List<string>? Tags { get; set; }
}