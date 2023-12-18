using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using FMOD.Studio;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class SoundBallEmitter : MonoBehaviour
{
    /// <summary>
    /// It takes the list of notes that are recorded and play them,it creates Sound Instances and Parameters in the Object to play the sound
    /// ,it also has a function to repeat the song a number of times
    /// </summary>
    private List<RecordNotesPerTime._InstrumentsPTime> _temporalNotesPerTimeList = new List<RecordNotesPerTime._InstrumentsPTime>();
    private List<RecordNotesPerTime._InstrumentsPTime> _backupTemporalNotesPerTimeList = new List<RecordNotesPerTime._InstrumentsPTime>();

    private EventInstance _drums;
    private EventInstance _snare;
    private EventInstance _clap;
    private EventInstance _music;
    //Parameters from Notes
    private PARAMETER_DESCRIPTION _pitch;
    private PARAMETER_DESCRIPTION _tremolo ;
    private PARAMETER_DESCRIPTION _note ;
    private PARAMETER_DESCRIPTION _instrument;

    private PARAMETER_DESCRIPTION _typeSoundClap; // 0 = clap, 1 = cymbal, 2 = cymbal 2, 3 = Cymbal 3
    private PARAMETER_DESCRIPTION _typeSoundSnare; // 0 = Tomtom, 1 = snare 

    private PARAMETER_DESCRIPTION _radiusMusic;
    private PARAMETER_DESCRIPTION _radiusDrums;
    private PARAMETER_DESCRIPTION _radiusSnare;
    private PARAMETER_DESCRIPTION _radiusClap;
    
    private float _time;
    bool _isPlaying ;
    [FormerlySerializedAs("RepeatSong")] public int repeatSong = 10;
    //Variable to control the radius of the sound
    private float _radiusSound = 0.2f;
    private void OnEnable()
    {
        _drums = AudioManager.Instance.CreateInstance(FMODEvents.Instance.DrumBass);
        _snare = AudioManager.Instance.CreateInstance(FMODEvents.Instance.SnareDrum);
        _clap = AudioManager.Instance.CreateInstance(FMODEvents.Instance.Clap);
        _music = AudioManager.Instance.CreateInstance(FMODEvents.Instance.RIndex);
        /*FMODUnity.RuntimeManager.AttachInstanceToGameObject(_drums,transform,GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(_snare,transform,GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(_clap,transform,GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(_music,transform,GetComponent<Rigidbody>());*/
        
        /*//AudioManager.Instance.AttachInstancetoObject(_music, gameObject);
        AudioManager.Instance.AttachInstancetoObject(_drums, gameObject);
        AudioManager.Instance.AttachInstancetoObject(_clap, gameObject);
        AudioManager.Instance.AttachInstancetoObject(_snare, gameObject);*/
        _pitch = AudioManager.Instance.GetIDofParameter(_music, "Pitch");
        _tremolo = AudioManager.Instance.GetIDofParameter(_music, "Tremolo");
        _note = AudioManager.Instance.GetIDofParameter(_music, "Note");
        _instrument = AudioManager.Instance.GetIDofParameter(_music, "Instrument");
        _typeSoundClap = AudioManager.Instance.GetIDofParameter(_clap, "Note");
        _typeSoundSnare = AudioManager.Instance.GetIDofParameter(_snare, "Note");
        _radiusClap = AudioManager.Instance.GetIDofParameter(_clap, "Radius");
        _radiusDrums = AudioManager.Instance.GetIDofParameter(_drums, "Radius");
        _radiusSnare = AudioManager.Instance.GetIDofParameter(_snare, "Radius");
        _radiusMusic = AudioManager.Instance.GetIDofParameter(_music, "Radius");
    }

    private void Start()
    {
        StartCoroutine(PlayMusicRecorded());
    }

    private void Update()
    {
        _music.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        _drums.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        _snare.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        _clap.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    public void SetListeNotesPerTime(List<RecordNotesPerTime._InstrumentsPTime> _notesPerTimeList)
    {
       _backupTemporalNotesPerTimeList = _notesPerTimeList.ToList();
    }
   private IEnumerator PlayMusicRecorded()
    {
        for (int  i = 0;  i < repeatSong && _isPlaying == false;  i++)
        {
            _temporalNotesPerTimeList = _backupTemporalNotesPerTimeList.ToList();
            yield return new WaitForSecondsRealtime(1);
            _time = 0;
            /*Debug.Log("list temporal back "+_backupTemporalNotesPerTimeList.Count);*/
            _isPlaying = true;
            
            yield return StartCoroutine(Play());
            
            /*Debug.Log("Timer "+_time);*/
        }
    }
    private IEnumerator Play()
    {
        while (_temporalNotesPerTimeList.Count > 0)
        {
            _time += (float) Math.Round(Time.deltaTime, 3);
            
            if (CompareInRange(_temporalNotesPerTimeList.First()._time,_time,0.1f))
            {
                switch (_temporalNotesPerTimeList.First()._instrument)
                {
                    case "Drums":
                        _drums.setParameterByID(_radiusDrums.id,_radiusSound);
                       _drums.start();
                        break;
                    case "Snare":
                        _snare.setParameterByID(_radiusSnare.id,_radiusSound);
                        _snare.setParameterByID(_typeSoundSnare.id,_temporalNotesPerTimeList.First()._typeOfInstrument);
                        _snare.start();
                        break;
                    case "Clap":
                        _clap.setParameterByID(_radiusClap.id,_radiusSound);
                        _clap.setParameterByID(_typeSoundClap.id,_temporalNotesPerTimeList.First()._typeOfInstrument);
                        _clap.start();
                        break;
                    default:
                        _music.setParameterByID(_radiusMusic.id,_radiusSound);
                        _music.setParameterByID(_instrument.id,_temporalNotesPerTimeList.First()._typeOfInstrument);
                        _music.setParameterByID(_note.id,_temporalNotesPerTimeList.First()._note);
                        _music.setParameterByID(_tremolo.id,_temporalNotesPerTimeList.First()._effectInY);
                        _music.setParameterByID(_pitch.id,_temporalNotesPerTimeList.First()._effectInX);
                        _music.start();
                        break;
                }
                _temporalNotesPerTimeList.RemoveAt(0);
            }
            yield return null;
        }
        _isPlaying = false;
    }

    
    bool CompareInRange(float a, float b, float tolerance)
    {
        if(Mathf.Abs(a - b) < tolerance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public float GetTime()
    {
        return _time;
    }

    private void OnDestroy()
    {
        _temporalNotesPerTimeList.Clear();
        _backupTemporalNotesPerTimeList.Clear();
    }
}
