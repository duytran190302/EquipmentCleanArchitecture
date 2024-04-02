using EquipmentManagement.Application.Feature.Supplier.Commands.UpdateSupplier;
using EquipmentManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Tag.Commands.UpdateTag
{
	public class UpdateTag : IRequest<string>
	{
		public string TagId { get; set; } = string.Empty;
		public string TagDetail { get; set; } = string.Empty;
	}
}
