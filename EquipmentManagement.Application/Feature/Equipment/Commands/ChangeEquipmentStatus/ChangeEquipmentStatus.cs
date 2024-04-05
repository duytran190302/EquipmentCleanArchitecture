using EquipmentManagement.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.ChangeEquipmentStatus;

public class ChangeEquipmentStatus : IRequest<string>
{
	public List<string> Equipments { get; set; }

	[EnumDataType(typeof(EquipmentStatus))]
	public EquipmentStatus Status { get; set; } 

}
