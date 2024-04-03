using EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.EquipmentType.Commands.CreateET
{
	public class CreateETValidation : AbstractValidator<CreateET>
	{
		public CreateETValidation()
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
}
