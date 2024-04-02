namespace EquipmentManagement.API.Worker;

public class TagChangedNotification
{
	public string Topic { get; set; }
	public string DeviceId { get; set; }
	public object TagValue { get; set; }

	public TagChangedNotification(string topic, string deviceId, object tagValue)
	{
		Topic = topic;
		DeviceId = deviceId;
		TagValue = tagValue;
	}
}
