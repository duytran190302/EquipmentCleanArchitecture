using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations
{
	public record GetAllLocation: IRequest<List<LocationDTO>>;

}
