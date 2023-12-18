using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using FMOD.Studio;


public class PlayNotes : MonoBehaviour
{
    /// <summary>
    /// It takes the notes from the dictionary in RecordNotesPerTime and create the prefabs to play the song, also sends the list of notes to the prefabs
    /// </summary>
    
    [SerializeField] private RecordNotesPerTime _recordNotesPerTime;
    [SerializeField] private GameObject _objectPlayer;
   
    private List<RecordNotesPerTime._InstrumentsPTime> _temporalNotesPerTimeList = new List<RecordNotesPerTime._InstrumentsPTime>();
    private List<GameObject> _soundEmitters = new List<GameObject>();
    private float _counterObjects;
   

    public void PlaySavedSong()
    {
        _temporalNotesPerTimeList = _recordNotesPerTime.GetNotesPerTimeList();
        GameObject cloneObjectMusic = Instantiate(_objectPlayer,new Vector3(0.06f,1.135f,0.378f),Quaternion.identity);
        cloneObjectMusic.GetComponentInChildren<SoundBallEmitter>().SetListeNotesPerTime(_temporalNotesPerTimeList);
        _soundEmitters.Add(cloneObjectMusic);
        _counterObjects++;
    }

    
   
    public float GetCounterPrefabs()
    {
        return _counterObjects;
    }

    private void OnDisable()
    {
       DeleteSoundEmitters();
    }
    public void DeleteSoundEmitters()
    {
        foreach (var _soundEmitter in _soundEmitters)
        {
            Destroy(_soundEmitter);
        }
        _soundEmitters.Clear();
        _counterObjects = 0;
    }
}
