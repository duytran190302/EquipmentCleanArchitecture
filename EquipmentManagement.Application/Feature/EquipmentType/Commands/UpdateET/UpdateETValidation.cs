using FluentValidation;

namespace EquipmentManagement.Application.Feature.EquipmentType.Commands.UpdateET;

public class UpdateETValidation : AbstractValidator<UpdateET>
{
	public UpdateETValidation()
	{
		RuleFor(p => p.EquipmentTypeId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.EquipmentTypeName)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500).WithMessage("max length = 500");
	}

}
