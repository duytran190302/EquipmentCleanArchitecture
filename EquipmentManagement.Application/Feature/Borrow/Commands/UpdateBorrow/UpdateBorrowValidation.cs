using EquipmentManagement.Application.Feature.Equipment.Commands.UpdateEquipment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Borrow.Commands.UpdateBorrow;
public class UpdateBorrowValidation : AbstractValidator<UpdateBorrow>
{
	public UpdateBorrowValidation()
	{
		RuleFor(p => p.BorrowId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.BorrowedDate)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull();

		RuleFor(p => p.ReturnedDate)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull();
		RuleFor(p => p.Borrower)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500).WithMessage("max length = 500");

		RuleFor(p => p.Reason)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500).WithMessage("max length = 500");

		RuleFor(p => p.OnSide)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull();
	}

}
