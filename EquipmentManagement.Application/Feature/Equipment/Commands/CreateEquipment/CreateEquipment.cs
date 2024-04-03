using EquipmentManagement.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.CreateEquipment;

public class CreateEquipment : IRequest<string>
{
	public string EquipmentId { get; set; } = string.Empty;
	public string EquipmentName { get; set; } = string.Empty;
	public DateTime YearOfSupply { get; set; }
	public string CodeOfManager { get; set; } = string.Empty;
	[EnumDataType(typeof(EquipmentStatus))]
	public EquipmentStatus Status { get; set; } = EquipmentStatus.Active;
	public string EquipmentTypeId { get; set; } = string.Empty;
	public string LocationId {  get; set; } = string.Empty;	
	public string SupplierName { get; set; } = string.Empty;

}
