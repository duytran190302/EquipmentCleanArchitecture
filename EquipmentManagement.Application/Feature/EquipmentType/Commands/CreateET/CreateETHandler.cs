using AutoMapper;
using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.EquipmentType.Commands.CreateET
{
	public class CreateETHandler : IRequestHandler<CreateET, string>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPictureRepository _pictureRepository;
		private readonly IEquipmentTypeRepository _equipmentTypeRepository;
		private readonly ISpecificationRepository _specificationRepository;

		public CreateETHandler(IMapper mapper, IUnitOfWork unitOfWork, IEquipmentTypeRepository equipmentTypeRepository, ISpecificationRepository specificationRepository)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_equipmentTypeRepository = equipmentTypeRepository;
			_specificationRepository = specificationRepository;
		}
		public async Task<string> Handle(CreateET request, CancellationToken cancellationToken)
		{
			//validate
			var validator = new CreateETValidation();
			var validatorResult = await validator.ValidateAsync(request);
			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid ET", validatorResult);
			}
			//convert
			var pictureToCreate = new List<Domain.Picture>();

			foreach (var picture in request.Pictures)
			{
				if (!string.IsNullOrEmpty(picture.FileData))
				{
					foreach (var item in request.Pictures)
					{
						var a = new Domain.Picture
						{
							FileData = Convert.FromBase64String(item.FileData),
							EquipmentTypeId=request.EquipmentTypeId,
						};
						pictureToCreate.Add(a);
					}
				}
			}
			var specToCreate = new List<Domain.Specification>();
			if (request.Specification != null)
			{
				foreach (var item in request.Specification)
				{
					var a = new Domain.Specification
					{
						Name = item.Name,
						Value = item.Value,
						Unit = item.Unit,
						EquipmentTypeId=request.EquipmentTypeId
					};
					specToCreate.Add(a);
				}

			}
			var tag = _unitOfWork.tagRepository.FindByCondition(x => request.Tags.Any(id => x.TagId == id),trackChanges:true).ToList();
			var equipmentTypeToCreate = new Domain.EquipmentType
			{
				EquipmentTypeId = request.EquipmentTypeId,
				EquipmentTypeName = request.EquipmentTypeName,
				Category = request.Category,
				Description = request.Description,
				Tags = tag,
				//Pictures= pictureToCreate,
				//Specifications= specToCreate
			};

			 _unitOfWork.equipmentTypeRepository.Add(equipmentTypeToCreate);
			if (pictureToCreate.Count != 0)
			{
				_unitOfWork.pictureRepository.AddRange(pictureToCreate);
				//_picturerepository.addrange(picturetocreate);
			}


			_unitOfWork.specificationRepository.AddRange(specToCreate);
			//_specificationRepository.AddRange(specToCreate);
			await _unitOfWork.SaveChangeAsync();
			//return 
			return request.EquipmentTypeId;
		}
	}
}
