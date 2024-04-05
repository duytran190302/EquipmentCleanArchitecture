using EquipmentManagement.Application.Feature.Equipment.Commands.CreateEquipment;
using EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Project.Commands.CreatePrj;

public class CreatePrjValidation : AbstractValidator<CreatePrj>
{
	public CreatePrjValidation()
	{
		RuleFor(p => p.ProjectName)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.StartDate)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull();
		RuleFor(p => p.EndDate)
		.NotEmpty().WithMessage("{property} is required")
		.NotNull();

	}

}

