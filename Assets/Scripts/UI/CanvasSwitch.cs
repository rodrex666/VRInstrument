using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    /// <summary>
    /// Here we have the canvas that we want to switch between
    /// Canvas with the sounds and notes to play - canvas 1
    /// Canvas with the metronom - canvas 2
    /// Canvas with the recorder and the play button - canvas 3
    /// Canvas with the information about Notes and Scales - canvas 4
    /// </summary>
    [SerializeField] private GameObject _canvas1;
    [SerializeField] private GameObject _canvas2;
    [SerializeField] private GameObject _canvas3;
    [SerializeField] private GameObject _canvas4;
    bool _isCanvasInfo = false;
    bool _isCanvasMetro = false;
    bool _isCanvasRecord = false;
    private bool _isCanvasStart = false;
  
  

    private void Start()
    {
        _canvas1.SetActive(true);
        _canvas2.SetActive(false);
        _canvas3.SetActive(false);
        _canvas4.SetActive(false);
    }

    public void StartCanvas()
    {
        _isCanvasStart = !_isCanvasStart;
        if (_isCanvasStart)
        {
            _canvas1.SetActive(true);
            _canvas2.SetActive(false);
            _canvas3.SetActive(false);
        }
    }
    public void disableEnableCanvasRecorder()
    {
        _isCanvasRecord = !_isCanvasRecord;
        if (_isCanvasRecord)
        {
            _canvas1.SetActive(false);
            _canvas2.SetActive(true);
            _canvas3.SetActive(false);
        }
        else
        {
            _canvas1.SetActive(true);
            _canvas2.SetActive(false);
            _canvas3.SetActive(false);
        }
        
    }
    public void disableEnableCanvasMetronom()
    {
        _isCanvasMetro = !_isCanvasMetro;
        if (_isCanvasMetro)
        {
            _canvas1.SetActive(false);
            _canvas2.SetActive(false);
            _canvas3.SetActive(true);
        }
        else
        {
            _canvas1.SetActive(true);
            _canvas2.SetActive(false);
            _canvas3.SetActive(false);
        }
    }

    public void disableEnableCanvasInformation()
    {
        _isCanvasInfo = !_isCanvasInfo;
        if (_isCanvasInfo)
        {
            _canvas4.SetActive(true);
        }
        else
        {
            _canvas4.SetActive(false);
        }
    }
}
