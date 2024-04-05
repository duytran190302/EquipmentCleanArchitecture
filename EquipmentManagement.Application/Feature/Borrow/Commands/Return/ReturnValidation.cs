using FluentValidation;

namespace EquipmentManagement.Application.Feature.Borrow.Commands.Return;

public class ReturnValidation : AbstractValidator<Return>
{
	public ReturnValidation()
	{
		RuleFor(p => p.BorrowId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);
		RuleFor(p => p.RealReturnedDate)
		.NotEmpty().WithMessage("{property} is required")
		 .NotNull();

	}

}