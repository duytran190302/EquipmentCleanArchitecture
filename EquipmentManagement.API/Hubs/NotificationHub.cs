using EquipmentManagement.API.MQTTModels;
using EquipmentManagement.API.Worker;
using EquipmentManagement.Infrastructure.Communication;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Buffer = EquipmentManagement.API.Worker.Buffer;
namespace EquipmentManagement.API.Hubs;

public class NotificationHub : Hub
{
	private readonly Buffer _buffer;
	private readonly ManagedMqttClient _mqttClient;

	public NotificationHub(Buffer buffer, ManagedMqttClient mqttClient)
	{
		_buffer = buffer;
		_mqttClient = mqttClient;
	}

	public string SendAllMachineOee()
	{
		var a = new List<OeeSend>();
		List<TagChangedNotification> Oee = _buffer.GetMachineOee();
		foreach (TagChangedNotification oee in Oee)
		{
			var oeeObjectFromBuffer = JsonConvert.DeserializeObject<OeeSend>(oee.TagValue.ToString());
			var b = new OeeSend
			{
				Topic = oee.Topic,
				DeviceId = oee.DeviceId,
				IdleTime = oeeObjectFromBuffer.IdleTime,
				ShiftTime = oeeObjectFromBuffer.ShiftTime,
				Oee = oeeObjectFromBuffer.Oee,
				OperationTime = oeeObjectFromBuffer.OperationTime,
				Timestamp = oeeObjectFromBuffer.Timestamp,
			};
			a.Add(b);
		}
		string jsonDb = JsonConvert.SerializeObject(a);
		return jsonDb;
	}

	public string SendAllEnvironment()
	{
		var envSend = new List<EnvironmentSend>();
		List<TagChangedNotification> envs = _buffer.GetEnvironment();
		foreach (TagChangedNotification env in envs)
		{
			var envObjectFromBuffer = JsonConvert.DeserializeObject<EnvironmentSend>(env.TagValue.ToString());

			envSend.Add(envObjectFromBuffer);
		}
		string jsonDb = JsonConvert.SerializeObject(envSend);
		return jsonDb;
	}
	public string SendAllMachineData()
	{
		var dataSend = new List<MachineDataSend>();
		List<TagChangedNotification> machines = _buffer.GetMachineData();
		foreach (TagChangedNotification machine in machines)
		{
			var dataObjectFromBuffer = JsonConvert.DeserializeObject<MachineDataSend>(machine.TagValue.ToString());

			dataSend.Add(dataObjectFromBuffer);
		}
		string jsonDb = JsonConvert.SerializeObject(dataSend);
		return jsonDb;
	}

	public string SendAll()
	{
		string allTags = _buffer.GetAllTag();
		return allTags;
	}

	public async Task SendAllTag()
	{
		string allTags = _buffer.GetAllTag();

		await Clients.All.SendAsync("GetAll", allTags);
	}

	public async Task SendCommand(string deviceId, string command)
	{
		string topic = $"IOT/Detail/NewDetailToWork/{deviceId}";

		await _mqttClient.Publish(topic, command, true);
	}
}

