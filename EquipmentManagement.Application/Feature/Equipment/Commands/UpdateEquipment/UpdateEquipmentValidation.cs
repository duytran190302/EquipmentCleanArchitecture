using FluentValidation;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.UpdateEquipment;

public class UpdateEquipmentValidation : AbstractValidator<UpdateEquipment>
{
	public UpdateEquipmentValidation()
	{
		RuleFor(p => p.EquipmentId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.EquipmentName)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500).WithMessage("max length = 500");

		RuleFor(p => p.LocationId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500).WithMessage("max length = 500");
		RuleFor(p => p.SupplierName)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500).WithMessage("max length = 500");

		RuleFor(p => p.EquipmentTypeId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500).WithMessage("max length = 500");
	}

}

