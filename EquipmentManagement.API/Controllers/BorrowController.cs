using EquipmentManagement.Application.Feature.Borrow.Commands.CreateBorrow;
using EquipmentManagement.Application.Feature.Borrow.Commands.DeleteBorrow;
using EquipmentManagement.Application.Feature.Borrow.Commands.Return;
using EquipmentManagement.Application.Feature.Borrow.Commands.UpdateBorrow;
using EquipmentManagement.Application.Feature.Borrow.Queries.GetAllBorrow;
using EquipmentManagement.Application.Feature.Equipment.Commands.ChangeEquipmentStatus;
using EquipmentManagement.Application.Feature.Equipment.Commands.CreateEquipment;
using EquipmentManagement.Application.Feature.Equipment.Commands.DeleteEquipment;
using EquipmentManagement.Application.Feature.Equipment.Commands.UpdateEquipment;
using EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipment;
using EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipmentEnhanced;
using EquipmentManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BorrowController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BorrowController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetBorrow(
			[FromQuery] string? borrower,
			bool? onSide, string borrowId,
			string? projectName,
			DateTime? startDate, DateTime? endDate,

			int pageSize = 20, int pageNumber = 1)
		{
			var et = await _mediator.Send(new GetBorrow { Borrower = borrower,OnSide=onSide,BorrowId= borrowId,ProjectName= projectName,
			BorrowedDate= startDate, ReturnedDate= endDate,
			});

			et = et.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(et);
		}
		

		[HttpPost]
		public async Task<IActionResult> PostBorrow([FromBody] CreateBorrow e)
		{
			var id = await _mediator.Send(e);
			return Ok(id);

		}
		[HttpPut]
		public async Task<IActionResult> PutBorrow([FromBody] UpdateBorrow e)
		{
			var id = await _mediator.Send(e);
			return Ok(id);

		}
		[HttpPut("return")]
		public async Task<IActionResult> Return([FromBody] Return e)
		{
			var id = await _mediator.Send(e);
			return Ok(id);

		}
		[HttpDelete]
		public async Task<IActionResult> DeleteBorrow([FromQuery] string id)
		{
			var command = new DeleteBorrow { BorrowId = id };
			var IdReturn = await _mediator.Send(command);
			return Ok(IdReturn);

		}
	}
}
