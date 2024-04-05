using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using FluentValidation;
using MediatR;

namespace EquipmentManagement.Application.Feature.Project.Commands.CreatePrj;

public class CreatePrjHandler : IRequestHandler<CreatePrj, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreatePrjHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task <string> Handle(CreatePrj request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CreatePrjValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid ET", validatorResult);
		}
		//convert
		var equips = _unitOfWork.equipmentRepository.FindByCondition(x => request.Equipments.Any(id => x.EquipmentId == id), trackChanges: true, x=>x.Project).ToList();
		equips= equips.Where(x=>x.Status==Domain.EquipmentStatus.Active).ToList();
		equips = equips.Where(x => x.Project == null).ToList();

		var project = new Domain.Project()
		{
			ProjectName = request.ProjectName,
			StartDate = request.StartDate,
			EndDate = request.EndDate,
			Description = request.Description,
			Approved = false,
			Equipments= equips,


		};
		_unitOfWork.projectRepository.Add(project);
		await _unitOfWork.SaveChangeAsync();
		//return 
		return project.ProjectName ;
	}
}

