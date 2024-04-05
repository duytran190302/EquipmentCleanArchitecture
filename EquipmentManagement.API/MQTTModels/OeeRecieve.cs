namespace EquipmentManagement.API.MQTTModels
{
	public class OeeRecieve
	{
		public float shiftTime { get; set; }
		public float idleTime { get; set; }
		public float operationTime { get; set; }
		public DateTime timestamp {  get; set; }


	}
}
