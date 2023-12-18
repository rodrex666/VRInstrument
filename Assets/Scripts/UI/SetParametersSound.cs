using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParametersSound : MonoBehaviour
{
    [SerializeField] private SoundInstruments _instruments;

    public void SetAudioInstrument(int _value)
    {
        _instruments.SetSoundParameters("Audio",_value);
    }
    
}
