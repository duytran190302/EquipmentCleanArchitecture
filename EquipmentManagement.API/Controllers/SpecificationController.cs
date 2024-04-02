using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using EquipmentManagement.Application.Feature.Location.Commands.DeleteLocation;
using EquipmentManagement.Application.Feature.Location.Commands.UpdateLocation;
using EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations;
using EquipmentManagement.Application.Feature.Specification.Commands.CreateSpec;
using EquipmentManagement.Application.Feature.Specification.Commands.DeleteSpec;
using EquipmentManagement.Application.Feature.Specification.Queries.GetSpec;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpecificationController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SpecificationController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetSpecs([FromQuery] string equipmentTypeId)
		{
			var specs = await _mediator.Send(new GetSpec { EquipmentTypeId= equipmentTypeId });
			return Ok(specs);
		}

		[HttpPost]
		public async Task<IActionResult> PostSpec([FromBody] CreateSpec spec)
		{
			var locationId = await _mediator.Send(spec);
			return Ok(locationId);

		}

		[HttpDelete]
		public async Task<IActionResult> DeleteLocation([FromQuery] string equipmentTypeId, string name)
		{
			var command = new DeleteSpec { EquipmentTypeId = equipmentTypeId, Name=name };
			var IdReturn = await _mediator.Send(command);
			return Ok(IdReturn);

		}
	}
}
