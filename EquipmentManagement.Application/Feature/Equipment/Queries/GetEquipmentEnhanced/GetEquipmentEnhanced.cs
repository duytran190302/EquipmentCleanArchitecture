using EquipmentManagement.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipmentEnhanced;

public class GetEquipmentEnhanced : IRequest<List<GetEquipmentEnhancedDTO>>
{
	public string? EquipmentId { get; set; } 
	public string? EquipmentName { get; set; }
	public int? YearOfSupply { get; set; } = null;
	public string? CodeOfManager { get; set; } 
	public string? EquipmentTypeId { get; set; } 
	[EnumDataType(typeof(EquipmentStatus))]
	public EquipmentStatus? Status { get; set; }
	public string? LocationId { get; set; } 
	public string? SupplierName { get; set; } 
	public List<string>? TagId { get; set; }
	public Domain.Category? Category { get; set; }
}
