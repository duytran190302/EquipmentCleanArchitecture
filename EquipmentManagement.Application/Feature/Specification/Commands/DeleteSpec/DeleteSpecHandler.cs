using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Specification.Commands.DeleteSpec;

public class DeleteSpecHandler : IRequestHandler<DeleteSpec, string>
{
	private readonly IUnitOfWork _specRepository;

	public DeleteSpecHandler(IUnitOfWork specRepository)
	{
		_specRepository = specRepository;
	}
	public async Task<string> Handle(DeleteSpec request, CancellationToken cancellationToken)
	{


		var specToDelete =  _specRepository.specificationRepository
			.FindByCondition(x=> x.EquipmentTypeId == request.EquipmentTypeId).ToList();
		   specToDelete = specToDelete.Where(x=>x.Name == request.Name).ToList();

		if (specToDelete == null)
		{
			throw new NotFoundException(nameof(Specification), request.Name);
		}

		_specRepository.specificationRepository.RemoveRange(specToDelete);
		await _specRepository.SaveChangeAsync();
		return request.EquipmentTypeId;
	}
}
