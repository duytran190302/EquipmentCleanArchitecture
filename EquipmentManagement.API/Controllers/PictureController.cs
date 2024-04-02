using EquipmentManagement.Application.Feature.Picture.Commands.CreatePicture;
using EquipmentManagement.Application.Feature.Picture.Commands.DeletePicture;
using EquipmentManagement.Application.Feature.Picture.Queries.GetPicture;
using EquipmentManagement.Application.Feature.Specification.Commands.CreateSpec;
using EquipmentManagement.Application.Feature.Specification.Commands.DeleteSpec;
using EquipmentManagement.Application.Feature.Specification.Queries.GetSpec;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PictureController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PictureController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetPics([FromQuery] string equipmentTypeId)
		{
			var pics = await _mediator.Send(new GetPicture { EquipmentTypeId = equipmentTypeId });
			return Ok(pics);
		}

		[HttpPost]
		public async Task<IActionResult> PostPic([FromBody] CreatePicture pic)
		{
			var id = await _mediator.Send(pic);
			return Ok(id);

		}

		[HttpDelete]
		public async Task<IActionResult> DeletePic([FromQuery] string equipmentTypeId)
		{
			var command = new DeletePicture { EquipmentTypeId = equipmentTypeId };
			var IdReturn = await _mediator.Send(command);
			return Ok(IdReturn);

		}
	}
}
