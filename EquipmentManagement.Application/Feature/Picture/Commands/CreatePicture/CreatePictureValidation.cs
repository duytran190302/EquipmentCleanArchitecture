using FluentValidation;

namespace EquipmentManagement.Application.Feature.Picture.Commands.CreatePicture;

public class CreatePictureValidation : AbstractValidator<CreatePicture>
{
	public CreatePictureValidation()
	{
		RuleFor(p => p.EquipmentTypeId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.FileData)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull();
	}

}


