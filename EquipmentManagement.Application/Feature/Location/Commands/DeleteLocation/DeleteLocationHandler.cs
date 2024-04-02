using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence.Generic;
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
		private readonly IUnitOfWork _locationRepository;

		public DeleteLocationHandler(IUnitOfWork locationRepository)
        {
			_locationRepository = locationRepository;
		}
        public async Task<string> Handle(DeleteLocation request, CancellationToken cancellationToken)
		{


			var locationToDelete= await _locationRepository.locationRepository.GetByIdAsync( request.LocationId);
			if (locationToDelete == null)
			{
				throw new NotFoundException(nameof(Location),request.LocationId);
			}

			 _locationRepository.locationRepository.Remove(locationToDelete);
			await _locationRepository.SaveChangeAsync();
			return locationToDelete.LocationId;
		}
	}
}
