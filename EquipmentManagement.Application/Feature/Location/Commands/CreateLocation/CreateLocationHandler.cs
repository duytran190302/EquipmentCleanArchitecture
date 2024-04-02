using AutoMapper;
using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence.Generic;
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
		private readonly IUnitOfWork _locationRepository;

		public CreateLocationHandler(IMapper mapper, IUnitOfWork locationRepository)
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
			 _locationRepository.locationRepository.Add(locationToCreate);
			await _locationRepository.SaveChangeAsync();
			//return 
			return locationToCreate.LocationId;
		}
	}
}
