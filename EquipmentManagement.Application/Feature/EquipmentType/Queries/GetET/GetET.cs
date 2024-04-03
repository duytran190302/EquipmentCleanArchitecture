using EquipmentManagement.Application.Feature.Picture.Queries.GetPicture;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.EquipmentType.Queries.GetET;
public class GetET : IRequest<List<GetETDTO>>
{
	public string? Search { get; set; } = string.Empty;
}
