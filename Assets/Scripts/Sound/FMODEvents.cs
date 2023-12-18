using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    /*
     * This is a Singleton to collect all sounds. 
     */
    // Right Hand
    [field: Header("Right Index")] 
    [field: SerializeField] public EventReference RIndex { get; private set; }
    [field: Header("Right Middle")] 
    [field: SerializeField] public EventReference RMiddle { get; private set; }
    [field: Header("Right Ring")] 
    [field: SerializeField] public EventReference RRing { get; private set; }
    [field: Header("Right Little")] 
    [field: SerializeField] public EventReference RLittle { get; private set; }
    [field: Header("Right Thumb")] 
    [field: SerializeField] public EventReference RThumb { get; private set; }
    //Left Hand
    [field: Header("Left Index")] 
    [field: SerializeField] public EventReference LIndex { get; private set; }
    [field: Header("Left Middle")] 
    [field: SerializeField] public EventReference LMiddle { get; private set; }
    [field: Header("Left Ring")] 
    [field: SerializeField] public EventReference LRing { get; private set; }
    [field: Header("Left Little")] 
    [field: SerializeField] public EventReference LLittle { get; private set; }
    [field: Header("Left Thumb")] 
    [field: SerializeField] public EventReference LThumb { get; private set; }
    //UI Sound
    [field: Header("Button Sound")] 
    [field: SerializeField] public EventReference ButtonClick { get; private set; }
    [field: Header("Button Sound 2")] 
    [field: SerializeField] public EventReference ButtonClick2 { get; private set; }
    [field: Header("Button Sound 3")] 
    [field: SerializeField] public EventReference ButtonClick3 { get; private set; }
    public static FMODEvents Instance { get; private set; }
    
    //Drums and Metronom
    //Metronom
    [field: Header("Metronom")] 
    [field: SerializeField] public EventReference Metronom { get; private set; }
    //Drums
    [field: Header("Clap Clap")] 
    [field: SerializeField] public EventReference Clap { get; private set; }
    [field: Header("Drum Kick")] 
    [field: SerializeField] public EventReference DrumBass { get; private set; }
    [field: Header("Drum Snare")] 
    [field: SerializeField] public EventReference SnareDrum { get; private set; }
    
    //To save Here in this Event
    [field: Header("Recorded Sound ")] 
    [field: SerializeField] public EventReference SoundSaved { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found other instance FMOD Events");
        }

        Instance = this;
    }
}
