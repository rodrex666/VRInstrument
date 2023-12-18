using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateSounds : MonoBehaviour
{
    [SerializeField] private SoundInstruments _soundInstruments;

    private void OnEnable()
    {
        _soundInstruments.SetSoundParameters("R_T",0);
        _soundInstruments.SetSoundParameters("R_I",7);
        _soundInstruments.SetSoundParameters("R_M",2);
        _soundInstruments.SetSoundParameters("L_T",0);
        _soundInstruments.SetSoundParameters("L_I",7);
        _soundInstruments.SetSoundParameters("L_M",2);
        _soundInstruments.SetSoundParameters("Audio",5);
    }
}
