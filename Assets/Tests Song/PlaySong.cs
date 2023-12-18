using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlaySong
{
   
    [UnityTest]
     public IEnumerator TestLoadNotesPerTime_With_timer()
    {
        float time;
        time = 1.0f;
        var gameObject = new GameObject();
        var audioSource = gameObject.AddComponent<RecordNotesPerTime>();
        Dictionary<float, string> temporalNotesPerTime = new Dictionary<float, string>();
        Dictionary<float, string> temporalFinalNotesPerTime = new Dictionary<float, string>();
        List<RecordNotesPerTime._InstrumentsPTime> temporalNotesPerTimeList = new List<RecordNotesPerTime._InstrumentsPTime>();
        temporalNotesPerTime.Add(time, "Drum");
        temporalNotesPerTimeList.Add(new RecordNotesPerTime._InstrumentsPTime
        {
            _time = time,
            _instrument = "Drum",
            _note = 3,
            _effectInY = 0,
            _effectInX = 0
        });
        time = 4.0f;
        temporalNotesPerTime.Add(time, "Snare");
        temporalNotesPerTimeList.Add(new RecordNotesPerTime._InstrumentsPTime
        {
            _time = time,
            _instrument = "Snare",
            _note = 2,
            _effectInY = 0,
            _effectInX = 0
        });
        time = 9.0f;
        temporalNotesPerTime.Add(time, "R_M");
        temporalNotesPerTimeList.Add(new RecordNotesPerTime._InstrumentsPTime
        {
            _time = time,
            _instrument = "R_M",
            _note = 1,
            _effectInY = 0,
            _effectInX = 0
        });
        audioSource.StartRecording();
        yield return new WaitForSeconds(1);
        audioSource.SetNotesPerTime("Drum",3,0,0);
        yield return new WaitForSeconds(3);
        audioSource.SetNotesPerTime("Snare",2,0,0);
        yield return new WaitForSeconds(5);
        audioSource.SetNotesPerTime("R_M",1,0,0);
        yield return new WaitForSeconds(3);
        audioSource.StopRecording();
        
        var temporalNotesPerTimeList2 = audioSource.GetNotesPerTimeList();
        Assert.IsTrue(CompareInRange(temporalNotesPerTimeList2[0]._time, temporalNotesPerTimeList[0]._time, 0.5f));
        Assert.AreEqual(temporalNotesPerTimeList[0]._note, temporalNotesPerTimeList2[0]._note);
        Assert.AreEqual(temporalNotesPerTimeList[0]._instrument, temporalNotesPerTimeList2[0]._instrument);
        Assert.AreEqual(temporalNotesPerTimeList[0]._effectInY, temporalNotesPerTimeList2[0]._effectInY);
        Assert.AreEqual(temporalNotesPerTimeList[0]._effectInX, temporalNotesPerTimeList2[0]._effectInX);
        Assert.IsTrue(CompareInRange(temporalNotesPerTime.Keys.First(), temporalFinalNotesPerTime.Keys.First(), 0.5f));
        
        
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

}
