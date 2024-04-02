using EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier;
using EquipmentManagement.Application.Feature.Supplier.Commands.DeleteSupplier;
using EquipmentManagement.Application.Feature.Supplier.Commands.UpdateSupplier;
using EquipmentManagement.Application.Feature.Supplier.Queries.GetAllSupplier;
using EquipmentManagement.Application.Feature.Tag.Commands.CreateTag;
using EquipmentManagement.Application.Feature.Tag.Commands.DeleteTag;
using EquipmentManagement.Application.Feature.Tag.Commands.UpdateTag;
using EquipmentManagement.Application.Feature.Tag.Queries.GetAllTag;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TagController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetTags([FromQuery] string? search, int pageSize = 20, int pageNumber = 1)
		{
			var tags = await _mediator.Send(new GetAllTag());
			if (search != null)
			{
				tags = tags.Where(x => x.TagId == search).ToList();
			}
			tags = tags.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(tags);
		}

		[HttpPost]
		public async Task<IActionResult> PostTag([FromBody] CreateTag tag)
		{
			var supplierName = await _mediator.Send(tag);
			return Ok(supplierName);

		}
		[HttpPut]
		public async Task<IActionResult> PutTag([FromBody] UpdateTag tag)
		{
			var tagId = await _mediator.Send(tag);
			return Ok(tagId);

		}
		[HttpDelete]
		public async Task<IActionResult> DeleteSupplier([FromQuery] string tagId)
		{
			var command = new DeleteTag { TagId = tagId };
			var tagToDel = await _mediator.Send(command);
			return Ok(tagToDel);

		}
	}
}
