using EquipmentManagement.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.UpdateEquipment;

public class UpdateEquipment : IRequest<string>
{
	public string EquipmentId { get; set; } = string.Empty;
	public string EquipmentName { get; set; } = string.Empty;
	public DateTime YearOfSupply { get; set; }
	public string CodeOfManager { get; set; } = string.Empty;
	[EnumDataType(typeof(Domain.EquipmentStatus))]
	public Domain.EquipmentStatus Status { get; set; } = Domain.EquipmentStatus.Active;
	public string EquipmentTypeId { get; set; } = string.Empty;
	public string LocationId { get; set; } = string.Empty;
	public string SupplierName { get; set; } = string.Empty;

}

