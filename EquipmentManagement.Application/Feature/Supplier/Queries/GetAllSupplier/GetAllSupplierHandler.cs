using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations;
using MediatR;

namespace EquipmentManagement.Application.Feature.Supplier.Queries.GetAllSupplier
{
	public class GetAllSupplierHandler : IRequestHandler<GetAllSupplier, List<SupplierDTO>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _supplierRepository;
		private readonly IAppLogger<GetAllSupplier> _logger;

		public GetAllSupplierHandler(IMapper mapper, IUnitOfWork supplierRepository, IAppLogger<GetAllSupplier> logger)
		{
			_mapper = mapper;
			_supplierRepository = supplierRepository;
			_logger = logger;
		}

		public async Task<List<SupplierDTO>> Handle(GetAllSupplier request, CancellationToken cancellationToken)
		{
			//query
			var suppliers = _supplierRepository.supplierRepository.FindAll();
			//logging
			_logger.LogInformation("get location successfully");
			// convert
			var data = _mapper.Map<List<SupplierDTO>>(suppliers);
			//return
			return data;
		}
	}
}
