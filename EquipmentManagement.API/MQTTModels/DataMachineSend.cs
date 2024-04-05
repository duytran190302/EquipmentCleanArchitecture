namespace EquipmentManagement.API.MQTTModels
{
	public class MachineDataSend
	{
		public string machineId { get; set; }
		public string name { get; set; }
		public string value { get; set; }
		public string timestamp { get; set; }
	}
}
