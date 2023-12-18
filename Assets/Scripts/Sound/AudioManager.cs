using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    /***
     * Script of TreverMock
     * https://github.com/trevermock/fmod-audio-system
     */
   
    private Bus masterBus;

    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;

    private EventInstance ambienceEventInstance;
    private EventInstance musicEventInstance;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Audio Manager");
        }
        Instance = this;

        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();
        
       
    }


 private void InitializeSynth(EventReference ambienceEventReference)
    {
        ambienceEventInstance = CreateInstance(ambienceEventReference);
        
    }

    public void PlayInstrument(EventReference _instrument)
    {
        musicEventInstance = CreateInstance(_instrument);
        musicEventInstance.start();
    }
   

    public void SetNoteParameter(string parameterName, int parameterValue)
    {
        ambienceEventInstance.setParameterByName(parameterName, parameterValue);
    }

   
    // public void PlayOneNote(EventReference sound, Vector3 worldPos) //changed
    // {
    //     RuntimeManager.PlayOneShot(sound, worldPos);
    // }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    public PARAMETER_DESCRIPTION GetIDofParameter(EventInstance instance, String parameterName)
    {
        EventDescription tempDescription;
        instance.getDescription(out tempDescription);
        PARAMETER_DESCRIPTION outParameterDescription;
        tempDescription.getParameterDescriptionByName(parameterName, out outParameterDescription);
        return outParameterDescription;
    }

    public GameObject AttachInstancetoObject(EventInstance instance, GameObject gameObject)
    {
        Transform temptransform = gameObject.GetComponent<Transform>();
        Rigidbody tempRigidbody = gameObject.GetComponent<Rigidbody>();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance,temptransform,tempRigidbody);
        return gameObject;
    }

    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
    {
        StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = eventReference;
        eventEmitters.Add(emitter);
        return emitter;
    }

    void CleanUp()
    {
        // stop and release any created instances
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
        // stop all of the event emitters, because if we don't they may hang around in other scenes
        foreach (StudioEventEmitter emitter in eventEmitters)
        {
            emitter.Stop();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
}
