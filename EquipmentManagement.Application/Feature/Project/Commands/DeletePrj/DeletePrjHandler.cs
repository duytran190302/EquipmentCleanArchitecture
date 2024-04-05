using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.Supplier.Commands.DeleteSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Project.Commands.DeletePrj;
public class DeletePrjHandler : IRequestHandler<DeletePrj, string>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeletePrjHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(DeletePrj request, CancellationToken cancellationToken)
	{


		var prjToDelete = await _unitOfWork.projectRepository.GetByIdAsync(request.ProjectName);
		if (prjToDelete == null)
		{
			throw new NotFoundException(nameof(Project), request.ProjectName);
		}
		prjToDelete.Equipments = null;
		prjToDelete.Borrows = null;
		 _unitOfWork.projectRepository.Update(prjToDelete);
		_unitOfWork.projectRepository.Remove(prjToDelete);
		await _unitOfWork.SaveChangeAsync();
		return prjToDelete.ProjectName;
	}
}