using AutoMapper;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier
{
	public class CreateSupplierHandler : IRequestHandler<CreateSupplier, string>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _supplierRepository;

		public CreateSupplierHandler(IMapper mapper, IUnitOfWork supplierRepository)
		{
			_mapper = mapper;
			_supplierRepository = supplierRepository;
		}
		public async Task<string> Handle(CreateSupplier request, CancellationToken cancellationToken)
		{
			//validate
			var validator = new CreateSupplierValidation();
			var validatorResult = await validator.ValidateAsync(request);
			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Location", validatorResult);
			}
			//convert
			var supplierToCreate = _mapper.Map<Domain.Supplier>(request);

			//add to db
			_supplierRepository.supplierRepository.Add(supplierToCreate);
			await _supplierRepository.SaveChangeAsync();
			//return 
			return supplierToCreate.SupplierName;
		}
	}
}
