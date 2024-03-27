using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Location.Commands.DeleteLocation
{
	public class DeleteLocation: IRequest<string>
	{
		public string LocationId { get; set; } = string.Empty;
	}
}
