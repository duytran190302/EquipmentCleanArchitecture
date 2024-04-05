using EquipmentManagement.Application.Feature.Equipment.Queries.GetEquipment;
using EquipmentManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Project.Queries.GetAllPrj;

public class GetAllProjectDTO
{
	public string ProjectName { get; set; } = string.Empty;
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public DateTime? RealEndDate { get; set; }
	public string Description { get; set; } = string.Empty;
	public bool Approved { get; set; }
	//
	public List<string>? Borrows { get; set; }
	public List<string>? Equipments { get; set; }


}
