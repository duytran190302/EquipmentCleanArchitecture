using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations
{
	public class GetAllLocationHandler : IRequestHandler<GetAllLocation, List<LocationDTO>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _locationRepository;
		private readonly IAppLogger<GetAllLocation> _logger;

		public GetAllLocationHandler(IMapper mapper, IUnitOfWork locationRepository, IAppLogger<GetAllLocation> logger)
        {
			_mapper = mapper;
			_locationRepository = locationRepository;
			_logger = logger;
		}

        public async Task<List<LocationDTO>> Handle(GetAllLocation request, CancellationToken cancellationToken)
		{
			//query
			var locations =  _locationRepository.locationRepository.FindAll();
			//logging
			_logger.LogInformation("get location successfully");
			// convert
			var data = _mapper.Map<List<LocationDTO>>(locations);
			//return
			return data;
		}
	}
}
