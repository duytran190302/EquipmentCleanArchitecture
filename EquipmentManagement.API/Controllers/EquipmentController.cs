using EquipmentManagement.Application.Feature.Equipment.Commands.ChangeEquipmentStatus;
using EquipmentManagement.Application.Feature.Equipment.Commands.CreateEquipment;
using EquipmentManagement.Application.Feature.Equipment.Commands.DeleteEquipment;
using EquipmentManagement.Application.Feature.Equipment.Commands.UpdateEquipment;
using EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipment;
using EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipmentEnhanced;
using EquipmentManagement.Application.Feature.EquipmentType.Commands.CreateET;
using EquipmentManagement.Application.Feature.EquipmentType.Commands.UpdateET;
using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetET;
using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETEnhanced;
using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETInfor;
using EquipmentManagement.Application.Feature.Location.Commands.DeleteLocation;
using EquipmentManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EquipmentController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EquipmentController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetEquipments([FromQuery] string? search, int pageSize = 20, int pageNumber = 1)
		{
			var et = await _mediator.Send(new GetEquipment { Search = search });

			et = et.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(et);
		}
		[HttpGet("Enhanced")]
		public async Task<IActionResult> GetEquipmentEnhanced(
			[FromQuery]
			string? EquipmentId,
			string? EquipmentName,
			string ? EquipmentTypeId,
			string? LocationId,
			string? CodeOfManager,
			Category? EquipmentCategory,
			string? SupplierName,
			[FromQuery] List<string> TagId,
			EquipmentStatus Status,
			int? YearOfSupply,
			int pageSize = 20, int pageNumber = 1)
		{
			var et = await _mediator.Send(new GetEquipmentEnhanced
			{
				EquipmentId=EquipmentId,
				EquipmentName= EquipmentName,
				EquipmentTypeId = EquipmentTypeId,
				LocationId = LocationId,
				CodeOfManager = CodeOfManager,
				Category = EquipmentCategory,
				SupplierName = SupplierName,
				TagId = TagId,
				Status = Status,
				YearOfSupply = YearOfSupply,
				

			});
			et = et.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(et);
		}

		[HttpPost]
		public async Task<IActionResult> PostEquipment([FromBody] CreateEquipment e)
		{
			var id = await _mediator.Send(e);
			return Ok(id);

		}
		[HttpPut]
		public async Task<IActionResult> PutEquipment([FromBody] UpdateEquipment e)
		{
			var id = await _mediator.Send(e);
			return Ok(id);

		}
		[HttpPut("ChangeStatus")]
		public async Task<IActionResult> PutEquipmentStatus([FromBody] ChangeEquipmentStatus e)
		{
			var id = await _mediator.Send(e);
			return Ok(id);

		}
		[HttpDelete]
		public async Task<IActionResult> DeleteET([FromQuery] string id)
		{
			var command = new DeleteEquipment { EquipmentId = id };
			var IdReturn = await _mediator.Send(command);
			return Ok(IdReturn);

		}
	}
}
