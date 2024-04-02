using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.Specification.Commands.DeleteSpec;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Picture.Commands.DeletePicture
{
	public class DeletePictureHandler : IRequestHandler<DeletePicture, string>
	{
		private readonly IUnitOfWork _picture;

		public DeletePictureHandler(IUnitOfWork picture)
		{
			_picture = picture;
		}
		public async Task<string> Handle(DeletePicture request, CancellationToken cancellationToken)
		{


			var pictureToDelete = _picture.pictureRepository
				.FindByCondition(x => x.EquipmentTypeId == request.EquipmentTypeId).ToList();

			if (pictureToDelete == null)
			{
				throw new NotFoundException(nameof(Picture), request.EquipmentTypeId);
			}

			_picture.pictureRepository.RemoveRange(pictureToDelete);
			await _picture.SaveChangeAsync();
			return request.EquipmentTypeId;
		}
	}

}
