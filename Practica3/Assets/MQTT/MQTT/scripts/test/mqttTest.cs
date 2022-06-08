using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;

using System;

public class mqttTest : MonoBehaviour {
	public string brokerHostName = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string temperatureTopic = "casa/sala/temperatura";
	public string lightTopic = "casa/sala/luz";
	private MqttClient client;
	public Text displayText;
	public GameObject directionalLight;
	string lastMessage;
	volatile bool lightState = false;
	// Use this for initialization
	void Start () {
		// create client instance 
		client = new MqttClient((brokerHostName), brokerPort, false, null); 
		
		// register to message received 
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
		
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
		
		// subscribe to the topic "/home/temperature" with QoS 2 
		client.Subscribe(new string[] { temperatureTopic, lightTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
		//client.Subscribe(new string[] { lightTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });  

	}
	void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		if(e.Topic.Equals(lightTopic))
		{
			if(lastMessage.Equals("lightOn"))
			{
				lightState = true;
			}
			else if(lastMessage.Equals("lightOff"))
			{
				lightState = false;
			}
		}
	}

	void Update()
	{
		if (displayText != null)
			displayText.text = lastMessage;
		if (lightState != directionalLight.activeSelf)
			directionalLight.SetActive(lightState);
	}

	void OnGUI(){
		if ( GUI.Button (new Rect (20,40,80,20), "Encender")) {
			Debug.Log("sending...");
			client.Publish(lightTopic, System.Text.Encoding.UTF8.GetBytes("lightOn"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
		}
		if (GUI.Button(new Rect(50, 70, 110, 35), "Apagar"))
		{
			Debug.Log("sending...");
			client.Publish(lightTopic, System.Text.Encoding.UTF8.GetBytes("lightOff"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
		}
	}

	void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
