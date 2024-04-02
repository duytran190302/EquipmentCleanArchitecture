using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using EquipmentManagement.Application.Feature.Location.Commands.DeleteLocation;
using EquipmentManagement.Application.Feature.Location.Commands.UpdateLocation;
using EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations;
using EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier;
using EquipmentManagement.Application.Feature.Supplier.Commands.DeleteSupplier;
using EquipmentManagement.Application.Feature.Supplier.Commands.UpdateSupplier;
using EquipmentManagement.Application.Feature.Supplier.Queries.GetAllSupplier;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupplierController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SupplierController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetSuppliers([FromQuery] string? search, int pageSize = 20, int pageNumber = 1)
		{
			var suppliers = await _mediator.Send(new GetAllSupplier());
			if (search != null)
			{
				suppliers = suppliers.Where(x => x.SupplierName == search).ToList();
			}
			suppliers = suppliers.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(suppliers);
		}

		[HttpPost]
		public async Task<IActionResult> PostSupplier([FromBody] CreateSupplier supplier)
		{
			CreateSupplier command = supplier;
			var supplierName = await _mediator.Send(command);
			return Ok(supplierName);

		}
		[HttpPut]
		public async Task<IActionResult> PutSupplier([FromBody] UpdateSupplier supplier)
		{
			UpdateSupplier command = supplier;
			var supplierName = await _mediator.Send(command);
			return Ok(supplierName);

		}
		[HttpDelete]
		public async Task<IActionResult> DeleteSupplier([FromQuery] string supplierName)
		{
			var command = new DeleteSupplier { SupplierName = supplierName };
			var supplierToDel = await _mediator.Send(command);
			return Ok(supplierToDel);

		}
	}
}
