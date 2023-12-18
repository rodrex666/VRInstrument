using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;



public class SelectorToPlay : MonoBehaviour
{
/*
 * Enable and disable Objects / buttons
 * Change the text of the buttons in UI taking the value of the slider
 * 
 */


 List<TextMeshProUGUI> _textMeshes = new ();
List<ChangeNameButton> _buttonsUICheck = new();
 [SerializeField] private List<GameObject> _buttonsNotes; 
 [SerializeField] private Slider _slider; //Range 0-12
 [SerializeField] private TextMeshProUGUI _textDebug;
int _counter = 0;

 void SetTextMesh()
 {
  foreach (var _button in _buttonsNotes)
  { 
   _button.GetComponentInChildren<TextMeshProUGUI>().text = "C";
   _buttonsUICheck.Add(_button.GetComponent<ChangeNameButton>());
   _textMeshes.Add(_button.GetComponentInChildren<TextMeshProUGUI>());
  }
 }
 

 private void Start()
 {
  SetTextMesh();

  _slider.onValueChanged.AddListener((v) =>
   {
    //_textDebug.text = v.ToString("0000")+ "++"+_slider.value;
    UpdateSlider();
   });
 }
//update the value of the slider in the text property from the buttons
 public void UpdateSlider()
 {

  _counter = 0;
  switch (_slider.value)
  {
   
   case 0:
    _textDebug.text = "C";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "C";
     }
     _counter++; 
    }break;
   case 1:  
    _textDebug.text = "C#";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "C#";
     }
     _counter++; 
     
    }break;
   case 2: 
    _textDebug.text = "D";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "D";
     }
     _counter++; 
     
    }break;
   case 3:  
    _textDebug.text = "D#";
    foreach (var _text in _textMeshes)
    { 
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "D#";
     }
     _counter++; 
     
    }break;
   case 4:
    _textDebug.text = "E";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "E";
     }
     _counter++; 
     
    }break;
   case 5:
    _textDebug.text = "F";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "F";
     }
     _counter++; 
     
    }break;
   case 6:
    _textDebug.text = "F#";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "F#";
     }
     _counter++; 
  
    }break;
   case 7:
    _textDebug.text = "G";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "G";
     }
     _counter++; 
    
    }break;
   case 8:
    _textDebug.text = "G#";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "G#";
     }
     _counter++;
    }break;
   case 9:
    _textDebug.text = "A";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "A";
     }
     _counter++;
    }break;
   case 10:
    _textDebug.text = "A#";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "A#";
     }
     _counter++; 
    }break;
   case 11:
    _textDebug.text = "B";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "B";
     }
     _counter++; 
    }break;
   case 12:
    _textDebug.text = "C2";
    foreach (var _text in _textMeshes)
    {
     if (_buttonsUICheck[_counter].isChangeName == false)
     {
      _text.text = "C2";
     }
     _counter++;
    }break;
   default: 
    Debug.LogError("Error in Slider");
    break; 
    

  }
 }




}
