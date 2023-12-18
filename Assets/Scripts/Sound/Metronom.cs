using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMOD;

//The game object requires a Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class Metronom : MonoBehaviour
{
    private EventInstance _instanceMetronom;
    private Rigidbody _rb;
    private PARAMETER_DESCRIPTION _tempoMetronom;
    private PARAMETER_DESCRIPTION _soundMetronom;
    
    private int _valueTempo =1;//Range 1-6
    private int _valueSound =0;//Range 0-2

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _instanceMetronom = AudioManager.Instance.CreateInstance(FMODEvents.Instance.Metronom);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(_instanceMetronom,transform,_rb);
        _tempoMetronom = AudioManager.Instance.GetIDofParameter(_instanceMetronom, "Tempo");
        _soundMetronom = AudioManager.Instance.GetIDofParameter(_instanceMetronom, "Sound");
    }

    public void StartMetronom()
    {
        _instanceMetronom.setParameterByID(_tempoMetronom.id, _valueTempo);
        _instanceMetronom.setParameterByID(_soundMetronom.id, _valueSound);
        _instanceMetronom.start();
    }
    public void StopMetronom()
    {
        _instanceMetronom.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void SetValueTempo(int value)
    {
        var temp = Math.Clamp(value, 1, 6);
        _valueTempo = temp;
    }
    public void SetValueSound(int value)
    {
        var temp = Math.Clamp(value, 0, 2);
        _valueSound = temp;
    }
   
}
