using EquipmentManagement.Application.Feature.Supplier.Commands.UpdateSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Project.Commands.UpdatePrj;

public class UpdatePrj : IRequest<string>
{
	public string ProjectName { get; set; } = string.Empty;
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string Description { get; set; } = string.Empty;
	public List<string> Equipments { get; set; }
}
