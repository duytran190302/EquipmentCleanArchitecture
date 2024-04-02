using AutoMapper;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Specification.Commands.CreateSpec;

public class CreateSpecHandler : IRequestHandler<CreateSpec, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _specRepository;

	public CreateSpecHandler(IMapper mapper, IUnitOfWork specRepository)
	{
		_mapper = mapper;
		_specRepository = specRepository;
	}
	public async Task<string> Handle(CreateSpec request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CreateSpecValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid spec", validatorResult);
		}
		//convert
		var specToCreate = _mapper.Map<Domain.Specification>(request);

		//add to db
		_specRepository.specificationRepository.Add(specToCreate);
		await _specRepository.SaveChangeAsync();
		//return 
		return specToCreate.Name;
	}
}
