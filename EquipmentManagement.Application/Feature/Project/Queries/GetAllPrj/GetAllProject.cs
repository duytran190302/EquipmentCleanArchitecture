using MediatR;

namespace EquipmentManagement.Application.Feature.Project.Queries.GetAllPrj;

public class GetAllProject : IRequest<List<GetAllProjectDTO>>
{
	public string? Search { get; set; } = string.Empty;
	public int? Year { get; set; }
}
