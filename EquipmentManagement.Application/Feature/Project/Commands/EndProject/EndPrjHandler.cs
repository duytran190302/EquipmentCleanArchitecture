using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;

namespace EquipmentManagement.Application.Feature.Project.Commands.EndProject;

public class EndPrjHandler : IRequestHandler<EndPrj, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<EndPrj> _logger;

	public EndPrjHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<EndPrj> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}
	public async Task<string> Handle(EndPrj request, CancellationToken cancellationToken)
	{
		//validate

		var equips = _unitOfWork.equipmentRepository.FindByCondition(
			x => x.Project.ProjectName==request.ProjectName, trackChanges: true, x=>x.Project).ToList();
		foreach(var e in equips)
		{
			e.Project = null;
			_unitOfWork.equipmentRepository.Update(e);
		}

		var prjToEnd = await _unitOfWork.projectRepository.GetByIdAsync(request.ProjectName);
		prjToEnd.RealEndDate=request.RealEndDate;
		_unitOfWork.projectRepository.Update(prjToEnd);

		await _unitOfWork.SaveChangeAsync();
		//return 
		return request.ProjectName;
	}
}

