using EquipmentManagement.Application.Feature.EquipmentType.Commands.CreateET;
using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using EquipmentManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.EquipmentType.Commands.UpdateET;

public class UpdateET : IRequest<string>
{
	public string EquipmentTypeId { get; set; } = string.Empty;
	public string EquipmentTypeName { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	//
	[EnumDataType(typeof(Category))]
	public Category Category { get; set; }
	public List<string>? Tags { get; set; }

}
