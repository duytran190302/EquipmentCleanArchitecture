
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EquipmentManagement.Domain
{
	public class Borrow
	{
		public string BorrowId {  get; set; } = string.Empty;
		public DateTime BorrowedDate { get; set; }

		public DateTime ReturnedDate { get; set; }
		public DateTime? RealReturnedDate { get; set; }

		public string Borrower { get; set; } = string.Empty;
		public string Reason { get; set; } = string.Empty;
		public bool OnSide { get; set; }


		public string ProjectName { get; set; } = string.Empty;
		public Project? Project { get; set; }
		public List<Equipment>? Equipments { get; set; }
	}
}
