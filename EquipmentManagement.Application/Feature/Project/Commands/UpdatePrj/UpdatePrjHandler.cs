using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using MediatR;

namespace EquipmentManagement.Application.Feature.Project.Commands.UpdatePrj;

public class UpdatePrjHandler : IRequestHandler<UpdatePrj, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<UpdatePrj> _logger;

	public UpdatePrjHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<UpdatePrj> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}
	public async Task<string> Handle(UpdatePrj request, CancellationToken cancellationToken)
	{
		//validate

		var equips = _unitOfWork.equipmentRepository.FindByCondition(x => request.Equipments.Any(id => x.EquipmentId == id), trackChanges: true, x => x.Project).ToList();
		equips = equips.Where(x => x.Status == Domain.EquipmentStatus.Active).ToList();

		var project = await _unitOfWork.projectRepository.GetByIdAsync(request.ProjectName);

		project.StartDate = request.StartDate;
		project.EndDate = request.EndDate;
		project.Description = request.Description;
		//Approved = false,
		project.Equipments = equips;


		
		_unitOfWork.projectRepository.Update(project);
		await _unitOfWork.SaveChangeAsync();
		//return 
		return request.ProjectName;
	}
}
