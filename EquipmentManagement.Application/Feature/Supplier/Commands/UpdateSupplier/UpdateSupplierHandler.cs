using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Feature.Location.Commands.UpdateLocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Supplier.Commands.UpdateSupplier
{
	public class UpdateSupplierHandler : IRequestHandler<UpdateSupplier, string>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _supplierRepository;
		private readonly IAppLogger<UpdateSupplier> _logger;

		public UpdateSupplierHandler(IMapper mapper, IUnitOfWork supplierRepository, IAppLogger<UpdateSupplier> logger)
		{
			_mapper = mapper;
			_supplierRepository = supplierRepository;
			_logger = logger;
		}
		public async Task<string> Handle(UpdateSupplier request, CancellationToken cancellationToken)
		{
			//validate


			//convert
			var supplierToUpdate = _mapper.Map<Domain.Supplier>(request);

			//add to db
			_supplierRepository.supplierRepository.Update(supplierToUpdate);
			await _supplierRepository.SaveChangeAsync();
			//
			_logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Location), request.SupplierName);
			//return 
			return supplierToUpdate.SupplierName;
		}
	}
}
