using MediatR;

namespace EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETEnhanced;

public class GetETEnhanced : IRequest<List<GetETEnhancedDTO>>
{
	public List<string>? TagId { get; set; } 
	public string? equipmentTypeId { get; set; }
	public string?  equipmentTypeName { get; set; }
	public Domain.Category? category { get; set; }
}
