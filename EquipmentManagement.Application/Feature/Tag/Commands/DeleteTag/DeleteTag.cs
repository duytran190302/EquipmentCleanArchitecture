using MediatR;

namespace EquipmentManagement.Application.Feature.Tag.Commands.DeleteTag
{
	public class DeleteTag : IRequest<string>
	{
		public string TagId { get; set; } = string.Empty;
	}
}
