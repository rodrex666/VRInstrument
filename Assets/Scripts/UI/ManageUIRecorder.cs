using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ManageUIRecorder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeRecording;    
    [SerializeField] private TextMeshProUGUI _timePlaying;
    [SerializeField] private Button _recordButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private PlayNotes _playNotes;
    [SerializeField] private RecordNotesPerTime _recorder;
    [SerializeField] private Util util;
    private void Start()
    {
        _recordButton.interactable = true;
        _stopButton.interactable = false;
        _playButton.interactable = false;
    }
    public void SetIntoStartRecording()
    {
        _stopButton.interactable = true;
        _recordButton.interactable = false;
    }
    public void SetIntoStop()
    {
        _recordButton.interactable = true;
        _stopButton.interactable = false;
        _playButton.interactable = true;
    }
    void Update()
    {
        _timePlaying.text = _playNotes.GetCounterPrefabs().ToString();
        _timeRecording.text = util.FloatToTimeString(_recorder.GetTime());
    }
}
