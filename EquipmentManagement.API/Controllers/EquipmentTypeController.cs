using EquipmentManagement.Application.Feature.EquipmentType.Commands.CreateET;
using EquipmentManagement.Application.Feature.EquipmentType.Commands.UpdateET;
using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetET;
using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETEnhanced;
using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETInfor;
using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using EquipmentManagement.Application.Feature.Location.Commands.DeleteLocation;
using EquipmentManagement.Application.Feature.Location.Commands.UpdateLocation;
using EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations;
using EquipmentManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EquipmentTypeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EquipmentTypeController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetETs([FromQuery] string? search, int pageSize = 20, int pageNumber = 1)
		{
			var et = await _mediator.Send(new GetET{ Search=search});

			et = et.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(et);
		}
		[HttpGet("Information")]
		public async Task<IActionResult> GetETInf([FromQuery] string equipmentTypeId, int pageSize = 20, int pageNumber = 1)
		{
			var et = await _mediator.Send(new GETETInfor { EquipmentTypeId=equipmentTypeId });
			return Ok(et);
		}
		[HttpGet("Enhanced")]
		public async Task<IActionResult> GetETEnhanced(
			[FromQuery] 
		    string? equipmentTypeId,
			List<string>? tagIds,
			Category? category, 
			string? equipmentTypeName,
			int pageSize = 20, int pageNumber = 1)
		{
			var et = await _mediator.Send(new GetETEnhanced { 
				equipmentTypeId=equipmentTypeId,
				category= category ,
				equipmentTypeName= equipmentTypeName,
				TagId= tagIds
			});
			et = et.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(et);
		}

		[HttpPost]
		public async Task<IActionResult> PostET([FromBody] CreateET et)
		{ 
			var id =  _mediator.Send(et);
			return Ok(id);

		}
		[HttpPut]
		public async Task<IActionResult> PutET([FromBody] UpdateET et)
		{
			var id = await _mediator.Send(et);
			return Ok(id);

		}
		[HttpDelete]
		public async Task<IActionResult> DeleteET([FromQuery] string id)
		{
			var command = new DeleteLocation { LocationId = id };
			var IdReturn = await _mediator.Send(command);
			return Ok(IdReturn);

		}
	}
}

