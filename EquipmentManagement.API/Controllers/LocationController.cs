using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using EquipmentManagement.Application.Feature.Location.Commands.DeleteLocation;
using EquipmentManagement.Application.Feature.Location.Commands.UpdateLocation;
using EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations;
using EquipmentManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LocationController(IMediator mediator)
        {
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetLocations([FromQuery] string? search, int pageSize = 0, int pageNumber = 1)
		{
			var location = await _mediator.Send(new GetAllLocation());
			return Ok(location);
		}

		[HttpPost]
		public async Task<IActionResult> PostLocation([FromBody] CreateLocation locationDTO)
		{
			CreateLocation command = locationDTO;
			var locationId= await _mediator.Send(command);
			return Ok(locationId);

		}
		[HttpPut]
		public async Task<IActionResult> PutLocation([FromBody] UpdateLocation locationDTO)
		{
			UpdateLocation command = locationDTO;
			var locationId = await _mediator.Send(command);
			return Ok(locationId);

		}
		[HttpDelete]
		public async Task<IActionResult> DeleteLocation([FromQuery]  string locationId)
		{
			var command = new DeleteLocation { LocationId = locationId };
			var locationIdReturn = await _mediator.Send(command);
			return Ok(locationIdReturn);

		}
	}
}
