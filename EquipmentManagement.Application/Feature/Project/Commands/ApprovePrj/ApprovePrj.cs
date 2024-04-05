using MediatR;

namespace EquipmentManagement.Application.Feature.Project.Commands.ApprovePrj;

public class ApprovePrj : IRequest<string>
{
	public string ProjectName { get; set; } = string.Empty;
}
