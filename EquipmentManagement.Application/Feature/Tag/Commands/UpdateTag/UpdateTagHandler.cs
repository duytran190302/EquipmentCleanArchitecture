using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;

namespace EquipmentManagement.Application.Feature.Tag.Commands.UpdateTag
{
	public class UpdateTagHandler : IRequestHandler<UpdateTag, string>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _tagRepository;
		private readonly IAppLogger<UpdateTag> _logger;

		public UpdateTagHandler(IMapper mapper, IUnitOfWork tagRepository, IAppLogger<UpdateTag> logger)
		{
			_mapper = mapper;
			_tagRepository = tagRepository;
			_logger = logger;
		}
		public async Task<string> Handle(UpdateTag request, CancellationToken cancellationToken)
		{
			//validate


			//convert
			var tagToUpdate = _mapper.Map<Domain.Tag>(request);

			//add to db
			_tagRepository.tagRepository.Update(tagToUpdate);
			await _tagRepository.SaveChangeAsync();
			//
			_logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Tag), request.TagId);
			//return 
			return tagToUpdate.TagId;
		}
	}
}
