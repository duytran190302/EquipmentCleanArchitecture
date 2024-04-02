using EquipmentManagement.Application.Feature.Supplier.Commands.DeleteSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Specification.Commands.DeleteSpec;

public class DeleteSpec : IRequest<string>
{
	public string EquipmentTypeId { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
}
