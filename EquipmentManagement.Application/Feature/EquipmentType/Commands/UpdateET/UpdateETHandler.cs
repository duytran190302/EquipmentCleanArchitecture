using AutoMapper;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.EquipmentType.Commands.UpdateET;

public class UpdateETHandler : IRequestHandler<UpdateET, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateETHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(UpdateET request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new UpdateETValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid ET", validatorResult);
		}
		//convert
		var a = await _unitOfWork.equipmentTypeRepository.GetByIdAsync(request.EquipmentTypeId);
        if ( a==null)
        {
			throw new BadRequestException("Notfound");
		}
		else
		{
			a.Description = request.Description;
			a.Category = request.Category;
			a.EquipmentTypeName = request.EquipmentTypeName;
			if(request.Tags!=null)
			{
				a.Tags = _unitOfWork.tagRepository.FindByCondition(x => request.Tags.Any(id => x.TagId == id)).ToList();
			}
		}
		//add to db
		_unitOfWork.equipmentTypeRepository.Update(a);
        //return 
        return a.EquipmentTypeId;
	}
}
