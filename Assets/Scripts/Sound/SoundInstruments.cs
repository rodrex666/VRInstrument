using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class SoundInstruments : MonoBehaviour
{
    /*
     * Event number | Note
     * 0    | C
     * 1    | C#/Db
     * 2    | D
     * 3    | D#/Eb
     * 4    | E
     * 5    | F
     * 6    | F#/Gb
     * 7    | G
     * 8    | G#/Ab
     * 9    | A
     * 10   | A#/Bb
     * 11   | B
     * 12   | C2
     * 
     */
   
    /// <summary>
    /// On these Lists for every hand correspond 0 to index, 1 Middle, 2 Ring, 3 Little, 4 Thumb
    /// </summary>

    private List<EventInstance> _rightFingers = new();
    private List<EventInstance> _leftFingers = new();

    private EventInstance _drums;
    private EventInstance _snare;
    private EventInstance _clap;
    
    private List<PARAMETER_DESCRIPTION> _pitchRight = new();
    private List<PARAMETER_DESCRIPTION> _pitchLeft = new();
    private List<PARAMETER_DESCRIPTION> _tremoloRight = new();
    private List<PARAMETER_DESCRIPTION> _tremoloLeft = new();
    private List<PARAMETER_DESCRIPTION> _noteRight = new();
    private List<PARAMETER_DESCRIPTION> _noteLeft = new();
    private List<PARAMETER_DESCRIPTION> _instrumentRight = new();
    private List<PARAMETER_DESCRIPTION> _instrumentLeft = new();
    private List<PARAMETER_DESCRIPTION> _radiusRight = new();
    private List<PARAMETER_DESCRIPTION> _radiusLeft = new();
    
    

    private PARAMETER_DESCRIPTION _typeSoundClap; // 0 = clap, 1 = cymbal, 2 = cymbal 2, 3 = Cymbal 3
    private PARAMETER_DESCRIPTION _typeSoundSnare; // 0 = Tomtom, 1 = snare 

    private PARAMETER_DESCRIPTION _radiusDrums;
    private PARAMETER_DESCRIPTION _radiusClap;
    private PARAMETER_DESCRIPTION _radiusSnare;
  
    [FormerlySerializedAs("Right pitch")] [Range(-0.5f, 0.5f)] public float R_pitch;
    [FormerlySerializedAs("Left pitch")] [Range(-0.5f, 0.5f)] public float L_pitch;
    [FormerlySerializedAs("Right tremolo")] [Range(0, 1)] public float R_tremolo;
    [FormerlySerializedAs("Left tremolo")] [Range(0, 1)] public float L_tremolo;
    
    private int AudioInstrument; // Select Audio Synthesizer or other Audio

    private Dictionary<string,int> _soundOptions = new(); // Select Note to play

    //Play or Stop hand music
    private bool _playInstrument = false;

    /// <summary>
    /// Here comes the hands to check the velocity in x or y to modify pitch and tremolo
    /// </summary>
 
   
    //private OVRInput.Controller controllerMask;

    [SerializeField] private GameObject OculusHand_R;
    [SerializeField] private GameObject OculusHand_L;
    private Vector3 _velocityRightHand;
    private Vector3 _accelerationRightHand;
    private Vector3 _lastVelocityRightHand = Vector3.zero;
    private Vector3 _velocityLeftHand;
    private Vector3 _accelerationLeftHand;
    private Vector3 _lastVelocityLeftHand = Vector3.zero;

    //Variable to record notes and conditions
    [SerializeField] private RecordNotesPerTime _recordNotesPerTime;
    
    //Variable to control the radius of the sound
    private float _radiusSound = 4.0f;

    private void Start()
    {
        CreateInstancesToPlay();
        CreateParameter();
        FillDictionaryInitial();
    }

    private void Update()
    {
        
        if (OVRPlugin.GetHandTrackingEnabled())
        {
            if (_playInstrument)
            {
                SetEffects();
                _velocityLeftHand = (OculusHand_L.transform.position - _lastVelocityLeftHand);
                _accelerationLeftHand += _velocityLeftHand/10;
                _lastVelocityLeftHand = _velocityLeftHand;
                L_pitch = Math.Clamp(_accelerationLeftHand.y, -0.5f, 0.5f);
                L_tremolo = Math.Clamp(_accelerationLeftHand.x, 0f, 1f);
                //Debug.Log("Acceleration Left Hand Y: "+_velocityLefttHand.y);
                _velocityRightHand = (OculusHand_R.transform.position - _lastVelocityRightHand);
                _accelerationRightHand += _velocityRightHand/10;
                _lastVelocityRightHand = _velocityRightHand;
                R_pitch = Math.Clamp(_accelerationRightHand.y, -0.5f, 0.5f);
                R_tremolo = Math.Clamp(_accelerationRightHand.x, 0f, 1f);
                //Debug.Log("Acceleration Right Hand X: "+_accelerationRightHand.x);
            }
        }
       
    }
    //Sets the value of the dictionary
    public void SetSoundParameters(string _name,int _value )
    {
        switch (_name)
        {
            case "R_I": _soundOptions["R_I"] = _value; break;
            case "R_M": _soundOptions["R_M"] = _value; break;
            case "R_R": _soundOptions["R_R"] = _value; break;
            case "R_L": _soundOptions["R_L"] = _value; break;
            case "R_T": _soundOptions["R_T"] = _value; break;
            case "L_I": _soundOptions["L_I"] = _value; break;
            case "L_M": _soundOptions["L_M"] = _value; break;
            case "L_R": _soundOptions["L_R"] = _value; break;
            case "L_L": _soundOptions["L_L"] = _value; break;
            case "L_T": _soundOptions["L_T"] = _value; break;
            case "Audio": AudioInstrument = _value; break;
            default: Debug.LogError("error no value in Dictionary"); break;
        }
        //Debug.Log("Value sound option: "+_soundOptions[_name]);
    }

    public int GetSoundParameters(String _parameter)
    {
        return _soundOptions[_parameter];
    }
    
    void ResetHandVelocity()
    {
        _lastVelocityRightHand = OculusHand_R.transform.position;
        _lastVelocityLeftHand = OculusHand_L.transform.position;
        _accelerationLeftHand = Vector3.zero;
        _accelerationRightHand = Vector3.zero;
    }

    void FillDictionaryInitial()
    {
        _soundOptions.Add("R_I",0);
        _soundOptions.Add("R_M",0);
        _soundOptions.Add("R_R",0);
        _soundOptions.Add("R_L",0);
        _soundOptions.Add("R_T",0);
        _soundOptions.Add("L_I",0);
        _soundOptions.Add("L_M",0);
        _soundOptions.Add("L_R",0);
        _soundOptions.Add("L_L",0);
        _soundOptions.Add("L_T",0);
    }

    void CreateInstancesToPlay()
    {
        _rightFingers.Add(AudioManager.Instance.CreateInstance(FMODEvents.Instance.RIndex));
        _rightFingers.Add(AudioManager.Instance.CreateInstance(FMODEvents.Instance.RMiddle));
        _rightFingers.Add(AudioManager.Instance.CreateInstance(FMODEvents.Instance.RRing));
        _rightFingers.Add(AudioManager.Instance.CreateInstance(FMODEvents.Instance.RLittle));
        _rightFingers.Add(AudioManager.Instance.CreateInstance(FMODEvents.Instance.RThumb));
        
        _leftFingers.Add(AudioManager.Instance.CreateInstance(FMODEvents.Instance.LIndex));
        _leftFingers.Add(AudioManager.Instance.CreateInstance(FMODEvents.Instance.LMiddle));
        _leftFingers.Add(AudioManager.Instance.CreateInstance(FMODEvents.Instance.LRing));
        _leftFingers.Add(AudioManager.Instance.CreateInstance(FMODEvents.Instance.LLittle));
        _leftFingers.Add(AudioManager.Instance.CreateInstance(FMODEvents.Instance.LThumb));
        
        _drums = AudioManager.Instance.CreateInstance(FMODEvents.Instance.DrumBass);
        _clap= AudioManager.Instance.CreateInstance(FMODEvents.Instance.Clap);
        _snare = AudioManager.Instance.CreateInstance(FMODEvents.Instance.SnareDrum);
        
        AudioManager.Instance.AttachInstancetoObject(_drums, gameObject);
        AudioManager.Instance.AttachInstancetoObject(_clap, gameObject);
        AudioManager.Instance.AttachInstancetoObject(_snare, gameObject);
        foreach (var _finger in _rightFingers)
        {
            AudioManager.Instance.AttachInstancetoObject(_finger, gameObject);
        }
        foreach (var _finger in _leftFingers)
        {
            AudioManager.Instance.AttachInstancetoObject(_finger, gameObject);
        }
    }

    void CreateParameter()
    {
        //Right Hand
        
        foreach (var _rightFinger in _rightFingers)
        {
            //Pitch
            _pitchRight.Add(AudioManager.Instance.GetIDofParameter(_rightFinger, "Pitch"));

            //Tremolo

            _tremoloRight.Add(AudioManager.Instance.GetIDofParameter(_rightFinger, "Tremolo"));

            //Note

            _noteRight.Add(AudioManager.Instance.GetIDofParameter(_rightFinger, "Note"));

            //Instrument

            _instrumentRight.Add(AudioManager.Instance.GetIDofParameter(_rightFinger, "Instrument"));
            
            //Radius
            _radiusRight.Add(AudioManager.Instance.GetIDofParameter(_rightFinger, "Radius"));
        }

        //Left Hand
        
        foreach (var _leftFinger in _leftFingers)
        {
            //Pitch
            _pitchLeft.Add(AudioManager.Instance.GetIDofParameter(_leftFinger,"Pitch"));
        
            //Tremolo
       
            _tremoloLeft.Add(AudioManager.Instance.GetIDofParameter(_leftFinger,"Tremolo"));
        
            //Note
        
            _noteLeft.Add(AudioManager.Instance.GetIDofParameter(_leftFinger,"Note"));
        
            //Instrument
        
            _instrumentLeft.Add(AudioManager.Instance.GetIDofParameter(_leftFinger,"Instrument"));
            
            //Radius
            _radiusLeft.Add(AudioManager.Instance.GetIDofParameter(_leftFinger, "Radius"));
        }
        _typeSoundClap = AudioManager.Instance.GetIDofParameter(_clap,"Note"); //Range 0-3
        _typeSoundSnare = AudioManager.Instance.GetIDofParameter(_snare,"Note"); // Range 0-1
        _radiusClap = AudioManager.Instance.GetIDofParameter(_clap,"Radius");
        _radiusDrums = AudioManager.Instance.GetIDofParameter(_drums,"Radius");
        _radiusSnare = AudioManager.Instance.GetIDofParameter(_snare,"Radius");
    }

    public void SetStartMusic()
    {
        _playInstrument = !_playInstrument;

    }

    void SetEffects()
    {
        _rightFingers[0].setParameterByID(_pitchRight[0].id, R_pitch);
        _rightFingers[0].setParameterByID(_tremoloRight[0].id, R_tremolo);
        _rightFingers[1].setParameterByID(_pitchRight[1].id, R_pitch);
        _rightFingers[1].setParameterByID(_tremoloRight[1].id, R_tremolo);
        _rightFingers[2].setParameterByID(_pitchRight[2].id, R_pitch);
        _rightFingers[2].setParameterByID(_tremoloRight[2].id, R_tremolo);
        _rightFingers[3].setParameterByID(_pitchRight[3].id, R_pitch);
        _rightFingers[3].setParameterByID(_tremoloRight[3].id, R_tremolo);
        _rightFingers[4].setParameterByID(_pitchRight[4].id, R_pitch);
        _rightFingers[4].setParameterByID(_tremoloRight[4].id, R_tremolo);
        _leftFingers[0].setParameterByID(_pitchLeft[0].id, L_pitch);
        _leftFingers[0].setParameterByID(_tremoloLeft[0].id, L_tremolo);
        _leftFingers[1].setParameterByID(_pitchLeft[1].id, L_pitch);
        _leftFingers[1].setParameterByID(_tremoloLeft[1].id, L_tremolo);
        _leftFingers[2].setParameterByID(_pitchLeft[2].id, L_pitch);
        _leftFingers[2].setParameterByID(_tremoloLeft[2].id, L_tremolo);
        _leftFingers[3].setParameterByID(_pitchLeft[3].id, L_pitch);
        _leftFingers[3].setParameterByID(_tremoloLeft[3].id, L_tremolo);
        _leftFingers[4].setParameterByID(_pitchLeft[4].id, L_pitch);
        _leftFingers[4].setParameterByID(_tremoloLeft[4].id, L_tremolo);
    }
    
    //Right Hand
   public void Right_Index ()
    {
        if (_playInstrument)
        {
            ResetHandVelocity();
            _rightFingers[0].setParameterByID(_noteRight[0].id, _soundOptions["R_I"]);
            _rightFingers[0].setParameterByID(_instrumentRight[0].id, AudioInstrument);
            _rightFingers[0].setParameterByID(_radiusRight[0].id, _radiusSound);
            _rightFingers[0].start();
            _recordNotesPerTime.SetNotesPerTime("R_I",_soundOptions["R_I"],R_pitch,R_tremolo,AudioInstrument);
        }
        
        
    }

    public void Stop_RI()
    {
        ResetHandVelocity();
    }
    public void Right_Middle()
    {
     
        if (_playInstrument)
        {
            ResetHandVelocity();
            _rightFingers[1].setParameterByID(_noteRight[1].id, _soundOptions["R_M"]);
            _rightFingers[1].setParameterByID(_instrumentRight[1].id, AudioInstrument);
            _rightFingers[1].setParameterByID(_radiusRight[1].id, _radiusSound);
            _rightFingers[1].start();
            _recordNotesPerTime.SetNotesPerTime("R_M",_soundOptions["R_M"],R_pitch,R_tremolo,AudioInstrument);
        }
        
    }

    public void Stop_RM()
    {
        ResetHandVelocity();
    }
    public void Right_Ring ()
    {
        if (_playInstrument)
        {
            ResetHandVelocity();
            _rightFingers[2].setParameterByID(_noteRight[2].id, _soundOptions["R_R"]);
            _rightFingers[2].setParameterByID(_radiusRight[2].id, _radiusSound);
            _rightFingers[2].setParameterByID(_instrumentRight[2].id, AudioInstrument);
            _rightFingers[2].start();
            _recordNotesPerTime.SetNotesPerTime("R_R",_soundOptions["R_R"],R_pitch,R_tremolo,AudioInstrument);
        }
       
    }

    public void Stop_RR()
    {
        ResetHandVelocity();
    }
    public void Right_Little () 
    {
        if (_playInstrument)
        {
            ResetHandVelocity();
            _rightFingers[3].setParameterByID(_noteRight[3].id, _soundOptions["R_L"]);
            _rightFingers[3].setParameterByID(_radiusRight[3].id, _radiusSound);
            _rightFingers[3].setParameterByID(_instrumentRight[3].id, AudioInstrument);
            _rightFingers[3].start();
            _recordNotesPerTime.SetNotesPerTime("R_L",_soundOptions["R_L"],R_pitch,R_tremolo,AudioInstrument);
        }
        
    }

    public void Stop_RL()
    {
        ResetHandVelocity();
    }
    public void Right_Thumb ()
    {
        
     
        if (_playInstrument)
        {
            ResetHandVelocity();
            _rightFingers[4].setParameterByID(_noteRight[4].id, _soundOptions["R_T"]);
            _rightFingers[4].setParameterByID(_instrumentRight[4].id, AudioInstrument);
            _rightFingers[4].setParameterByID(_radiusRight[4].id, _radiusSound);
            _rightFingers[4].start();
            _recordNotesPerTime.SetNotesPerTime("R_T",_soundOptions["R_T"],R_pitch,R_tremolo,AudioInstrument);
        }
    }

    public void Stop_RT()
    {
        ResetHandVelocity();
    }
   
    // Left Hand
    public void Left_Index ()
    {
        
        if (_playInstrument)
        {
            ResetHandVelocity();
            _leftFingers[0].setParameterByID(_noteLeft[0].id, _soundOptions["L_I"]);
            _leftFingers[0].setParameterByID(_radiusLeft[0].id, _radiusSound);
            _leftFingers[0].setParameterByID(_instrumentLeft[0].id, AudioInstrument);
            _leftFingers[0].start();
            _recordNotesPerTime.SetNotesPerTime("L_I",_soundOptions["L_I"],L_pitch,L_tremolo,AudioInstrument);
        }
      
    }

    public void Stop_LI()
    {
        ResetHandVelocity();
    }
    public void Left_Middle()
    {
        
        if (_playInstrument)
        {
            ResetHandVelocity();
            _leftFingers[1].setParameterByID(_noteLeft[1].id, _soundOptions["L_M"]);
            _leftFingers[1].setParameterByID(_radiusLeft[1].id, _radiusSound);
            _leftFingers[1].setParameterByID(_instrumentLeft[1].id, AudioInstrument);
            _leftFingers[1].start();
            _recordNotesPerTime.SetNotesPerTime("L_M",_soundOptions["L_M"],L_pitch,L_tremolo,AudioInstrument);
        }
        
    }

    public void Stop_LM()
    {
        ResetHandVelocity();
    }
    public void Left_Ring()
    {
        
        if (_playInstrument)
        {
            ResetHandVelocity();
            _leftFingers[2].setParameterByID(_noteLeft[2].id, _soundOptions["L_R"]);
            _leftFingers[2].setParameterByID(_radiusLeft[2].id, _radiusSound);
            _leftFingers[2].setParameterByID(_instrumentLeft[2].id, AudioInstrument);
            _leftFingers[2].start();
            _recordNotesPerTime.SetNotesPerTime("L_R",_soundOptions["L_R"],L_pitch,L_tremolo,AudioInstrument);
        }
        
    }

    public void Stop_LR()
    {
        ResetHandVelocity();
    }
    public void Left_Little()
    {
        
        if (_playInstrument)
        {
            ResetHandVelocity();
            _leftFingers[3].setParameterByID(_noteLeft[3].id, _soundOptions["L_L"]);
            _leftFingers[3].setParameterByID(_radiusLeft[3].id, _radiusSound);
            _leftFingers[3].setParameterByID(_instrumentLeft[3].id, AudioInstrument);
            _leftFingers[3].start();
            _recordNotesPerTime.SetNotesPerTime("L_L",_soundOptions["L_L"],L_pitch,L_tremolo,AudioInstrument);
        }
        
    }

    public void Stop_LL()
    {
        ResetHandVelocity();
    }
    public void Left_Thumb ()
    {
        
        if (_playInstrument)
        {
            ResetHandVelocity();
            _leftFingers[4].setParameterByID(_noteLeft[4].id, _soundOptions["L_T"]);
            _leftFingers[4].setParameterByID(_radiusLeft[4].id, _radiusSound);
            _leftFingers[4].setParameterByID(_instrumentLeft[4].id, AudioInstrument);
            _leftFingers[4].start();
            _recordNotesPerTime.SetNotesPerTime("L_T",_soundOptions["L_T"],L_pitch,L_tremolo,AudioInstrument);
        }
       
    }

    public void Stop_LT()
    {
        ResetHandVelocity();
    }
    
    public void DrumsSound()
    {
        if (_playInstrument)
        {
            _drums.setParameterByID(_radiusDrums.id,_radiusSound);
            _drums.start();
            _recordNotesPerTime.SetNotesPerTime("Drums",_typeOfInstrument:0);
        }
        
    }

    public void StopDrums()
    {
        ResetHandVelocity();
    }

    public void ClapsSound(int claps)
    {
        if (_playInstrument)
        {
           
            if (_playInstrument)
            {
                _clap.setParameterByID(_typeSoundClap.id, claps);
                _clap.setParameterByID(_radiusClap.id, _radiusSound);
                _clap.start();
                _recordNotesPerTime.SetNotesPerTime("Clap",_typeOfInstrument:claps);
            }
           
        }
    }
    public void StopClaps()
    {
        ResetHandVelocity();
    }
    
    public void SnareDrumSound(int snareType)
    {
        
        if (_playInstrument)
        {
            _snare.setParameterByID(_typeSoundSnare.id, snareType);
            _snare.setParameterByID(_radiusSnare.id, _radiusSound);
            _snare.start();
            _recordNotesPerTime.SetNotesPerTime("Snare",_typeOfInstrument:snareType);
        }
    }
    public void StopSnareDrum()
    {
        ResetHandVelocity();
    }
    
}
