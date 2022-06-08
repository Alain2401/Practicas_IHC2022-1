using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;
using System.Collections.Generic;

public class BaseNode : MonoBehaviour
{
    public string brokerHostName = "test.mosquitto.org";

    public int brokerPort = 1883;

	public List<string> subscribers = new List<string>();

	//public string[] publishers;

    protected MqttClient client;

    protected string lastMessage;

	// Start is called before the first frame update
	protected virtual void Start()
	{
		// create client instance 
		client = new MqttClient((brokerHostName), brokerPort, false, null);

		// register to message received 
		client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;

		string clientId = Guid.NewGuid().ToString();
		client.Connect(clientId);

		// subscribe to the topic "/home/temperature" with QoS 2 
		if (subscribers.Count > 0)
        {
			byte[] qosArray = new byte[subscribers.Count];
			for (int i = 0; 1 > qosArray.Length; i++) qosArray[i] = MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE;
			client.Subscribe(subscribers.ToArray(), qosArray);
		}

	}

	protected virtual void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
	{
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
	
	}

	protected virtual void PublishMessage(string topic, string message)
    {
		Debug.Log("Sending message from Node{gameObject.name} to topic {topic}");
		client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
	}

	void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
