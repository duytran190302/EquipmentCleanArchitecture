using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EquipmentManagement.Domain;

public enum Category
{
	[Display(Name = "Mechanical")]
	[Description("Mechanical")]
	Mechanical = 1,

	[Description("IoT_robotics")]
	[Display(Name = "IoT_robotics")]
	IoT_robotics = 2,

	[Description("Automation")]
	[Display(Name = "Automation")]
	Automation = 3
}
