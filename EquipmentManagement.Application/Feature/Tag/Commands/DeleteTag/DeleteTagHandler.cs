using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Tag.Commands.DeleteTag
{
	public class DeleteTagHandler : IRequestHandler<DeleteTag, string>
	{
		private readonly IUnitOfWork _tagRepository;

		public DeleteTagHandler(IUnitOfWork tagRepository)
		{
			_tagRepository = tagRepository;
		}
		public async Task<string> Handle(DeleteTag request, CancellationToken cancellationToken)
		{


			var tagToDelete = await _tagRepository.tagRepository.GetByIdAsync(request.TagId);
			if (tagToDelete == null)
			{
				throw new NotFoundException(nameof(Tag), request.TagId);
			}

			_tagRepository.tagRepository.Remove(tagToDelete);
			await _tagRepository.SaveChangeAsync();
			return tagToDelete.TagDetail;
		}
	}
}
