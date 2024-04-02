using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Feature.Supplier.Queries.GetAllSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Specification.Queries.GetSpec
{
	public class GetSpecHandler : IRequestHandler<GetSpec, List<SpecDTO>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _specRepository;
		private readonly IAppLogger<GetSpec> _logger;

		public GetSpecHandler(IMapper mapper, IUnitOfWork specRepository, IAppLogger<GetSpec> logger)
		{
			_mapper = mapper;
			_specRepository = specRepository;
			_logger = logger;
		}

		public async Task<List<SpecDTO>> Handle(GetSpec request, CancellationToken cancellationToken)
		{
			//query

			var suppliers = _specRepository.specificationRepository.FindByCondition(x=>x.EquipmentTypeId==request.EquipmentTypeId).ToList();
			//logging
			_logger.LogInformation("get spec successfully");
			// convert
			var data = _mapper.Map<List<SpecDTO>>(suppliers);
			//return
			return data;
		}
	}

}
