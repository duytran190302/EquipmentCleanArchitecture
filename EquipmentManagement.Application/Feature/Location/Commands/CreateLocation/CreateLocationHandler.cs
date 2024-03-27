using AutoMapper;
using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Location.Commands.CreateLocation
{
	public class CreateLocationHandler : IRequestHandler<CreateLocation, string>
	{
		private readonly IMapper _mapper;
		private readonly ILocationRepository _locationRepository;

		public CreateLocationHandler(IMapper mapper, ILocationRepository locationRepository)
        {
			_mapper = mapper;
			_locationRepository = locationRepository;
		}
        public async Task<string> Handle(CreateLocation request, CancellationToken cancellationToken)
		{
			//validate
			var validator = new CreatLocationValidation();
			var validatorResult= await validator.ValidateAsync(request);
			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Location",validatorResult);
			}
			//convert
			var locationToCreate = _mapper.Map<Domain.Location>(request);

			//add to db
			await _locationRepository.CreateAsync(locationToCreate);
			//return 
			return locationToCreate.LocationId;
		}
	}
}
