using EquipmentManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.EquipmentType.Commands.CreateET;
public class CreateET : IRequest<string>
{
	public string EquipmentTypeId { get; set; } = string.Empty;
	public string EquipmentTypeName { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	//
	public Category Category { get; set; }
	public List<string> Tags { get; set; }
	public List<CreateETPicture>? Pictures {  get; set; }
	public List<CreateETSpec>? Specification {  get; set; }

}
public class CreateETPicture
{
	public string FileData { get; set; }
}
public class CreateETSpec
{
	public string Name { get; set; }
	public string Value { get; set; }
	public string Unit { get; set; }
}
