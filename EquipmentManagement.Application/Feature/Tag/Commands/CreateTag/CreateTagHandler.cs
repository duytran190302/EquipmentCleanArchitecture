using AutoMapper;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Tag.Commands.CreateTag
{
	public class CreateTagHandler : IRequestHandler<CreateTag, string>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _tagRepository;

		public CreateTagHandler(IMapper mapper, IUnitOfWork tagRepository)
		{
			_mapper = mapper;
			_tagRepository = tagRepository;
		}
		public async Task<string> Handle(CreateTag request, CancellationToken cancellationToken)
		{
			//validate
			var validator = new CreateTagValidation();
			var validatorResult = await validator.ValidateAsync(request);
			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Tag", validatorResult);
			}
			//convert
			var tagToCreate = _mapper.Map<Domain.Tag>(request);

			//add to db
			_tagRepository.tagRepository.Add(tagToCreate);
			await _tagRepository.SaveChangeAsync();
			//return 
			return tagToCreate.TagId;
		}
	}

}
