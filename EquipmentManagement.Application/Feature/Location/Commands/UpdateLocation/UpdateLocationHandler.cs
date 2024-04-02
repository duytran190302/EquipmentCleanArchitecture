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

namespace EquipmentManagement.Application.Feature.Location.Commands.UpdateLocation
{
	public class UpdateLocationHandler : IRequestHandler<UpdateLocation, string>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _locationRepository;
		private readonly IAppLogger<UpdateLocationHandler> _logger;

		public UpdateLocationHandler(IMapper mapper,IUnitOfWork locationRepository,IAppLogger<UpdateLocationHandler> logger)
        {
			_mapper = mapper;
			_locationRepository = locationRepository;
			_logger = logger;
		}
        public async Task<string> Handle(UpdateLocation request, CancellationToken cancellationToken)
		{
			//validate


			//convert
			var locationToUpdate = _mapper.Map<Domain.Location>(request);

			//add to db
			  _locationRepository.locationRepository.Update(locationToUpdate);
			await _locationRepository.SaveChangeAsync();
			//
			_logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Location), request.LocationId);
			//return 
			return locationToUpdate.LocationId;
		}
	}
}
