using EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Specification.Commands.CreateSpec;

public class CreateSpec : IRequest<string>
{
	public string Name { get; set; }
	public string Value { get; set; }
	public string Unit { get; set; }

	public string EquipmentTypeId { get; set; }
}
