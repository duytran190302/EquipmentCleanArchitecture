using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Supplier.Queries.GetAllSupplier
{
	public class SupplierDTO
	{
		public string SupplierName { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
	}

}
