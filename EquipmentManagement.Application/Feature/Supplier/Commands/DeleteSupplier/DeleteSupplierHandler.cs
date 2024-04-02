using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.Location.Commands.DeleteLocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Supplier.Commands.DeleteSupplier
{
	public class DeleteSupplierHandler : IRequestHandler<DeleteSupplier, string>
	{
		private readonly IUnitOfWork _supplierRepository;

		public DeleteSupplierHandler(IUnitOfWork supplierRepository)
		{
			_supplierRepository = supplierRepository;
		}
		public async Task<string> Handle(DeleteSupplier request, CancellationToken cancellationToken)
		{


			var supplierToDelete = await _supplierRepository.supplierRepository.GetByIdAsync(request.SupplierName);
			if (supplierToDelete == null)
			{
				throw new NotFoundException(nameof(Location), request.SupplierName);
			}

			_supplierRepository.supplierRepository.Remove(supplierToDelete);
			await _supplierRepository.SaveChangeAsync();
			return supplierToDelete.SupplierName;
		}
	}
}
