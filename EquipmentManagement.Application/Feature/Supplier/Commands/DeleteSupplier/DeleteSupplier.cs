using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Supplier.Commands.DeleteSupplier
{
	public class DeleteSupplier : IRequest<string>
	{
		public string SupplierName { get; set; } = string.Empty;
	}
}
