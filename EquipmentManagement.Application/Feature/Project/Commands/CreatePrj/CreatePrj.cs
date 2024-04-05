using MediatR;

namespace EquipmentManagement.Application.Feature.Project.Commands.CreatePrj;

public class CreatePrj: IRequest<string>
{
	public string ProjectName { get; set; } = string.Empty;
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string Description { get; set; } = string.Empty;
	public List<string> Equipments { get; set; }
}

