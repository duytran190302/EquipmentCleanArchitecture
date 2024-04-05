

using System.Text.Json;

namespace EquipmentManagement.API.Worker;

public class Buffer
{
	private readonly List<TagChangedNotification> tagChangedNotifications = new List<TagChangedNotification>();
	private static readonly List<string> dataMachine = new List<string> { "Operator", "Power", "MachineStatus", "Speed", "Vibration" };

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
	public List<TagChangedNotification> GetMachineData() => tagChangedNotifications.Where(x => dataMachine.Any(id=>id==x.Topic)).ToList();


	public string GetAllTag() => JsonSerializer.Serialize(tagChangedNotifications);
}
