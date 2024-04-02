using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Supplier.Queries.GetAllSupplier
{
	public record GetAllSupplier : IRequest<List<SupplierDTO>>;
}
