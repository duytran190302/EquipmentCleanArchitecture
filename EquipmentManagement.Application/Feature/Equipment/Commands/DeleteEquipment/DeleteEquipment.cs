using EquipmentManagement.Application.Feature.EquipmentType.Commands.DeleteET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Equipment.Commands.DeleteEquipment;

public class DeleteEquipment : IRequest<string>
{
	public string EquipmentId { get; set; } = string.Empty;
}
