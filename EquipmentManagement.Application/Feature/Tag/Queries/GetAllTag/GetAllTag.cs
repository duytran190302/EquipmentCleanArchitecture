using MediatR;

namespace EquipmentManagement.Application.Feature.Tag.Queries.GetAllTag;

public record GetAllTag : IRequest<List<TagDTO>>;
