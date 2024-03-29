using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Domain
{
	public class Specification
	{
		public int SpecificationId { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public string Unit { get; set; }

		public string EquipmentTypeId { get; set; }
		public EquipmentType EquipmentType { get; set; }

	}
}
