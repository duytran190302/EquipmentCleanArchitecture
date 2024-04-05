using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Project.Commands.EndProject;

public class EndPrj : IRequest<string>
{
	public string ProjectName { get; set; } = string.Empty;
	public DateTime? RealEndDate { get; set; }
}

