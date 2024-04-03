using AutoMapper;
using EquipmentManagement.Application.Feature.EquipmentType.Commands.CreateET;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.CreateEquipment;
public class CreateEquipmentValidation : AbstractValidator<CreateEquipment>
{
	public CreateEquipmentValidation()
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
