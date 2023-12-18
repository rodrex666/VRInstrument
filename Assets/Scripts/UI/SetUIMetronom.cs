using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetUIMetronom : MonoBehaviour
{
    /*
     * Enable and disable Objects / buttons for Metronom
     * This is just for the UI
     */
    [SerializeField] private Slider _slider;

    [SerializeField] private Metronom _metronom;
    [SerializeField] private Button _start;
    [SerializeField] private Button _stop;
    [SerializeField] private Button _sound1;
    [SerializeField] private Button _sound2;
    [SerializeField] private Button _sound3;

    [SerializeField] private TextMeshProUGUI _optionSlider;

    private void OnEnable()
    {
        _stop.interactable = false;
    }

    //update the value of the slider in the Metronom and the UI Text
    void Update()
    {
        _metronom.SetValueTempo(Mathf.RoundToInt(_slider.value)); //Send to Metronom that value
        switch (_slider.value)//just send to UI Text
        {
            case 1: _optionSlider.text = "120 4/4";
                break;
            case 2: _optionSlider.text = "90 4/4";
                break;
            case 3: _optionSlider.text = "60 4/4";
                break;
            case 4: _optionSlider.text = "120 3/2";
                break;
            case 5: _optionSlider.text = "90 3/2";
                break;
            case 6:_optionSlider.text = "60 3/2";
                break;
            default: Debug.LogError("Error in Slider"); break;
        }
    }

    public void MetronomON()
    {
        _slider.interactable = false;
        _start.interactable = false;
        _sound1.interactable = false;
        _sound2.interactable = false;
        _sound3.interactable = false;
        _stop.interactable = true;
        _metronom.StartMetronom();
    }
    public void MetronomOFF()
    {
        _slider.interactable = true;
        _start.interactable = true;
        _sound1.interactable = true;
        _sound2.interactable = true;
        _sound3.interactable = true;
        _stop.interactable = false;
        _metronom.StopMetronom();
    }
}
