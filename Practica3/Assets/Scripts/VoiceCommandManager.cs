using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watsson.Examples;
using System;

public class VoiceCommandManager : MonoBehaviour
{
    private Dictionary<string, Action> commandDictionary = new Dictionary<string, Action>();

    public static VoiceCommandManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            FindObjectOfType<ExampleStreaming>().onTranscriptRecevied += ProcessTranscript;
        }
    }

    public void RegisterCommand(string command, Action callback)
    {
        if (!commandDictionary.ContainsKey(command))
        {
            commandDictionary.Add(command, callback);
        }
    }

    private void ProcessTranscript(string transcript)
    {
        if (commandDictionary.ContainsKey(transcript.Trim()))
        {
            ProcessComand(transcript.Trim());
        }
    }

    private void ProcessComand(string command)
    {
        Debug.Log($"procesando comando: {command}");
        commandDictionary[command].Invoke();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}