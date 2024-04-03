using MediatR;

namespace EquipmentManagement.Application.Feature.EquipmentType.Commands.DeleteET;

public class DeleteET : IRequest<string>
{
	public string EquipmentTypeId { get; set; } = string.Empty;
}
