using MediatR;

namespace EquipmentManagement.Application.Feature.Picture.Queries.GetPicture
{
	public class GetPicture : IRequest<List<PictureDTO>>
	{
		public string EquipmentTypeId { get; set; } = string.Empty;
	}


}
