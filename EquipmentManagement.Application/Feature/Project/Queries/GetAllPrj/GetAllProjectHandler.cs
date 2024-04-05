using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;

namespace EquipmentManagement.Application.Feature.Project.Queries.GetAllPrj;

public class GetAllProjectHandler : IRequestHandler<GetAllProject, List<GetAllProjectDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<GetAllProject> _logger;

	public GetAllProjectHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GetAllProject> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<List<GetAllProjectDTO>> Handle(GetAllProject request, CancellationToken cancellationToken)
	{
		//query

		var prjs = _unitOfWork.projectRepository.FindAll(

			 false,
			 o => o.Equipments,
			 o => o.Borrows

			 ).ToList();
		_logger.LogInformation("get equipment successfully");
		// convert
		if (request.Search != null)
		{
			prjs = prjs.Where(x => x.ProjectName.Contains(request.Search)).ToList();
	
		}
		if (request.Year != null)
		{
			prjs = prjs.Where(x => x.StartDate.Year==request.Year).ToList();

		}

		var data = new List<GetAllProjectDTO>();
		foreach (var prj in prjs)
		{
			var dt = new GetAllProjectDTO()
			{
				ProjectName = prj.ProjectName,
				Approved = prj.Approved,
				Description = prj.Description,
				EndDate = prj.EndDate,
				RealEndDate = prj.RealEndDate,
				StartDate = prj.StartDate,
				Borrows = prj.Borrows.Select(x=>x.BorrowId).ToList(),
				Equipments = prj.Equipments.Select(x=>x.EquipmentId).ToList()

				
			};
			data.Add(dt);

		}


		return data;

	}
}
