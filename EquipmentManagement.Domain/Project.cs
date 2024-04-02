

namespace EquipmentManagement.Domain
{
	public class Project 
	{
		public string ProjectName { get; set; } = string.Empty;
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime? RealEndDate { get; set; }
		public string Description { get; set; } = string.Empty;
		public bool Approved { get; set; }
		//
		public List<Borrow> Borrows { get; set; }
		public List<Equipment> Equipments { get; set; }


	}
}
