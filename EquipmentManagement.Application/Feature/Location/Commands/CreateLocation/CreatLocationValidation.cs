using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;

public class CreatLocationValidation : AbstractValidator<CreateLocation>
{
	public CreatLocationValidation()
	{
		RuleFor(p => p.LocationId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.Note)
			.MaximumLength(200).WithMessage("max length = 200");
	}

}
