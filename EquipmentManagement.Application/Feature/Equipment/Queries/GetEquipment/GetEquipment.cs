using MediatR;

namespace EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipment;

public class GetEquipment : IRequest<List<GetEquipmentDTO>>
{
	public string? Search { get; set; } = string.Empty;
}
