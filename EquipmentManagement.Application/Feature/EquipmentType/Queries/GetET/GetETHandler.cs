using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;

namespace EquipmentManagement.Application.Feature.EquipmentType.Queries.GetET;

public class GetETHandler : IRequestHandler<GetET, List<GetETDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<GetET> _logger;

	public GetETHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GetET> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<List<GetETDTO>> Handle(GetET request, CancellationToken cancellationToken)
	{
		//query

		var ets = _unitOfWork.equipmentTypeRepository.FindAll(
			
			trackChanges: false,
			includeProperties: o =>new { o.Tags, o.Specifications }).ToList();
		_logger.LogInformation("get spec successfully");
		// convert
		if (request.Search!=null)
		{
			ets = ets.Where(x =>
	 (
			x.Description.Contains(request.Search) ||
			x.EquipmentTypeName.Contains(request.Search) ||
			x.EquipmentTypeId.Contains(request.Search) ||
			x.Category.ToString().Contains(request.Search) ||
			x.Tags.Any(t => t.TagId.Contains(request.Search))
	 )
    ).ToList();
		}

		var data = new List<GetETDTO>();
		foreach ( var et in ets )
		{
			var dt = new GetETDTO()
			{
				Category = et.Category,
				Description = et.Description,
				EquipmentTypeId = et.EquipmentTypeId,
				EquipmentTypeName = et.EquipmentTypeName,
				Tags = et.Tags

			};
			data.Add( dt );

		}



		//ets = ets.Where(x => (
		//request.Search.Any(id => x.EquipmentTypeName.Contains(id)) ||
		//request.Search.Any(id => x.EquipmentTypeId.Contains(id)) ||
		//request.Search.Any(id => x.Description.Contains(id))||
		//request.Search.Any(id => x.Tags.Any(a=>a.TagId.Contains(id)))||
		//)
		//)
		//	.ToList();

		return data;

	}
}