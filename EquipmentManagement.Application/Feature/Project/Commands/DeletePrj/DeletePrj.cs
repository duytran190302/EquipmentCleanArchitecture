using MediatR;

namespace EquipmentManagement.Application.Feature.Project.Commands.DeletePrj;

public class DeletePrj : IRequest<string>
{
	public string ProjectName { get; set; } = string.Empty;
}
