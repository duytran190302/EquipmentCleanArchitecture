using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Feature.Supplier.Queries.GetAllSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Tag.Queries.GetAllTag;
public class GetAllTagHandler : IRequestHandler<GetAllTag, List<TagDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _tagRepository;
	private readonly IAppLogger<GetAllTag> _logger;

	public GetAllTagHandler(IMapper mapper, IUnitOfWork tagRepository, IAppLogger<GetAllTag> logger)
	{
		_mapper = mapper;
		_tagRepository = tagRepository;
		_logger = logger;
	}

	public async Task<List<TagDTO>> Handle(GetAllTag request, CancellationToken cancellationToken)
	{
		//query
		var tags = _tagRepository.tagRepository.FindAll();
		//logging
		_logger.LogInformation("get location successfully");
		// convert
		var data = _mapper.Map<List<TagDTO>>(tags);
		//return
		return data;
	}
}
