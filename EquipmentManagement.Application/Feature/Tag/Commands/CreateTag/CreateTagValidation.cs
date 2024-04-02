using FluentValidation;

namespace EquipmentManagement.Application.Feature.Tag.Commands.CreateTag
{
	public class CreateTagValidation : AbstractValidator<CreateTag>
	{
		public CreateTagValidation()
		{
			RuleFor(p => p.TagId)
				.NotEmpty().WithMessage("{property} is required")
				.NotNull()
				.MaximumLength(100);

			RuleFor(p => p.TagDetail)
				.NotEmpty().WithMessage("{property} is required")
				.NotNull()
				.MaximumLength(500).WithMessage("max length = 500");
		}

	}

}
