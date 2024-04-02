using MediatR;

namespace EquipmentManagement.Application.Feature.Specification.Queries.GetSpec
{
	public class GetSpec : IRequest<List<SpecDTO>>
	{
		public string EquipmentTypeId { get; set; } = string.Empty;
	}

}
