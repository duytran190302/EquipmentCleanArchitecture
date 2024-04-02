namespace EquipmentManagement.API.MQTTModels
{
	public class OeeRecieve
	{
		public DateTime timestamp { get; set; }
		public float shiftTime { get; set; }
		public float idleTime { get; set; }
		public float operationTime { get; set; }
	}
}
