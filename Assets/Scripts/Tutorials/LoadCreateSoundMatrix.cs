using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCreateSoundMatrix : MonoBehaviour
{
   [SerializeField] private RecordNotesPerTime _recordNotesPerTime;
   [SerializeField] private PlayNotes _playNotes;
   private bool _isPlaying = false;
   private List<RecordNotesPerTime._InstrumentsPTime> _temporalNotesPerTimeList = new List<RecordNotesPerTime._InstrumentsPTime>();
   private List<RecordNotesPerTime._InstrumentsPTime> _temporalNotesPerTimeList_2 = new List<RecordNotesPerTime._InstrumentsPTime>();

   private void Awake()
   {
       fullNotesPerTime();
   }

   public void fullNotesPerTime()
   {
       for (float i = 0; i < 61; i++)
       {
           if (i % 2 == 0)
           {
               _temporalNotesPerTimeList.Add(new RecordNotesPerTime._InstrumentsPTime
               {
                   _time = i,
                   _instrument = "Drums",
                   _typeOfInstrument = 0,
                   _note = 0,
                   _effectInY = 0f,
                   _effectInX = 0f
               });
           }
           else
           {
                _temporalNotesPerTimeList.Add(new RecordNotesPerTime._InstrumentsPTime
                {
                     _time = i,
                     _instrument = "Clap",
                     _typeOfInstrument = 0,
                     _note = 0,
                     _effectInY = 0f,
                     _effectInX = 0f
                });
           }
         
       }
       _temporalNotesPerTimeList_2.Add(new RecordNotesPerTime._InstrumentsPTime
       {
           _time = 3f,
           _instrument = "R_I",
           _typeOfInstrument = 0,
           _note = 5,
           _effectInY = 0f,
           _effectInX = 0f
       });
       _temporalNotesPerTimeList_2.Add(new RecordNotesPerTime._InstrumentsPTime
       {
           _time = 3.5f,
           _instrument = "R_I",
           _typeOfInstrument = 0,
           _note = 7,
           _effectInY = 0f,
           _effectInX = 0f
       });
       _temporalNotesPerTimeList_2.Add(new RecordNotesPerTime._InstrumentsPTime
       {
           _time = 4.5f,
           _instrument = "R_I",
           _typeOfInstrument = 0,
           _note = 11,
           _effectInY = 0f,
           _effectInX = 0f
       });
       _temporalNotesPerTimeList_2.Add(new RecordNotesPerTime._InstrumentsPTime
       {
           _time = 5.5f,
           _instrument = "R_I",
           _typeOfInstrument = 0,
           _note = 7,
           _effectInY = 0f,
           _effectInX = 0f
       });
      
       
       _temporalNotesPerTimeList_2.Add(new RecordNotesPerTime._InstrumentsPTime
       {
           _time = 8f,
           _instrument = "R_I",
           _typeOfInstrument = 0,
           _note = 5,
           _effectInY = 0f,
           _effectInX = 0f
       });
       _temporalNotesPerTimeList_2.Add(new RecordNotesPerTime._InstrumentsPTime
       {
           _time = 8.5f,
           _instrument = "R_I",
           _typeOfInstrument = 0,
           _note = 7,
           _effectInY = 0f,
           _effectInX = 0f
       });
       _temporalNotesPerTimeList_2.Add(new RecordNotesPerTime._InstrumentsPTime
       {
           _time = 9.5f,
           _instrument = "R_I",
           _typeOfInstrument = 0,
           _note = 11,
           _effectInY = 0f,
           _effectInX = 0f
       });
       _temporalNotesPerTimeList_2.Add(new RecordNotesPerTime._InstrumentsPTime
       {
           _time = 10.5f,
           _instrument = "R_I",
           _typeOfInstrument = 0,
           _note = 5,
           _effectInY = 0.5f,
           _effectInX = 0f
       });
           
   }
   public void SendMatrix()
   {
       //check the _isPlaying bool if this is true delete all the emitters and stop the song, if this is false 
       //create the emitters and play the song
       if (_isPlaying)
       {
           _playNotes.DeleteSoundEmitters();
       }
       else
       {
           _recordNotesPerTime.SetListNotesPerTime(_temporalNotesPerTimeList);
           _playNotes.PlaySavedSong();
           _recordNotesPerTime.SetListNotesPerTime(_temporalNotesPerTimeList_2);
           _playNotes.PlaySavedSong();
       }
       _isPlaying = !_isPlaying;
   }

   
}
