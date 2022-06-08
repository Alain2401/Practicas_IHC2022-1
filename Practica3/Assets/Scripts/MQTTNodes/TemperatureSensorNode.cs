using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureSensorNode : BaseNode
{
    public string temperatureTopic = "casa/sala/sensor1";

    public float temperature = 20f;

    public float publishRate = 10f;

    private float publishTimer = 0;

    protected override void Start()
    {
        base.Start();

        PublishMessage(temperatureTopic, temperature.ToString());
    }

    protected override void PublishMessage(string topic, string message)
    {
        base.PublishMessage(topic, message);
    }

    // Update is called once per frame
    void Update()
    {
        if ((publishTimer += Time.deltaTime) >= publishRate)
        {
            temperature += 1f;

            PublishMessage(temperatureTopic, temperature.ToString());

            publishTimer = 0;
        } 
    }
}
