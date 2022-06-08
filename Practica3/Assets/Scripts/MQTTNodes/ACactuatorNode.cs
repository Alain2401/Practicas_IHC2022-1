using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt.Messages;

public class ACactuatorNode : BaseNode
{
    public float temperatureThresholdHigh = 26;

    public float temperatureThresholdLow = 19;

    private float temperature;

    protected override void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        base.ClientMqttMsgPublishReceived(sender, e);
    }

    private void Update()
    {
        if (string.IsNullOrEmpty(lastMessage)) return;
        temperature = float.Parse(lastMessage);
        if (temperature >= temperatureThresholdHigh)
        {
            Debug.Log("Turning on AC...");
        }
        else if (temperature <= temperatureThresholdLow)
        {
            Debug.Log("Turning off AC...");
        }
    }
}
