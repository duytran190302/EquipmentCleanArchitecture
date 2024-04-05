using EquipmentManagement.Application.Feature.EquipmentType.Commands.CreateET;
using EquipmentManagement.Application.Feature.EquipmentType.Commands.DeleteET;
using EquipmentManagement.Application.Feature.EquipmentType.Commands.UpdateET;
using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetET;
using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETEnhanced;
using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETInfor;
using EquipmentManagement.Application.Feature.Project.Commands.ApprovePrj;
using EquipmentManagement.Application.Feature.Project.Commands.CreatePrj;
using EquipmentManagement.Application.Feature.Project.Commands.DeletePrj;
using EquipmentManagement.Application.Feature.Project.Commands.EndProject;
using EquipmentManagement.Application.Feature.Project.Commands.UpdatePrj;
using EquipmentManagement.Application.Feature.Project.Queries.GetAllPrj;
using EquipmentManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProjectController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetPrjs([FromQuery] string? search,int? year, int pageSize = 20, int pageNumber = 1)
		{
			var et = await _mediator.Send(new GetAllProject { Search = search,Year=year });

			et = et.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(et);
		}


		[HttpPost]
		public async Task<IActionResult> PostPrj([FromBody] CreatePrj et)
		{
			var id = await _mediator.Send(et);
			return Ok(id);

		}
		[HttpPut]
		public async Task<IActionResult> PutET([FromBody] UpdatePrj et)
		{
			var id = await _mediator.Send(et);
			return Ok(id);

		}
		[HttpPut("EndPrj")]
		public async Task<IActionResult> EndPrj([FromBody] EndPrj et)
		{
			var id = await _mediator.Send(et);
			return Ok(id);

		}
		[HttpPut("Approve")]
		public async Task<IActionResult> ApprovePrj([FromBody] ApprovePrj et)
		{
			var id = await _mediator.Send(et);
			return Ok(id);

		}


		[HttpDelete]
		public async Task<IActionResult> DeletePrj([FromQuery] string id)
		{
			var command = new DeletePrj { ProjectName = id };
			var IdReturn = await _mediator.Send(command);
			return Ok(IdReturn);

		}
	}
}
