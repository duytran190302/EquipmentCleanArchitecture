using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier;
public class CreateSupplierValidation : AbstractValidator<CreateSupplier>
{
	public CreateSupplierValidation()
	{
		RuleFor(p => p.SupplierName)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.Address)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500).WithMessage("max length = 500");
	}

}
