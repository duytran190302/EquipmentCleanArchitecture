using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier
{
	public class CreateSupplier: IRequest<string>
	{
		public string SupplierName { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
	}
}
