

using System.Text.Json;

namespace EquipmentManagement.API.Worker;

public class Buffer
{
	private readonly List<TagChangedNotification> tagChangedNotifications = new List<TagChangedNotification>();

	public void Update(TagChangedNotification notification)
	{
		var existedNotification = tagChangedNotifications.FirstOrDefault(n => n.DeviceId == notification.DeviceId && n.Topic == notification.Topic);

		if (existedNotification is null)
		{
			tagChangedNotifications.Add(notification);
		}
		else
		{
			existedNotification.TagValue = notification.TagValue;
		}
	}
	public List<TagChangedNotification> GetMachineOee() => tagChangedNotifications.Where(x => x.Topic == "OEE").ToList();
	public List<TagChangedNotification> GetEnvironment() => tagChangedNotifications.Where(x => x.Topic == "Environment").ToList();
	public string GetAllTag() => JsonSerializer.Serialize(tagChangedNotifications);
}
