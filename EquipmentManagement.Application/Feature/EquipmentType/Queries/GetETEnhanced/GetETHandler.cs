using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;

namespace EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETEnhanced;

public class GetETHandler : IRequestHandler<GetETEnhanced, List<GetETEnhancedDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<GetETEnhanced> _logger;

	public GetETHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GetETEnhanced> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<List<GetETEnhancedDTO>> Handle(GetETEnhanced request, CancellationToken cancellationToken)
	{
		//query

		var ets = _unitOfWork.equipmentTypeRepository.FindAll(

			trackChanges: false,
			includeProperties: o => new { o.Tags, o.Specifications }).ToList();
		_logger.LogInformation("get spec successfully");
		// convert
		if (request.equipmentTypeId!=null)
		{
			ets= ets.Where(x=>x.EquipmentTypeId==request.equipmentTypeId).ToList();
		};
		if (request.equipmentTypeName != null)
		{
			ets = ets.Where(x => x.EquipmentTypeName == request.equipmentTypeName).ToList();
		};
		if (request.category != null)
		{
			ets = ets.Where(x => x.Category == request.category).ToList();
		};
		if (request.TagId != null)
		{
			foreach(var t in request.TagId)
			{
				ets = ets.Where(x => x.Tags.Any(tg => tg.TagId==t)).ToList();
			}
		};



		var data = new List<GetETEnhancedDTO>();
		foreach (var et in ets)
		{
			var dt = new GetETEnhancedDTO()
			{
				Category = et.Category,
				Description = et.Description,
				EquipmentTypeId = et.EquipmentTypeId,
				EquipmentTypeName = et.EquipmentTypeName,
				Tags = et.Tags

			};
			data.Add(dt);

		}



		return data;

	}
}
