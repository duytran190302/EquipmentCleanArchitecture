using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;

namespace EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipment;

public class GetEquipmentHandler : IRequestHandler<GetEquipment, List<GetEquipmentDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<GetEquipment> _logger;

	public GetEquipmentHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GetEquipment> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<List<GetEquipmentDTO>> Handle(GetEquipment request, CancellationToken cancellationToken)
	{
		//query

		var equipments = _unitOfWork.equipmentRepository.FindAll(

			trackChanges: false,
			includeProperties: o => new { o.Supplier, o.Borrows, o.Location, o.Project, o.EquipmentType}).ToList();
		_logger.LogInformation("get equipment successfully");
		// convert
		if (request.Search != null)
		{
			equipments = equipments.Where(x =>
	 (
			x.EquipmentId.Contains(request.Search) ||
			x.EquipmentName.Contains(request.Search) ||
			x.Location.LocationId.Contains(request.Search) ||
			x.Supplier.SupplierName.Contains(request.Search) ||
			x.Project != null && x.Project.ProjectName.Contains(request.Search) ||
			x.Borrows != null && x.Borrows.Any(x=>x.Borrower.Contains(request.Search)) ||
			x.Status.ToString().Contains(request.Search) ||
			x.EquipmentType.Category.ToString().Contains(request.Search) ||
			x.EquipmentType.Tags.Any(t => t.TagId.Contains(request.Search))
	 )
	).ToList();
		}

		var data = new List<GetEquipmentDTO>();
		foreach (var equipment in equipments)
		{
			var dt = new GetEquipmentDTO()
			{
				EquipmentId = equipment.EquipmentId,
				Status = equipment.Status,
				CodeOfManager = equipment.CodeOfManager,
				EquipmentName = equipment.EquipmentName,
				EquipmentTypeId = equipment.EquipmentTypeId,
				LocationId = equipment.Location.LocationId,
				SupplierName= equipment.Supplier.SupplierName,
				YearOfSupply = equipment.YearOfSupply,
				Tags = equipment.EquipmentType.Tags.Select(x=>x.TagId).ToList(),
			};
			data.Add(dt);

		}


		return data;

	}
}
