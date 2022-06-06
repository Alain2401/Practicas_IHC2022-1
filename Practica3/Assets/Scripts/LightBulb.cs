using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    // Start is called before the first frame update
    public string turnOnCommand = "encender luz de la cocina";
    public string turnOffCommand = "fuera luz de la cocina";

    private Light lightComponent;

    private void Awake()
    {
        lightComponent = GetComponent<Light>();
    }

    void Start()
    {
        VoiceCommandManager.Instance.RegisterCommand(turnOnCommand, SwitchLightOn);
        VoiceCommandManager.Instance.RegisterCommand(turnOffCommand, SwitchLightOff);
    }

    private void SwitchLightOn()
    {
        lightComponent.enabled = true;
    }

    private void SwitchLightOff()
    {
        lightComponent.enabled = false;
    }
}