using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Location.Commands.DeleteLocation
{
	public class DeleteLocationHandler : IRequestHandler<DeleteLocation, string>
	{
		private readonly ILocationRepository _locationRepository;

		public DeleteLocationHandler(ILocationRepository locationRepository)
        {
			_locationRepository = locationRepository;
		}
        public async Task<string> Handle(DeleteLocation request, CancellationToken cancellationToken)
		{


			var locationToDelete= await _locationRepository.GetAsync(x=>x.LocationId== request.LocationId);
			if (locationToDelete == null)
			{
				throw new NotFoundException(nameof(Location),request.LocationId);
			}

			await _locationRepository.DeleteAsync(locationToDelete);
			return locationToDelete.LocationId;
		}
	}
}
