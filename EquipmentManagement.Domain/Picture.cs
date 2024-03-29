
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentManagement.Domain
{
	public class Picture 
	{
		public int PictureId { get; set; }
		[Column(TypeName = "VARBINARY(MAX)")]
		public byte[] FileData { get; set; }
		public string EquipmentTypeId { get; set; }
		public EquipmentType EquipmentType { get; set; }

	}
}
