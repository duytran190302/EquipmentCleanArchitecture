using MediatR;

namespace EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETInfor;

public class GETETInfor : IRequest<GETETInforDTO>
{
	public string EquipmentTypeId { get; set; } = string.Empty;
}
