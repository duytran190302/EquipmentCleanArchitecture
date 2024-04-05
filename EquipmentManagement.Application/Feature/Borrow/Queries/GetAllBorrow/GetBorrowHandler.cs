using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipmentEnhanced;
using EquipmentManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Borrow.Queries.GetAllBorrow;
public class GetBorrowHandler : IRequestHandler<GetBorrow, List<GetBorrowDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<GetBorrow> _logger;

	public GetBorrowHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GetBorrow> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<List<GetBorrowDTO>> Handle(GetBorrow request, CancellationToken cancellationToken)
	{
		//query

		var ets = _unitOfWork.borrowRepository.FindAll(

			 false,
			 o => o.Project,
			 o => o.Equipments
			 ).ToList();
		_logger.LogInformation("get spec successfully");
		// convert
		if (!string.IsNullOrEmpty(request.ProjectName))
		{
			ets = ets.Where(x => x.ProjectName == request.ProjectName).ToList();
		};
		if (!string.IsNullOrEmpty(request.Borrower))
		{
			ets = ets.Where(x => x.Borrower == request.Borrower).ToList();
		};

		if (!string.IsNullOrEmpty(request.BorrowId))
		{
			ets = ets.Where(x => x.BorrowId == request.BorrowId).ToList();
		};

		if (request.OnSide!= null)
		{
			ets = ets.Where(x => x.OnSide == request.OnSide).ToList();
		};
		if (request.BorrowedDate != null)
		{
			ets = ets.Where(x => x.BorrowedDate >= request.BorrowedDate).ToList();
		};
		if (request.ReturnedDate != null)
		{
			ets = ets.Where(x => x.ReturnedDate <= request.ReturnedDate).ToList();
		};


		var data = new List<GetBorrowDTO>();
		foreach (var et in ets)
		{
			var dt = new GetBorrowDTO()
			{
				Borrower= et.Borrower,
				BorrowedDate= et.BorrowedDate,
				ReturnedDate= et.ReturnedDate,
				OnSide= et.OnSide,
				BorrowId= et.BorrowId,
				ProjectName= et.ProjectName,Reason= et.Reason,
				RealReturnedDate= et.RealReturnedDate,
				Equipments = et.Equipments.Select(x => x.EquipmentId).ToList(),
				
				//Tags = et.EquipmentType.Tags.Select(x => x.TagId).ToList(),
			};
			data.Add(dt);

		}



		return data;

	}
}
