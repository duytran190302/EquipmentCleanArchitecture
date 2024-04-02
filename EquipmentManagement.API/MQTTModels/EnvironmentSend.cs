namespace EquipmentManagement.API.MQTTModels
{
	public class EnvironmentSend
	{
		public string sensorId { get; set; }
		public string name { get; set; }
		public string value { get; set; }
		public string timestamp { get; set; }
	}
}
