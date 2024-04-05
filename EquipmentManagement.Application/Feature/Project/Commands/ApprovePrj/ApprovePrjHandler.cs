using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Project.Commands.ApprovePrj;
public class ApprovePrjHandler : IRequestHandler<ApprovePrj, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public ApprovePrjHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(ApprovePrj request, CancellationToken cancellationToken)
	{


		var prjToApprove = await _unitOfWork.projectRepository.GetByIdAsync(request.ProjectName);
		if (prjToApprove == null)
		{
			throw new NotFoundException(nameof(Project), request.ProjectName);
		}
		prjToApprove.Approved = true;

		_unitOfWork.projectRepository.Update(prjToApprove);
		await _unitOfWork.SaveChangeAsync();
		return prjToApprove.ProjectName;
	}
}