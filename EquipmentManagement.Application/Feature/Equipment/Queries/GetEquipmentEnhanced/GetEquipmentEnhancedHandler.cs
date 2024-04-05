using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;

namespace EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipmentEnhanced;

public class GetEquipmentEnhancedHandler : IRequestHandler<GetEquipmentEnhanced, List<GetEquipmentEnhancedDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<GetEquipmentEnhanced> _logger;

	public GetEquipmentEnhancedHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GetEquipmentEnhanced> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<List<GetEquipmentEnhancedDTO>> Handle(GetEquipmentEnhanced request, CancellationToken cancellationToken)
	{
		//query

		var ets = _unitOfWork.equipmentRepository.FindAll(

			 false,
			 o=> o.Supplier, 
			 o=> o.Borrows,
			 o => o.Project,
			 o => o.EquipmentType,
			 o => o.EquipmentType.Tags,
			 o => o.Location 
			 ).ToList();
		_logger.LogInformation("get spec successfully");
		// convert
		if (!string.IsNullOrEmpty(request.EquipmentId))
		{
			ets = ets.Where(x => x.EquipmentId == request.EquipmentId).ToList();
		};
		if (!string.IsNullOrEmpty(request.EquipmentName))
		{
			ets = ets.Where(x => x.EquipmentName == request.EquipmentName).ToList();
		};
		if (request.YearOfSupply != null)
		{
			ets = ets.Where(x => x.YearOfSupply.Year == request.YearOfSupply).ToList();
		};

		if (!string.IsNullOrEmpty(request.CodeOfManager))
		{
			ets = ets.Where(x => x.CodeOfManager == request.CodeOfManager).ToList();
		};

		if (!string.IsNullOrEmpty(request.EquipmentTypeId))
		{
			ets = ets.Where(x => x.EquipmentTypeId == request.EquipmentTypeId).ToList();
		};
		if (request.Status != null)
		{
			ets = ets.Where(x => x.Status == request.Status).ToList();
		};
		if (request.Category != null)
		{
			ets = ets.Where(x => x.EquipmentType.Category == request.Category).ToList();
		};
		if (!string.IsNullOrEmpty(request.LocationId))
		{
			ets = ets.Where(x => x.Location.LocationId == request.LocationId).ToList();
		};
		if (!string.IsNullOrEmpty(request.SupplierName))
		{
			ets = ets.Where(x => x.Supplier.SupplierName == request.SupplierName).ToList();
		};
		if (request.TagId != null)
		{
			foreach (var t in request.TagId)
			{
				ets = ets.Where(x => x.EquipmentType.Tags.Any(tg => tg.TagId == t)).ToList();
			}
		};



		var data = new List<GetEquipmentEnhancedDTO>();
		foreach (var et in ets)
		{
			var dt = new GetEquipmentEnhancedDTO()
			{

				EquipmentName = et.EquipmentName,
				EquipmentId = et.EquipmentId,
				CodeOfManager = et.CodeOfManager,
				LocationId = et.Location.LocationId,
				SupplierName = et.Supplier.SupplierName,
				EquipmentTypeId = et.EquipmentTypeId,
				YearOfSupply = et.YearOfSupply,
				Category= et.EquipmentType.Category,
				Status= et.Status,
				Tags = et.EquipmentType.Tags.Select(x => x.TagId).ToList(),
			};
			data.Add(dt);

		}



		return data;

	}
}
