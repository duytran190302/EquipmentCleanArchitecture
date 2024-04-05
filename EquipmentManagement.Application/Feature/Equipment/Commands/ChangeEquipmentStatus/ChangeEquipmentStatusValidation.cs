using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.ChangeEquipmentStatus;
public class ChangeEquipmentStatusValidation : AbstractValidator<ChangeEquipmentStatus>
{
	public ChangeEquipmentStatusValidation()
	{
		//RuleFor(p => p.Equipments)
		//	.NotEmpty().WithMessage("{property} is required")
		//	.NotNull();

		//RuleFor(p => p.Status)
		//	.NotEmpty().WithMessage("{property} is required")
		//	.NotNull();

	}

}
