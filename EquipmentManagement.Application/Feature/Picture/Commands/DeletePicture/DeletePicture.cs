using MediatR;

namespace EquipmentManagement.Application.Feature.Picture.Commands.DeletePicture
{
	public class DeletePicture : IRequest<string>
	{
		public string EquipmentTypeId { get; set; } = string.Empty;
	}

}
