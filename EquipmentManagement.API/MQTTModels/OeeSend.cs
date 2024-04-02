namespace EquipmentManagement.API.MQTTModels
{
	public class OeeSend
	{
		public string Topic { get; set; }
		public string DeviceId { get; set; }
		public DateTime Timestamp { get; set; }
		public float IdleTime { get; set; }
		public float ShiftTime { get; set; }
		public float OperationTime { get; set; }
		public float Oee { get; set; }
	}
}
