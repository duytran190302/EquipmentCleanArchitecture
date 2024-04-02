using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Feature.Specification.Queries.GetSpec;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Picture.Queries.GetPicture
{
	public class GetPictureHandler : IRequestHandler<GetPicture, List<PictureDTO>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _picture;
		private readonly IAppLogger<GetPicture> _logger;

		public GetPictureHandler(IMapper mapper, IUnitOfWork picture, IAppLogger<GetPicture> logger)
		{
			_mapper = mapper;
			_picture = picture;
			_logger = logger;
		}

		public async Task<List<PictureDTO>> Handle(GetPicture request, CancellationToken cancellationToken)
		{
			//query

			var pic = _picture.pictureRepository.FindByCondition(x => x.EquipmentTypeId == request.EquipmentTypeId).ToList();
			//logging
			_logger.LogInformation("get spec successfully");
			// convert
			var data = _mapper.Map<List<PictureDTO>>(pic);
			//return
			return data;
		}
	}


}
