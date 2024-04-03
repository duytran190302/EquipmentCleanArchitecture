using EquipmentManagement.Application.Feature.EquipmentType.Queries.GetET;
using EquipmentManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.EquipmentType.Queries.GetETInfor;
public class GETETInforDTO
{
	public string equipmentTypeId { get; set; } = string.Empty;
	public List<Pics> Pics { get; set; }
	public List<Specs> Specs { get; set; }
}
public class Pics
{
	public byte[] FileData { get; set; }
}
public class Specs 
{
	public string Name { get; set; }
	public string Value { get; set; }
	public string Unit { get; set; }
}