using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.EquipmentType.Commands.UpdateET;
using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETInfor;

public class GetETInforHandler : IRequestHandler<GETETInfor, GETETInforDTO>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<GETETInfor> _logger;

	public GetETInforHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GETETInfor> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<GETETInforDTO> Handle(GETETInfor request, CancellationToken cancellationToken)
	{
		//query

		var pics = _unitOfWork.pictureRepository.FindByCondition(x=>x.EquipmentTypeId== request.EquipmentTypeId).Select(x=>x.FileData).ToList();
		var picdata = new List<Pics>();
        foreach (var pic in pics)
		{
			picdata.Add(new Pics() { FileData = pic });
		}

		var specs = _unitOfWork.specificationRepository.FindByCondition(x=>x.EquipmentTypeId== request.EquipmentTypeId).ToList();
		var specsdata = new List<Specs>();
		foreach(var spec in specs)
		{
			specsdata.Add(new Specs()
			{
				Name = spec.Name,
				Unit= spec.Unit,
				Value = spec.Value,
			});
		}
		// convert
		var data = new GETETInforDTO
		{
			equipmentTypeId = request.EquipmentTypeId,
			Pics = picdata,
			Specs = specsdata
		};




		return data;

	}
}
