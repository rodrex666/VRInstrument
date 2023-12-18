using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordNotesPerTime : MonoBehaviour
{
    /// <summary>
    /// This gonna have the notes recorded per time, it will be two functions, one to initialize the recording and the other to stop it
    /// when the player press the button to record, a timer begins to count, when the player press the button to stop, the timer stops and the notes are saved
    /// A Struct will be used to save the notes, and a List of Structs to save the notes per time
    /// </summary>
 
   
    private float _time;
    private bool _isRecording = false;
    public struct _InstrumentsPTime
    {
        public float _time;
        public string _instrument;
        public int _note;
        public int _typeOfInstrument;
        public float _effectInY;
        public float _effectInX;
    }
    List<_InstrumentsPTime> _notesPerTimeList ;
    void Start()
    {
        _notesPerTimeList = new List<_InstrumentsPTime>();
    }

    public void StartRecording()
    {
        _notesPerTimeList.Clear();
        _isRecording = true;
        _time = 0;
        StartCoroutine(Record());
    }
    private IEnumerator Record()
    {
        while (_isRecording)
        {
            _time += Time.deltaTime;
            //Debug.Log("Time for the play of music"+_time);
            yield return null;
        }
    }
    public void StopRecording()
    {
        _isRecording = false;
    }
    public void SetNotesPerTime( String _instrument,int _note = 0, float _effectInY = 0, float _effectInX = 0,int _typeOfInstrument = 0)
    {
        if (_isRecording)
        {
            _notesPerTimeList.Add(new _InstrumentsPTime
            {
                _time = (float)Math.Round(_time, 3),
                _instrument = _instrument,
                _typeOfInstrument = _typeOfInstrument,
                _note = _note,
                _effectInY = _effectInY,
                _effectInX = _effectInX
            });
        }
        
    }
    public void SetListNotesPerTime(List<_InstrumentsPTime> _notesPerTimeList) // Test purpose and tutorial
    {
        this._notesPerTimeList = _notesPerTimeList;
    }
   
    public void SetTime(float _time) // Test purpose
    {
        this._time = _time;
    }
    public void SetRecording(bool _isRecording) // Test purpose
    {
        this._isRecording = _isRecording;
    }
 
    public List<_InstrumentsPTime> GetNotesPerTimeList()
    {
        return _notesPerTimeList;
    }
    public float GetTime()
    {
        return _time;
    }
}
