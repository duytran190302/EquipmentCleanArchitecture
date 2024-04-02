using MediatR;

namespace EquipmentManagement.Application.Feature.Picture.Commands.CreatePicture;

public class CreatePicture : IRequest<string>
{
	public string FileData { get; set; }
	public string EquipmentTypeId { get; set; }
}


