
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ButtonToDictionary : MonoBehaviour
{
    /// <summary>
    ///     This script is to set the value of the buttons to the dictionary of the sound instruments, every button's name
    ///     is the name of the key in the dictionary "L_T, R_I,R_T, etc" and the value is the note that is going to be played
    ///     0 for C, 1 for C#, 2 for D, 3 for D#, 4 for E, 5 for F, 6 for F#, 7 for G, 8 for G#, 9 for A, 10 for A#, 11 for B, 12 for C2
    ///     
    /// </summary>
    [SerializeField] List<GameObject> _buttonsNotes = new List<GameObject>();
    [SerializeField] SoundInstruments _dictionary;
    public void SetValueButtonsToDictionary()
    {
        foreach (var _button in _buttonsNotes)
        {
            switch (_button.GetComponentInChildren<TextMeshProUGUI>().text)
            {
                case "C":
                    _dictionary.SetSoundParameters(_button.name, 0);
                    break;
                case "C#":
                    _dictionary.SetSoundParameters(_button.name, 1);
                    break;
                case "D":
                    _dictionary.SetSoundParameters(_button.name, 2);
                    break;
                case "D#":
                    _dictionary.SetSoundParameters(_button.name, 3);
                    break;
                case "E":   
                    _dictionary.SetSoundParameters(_button.name, 4);
                    break;
                case "F":
                    _dictionary.SetSoundParameters(_button.name, 5);
                    break;
                case "F#":
                    _dictionary.SetSoundParameters(_button.name, 6);
                    break;
                case "G":
                    _dictionary.SetSoundParameters(_button.name, 7);
                    break;
                case "G#":
                    _dictionary.SetSoundParameters(_button.name, 8);
                    break;
                case "A":
                    _dictionary.SetSoundParameters(_button.name, 9);
                    break;
                case "A#":
                    _dictionary.SetSoundParameters(_button.name, 10);
                    break;
                case "B":
                    _dictionary.SetSoundParameters(_button.name, 11);
                    break;
                case "C2":
                    _dictionary.SetSoundParameters(_button.name, 12);
                    break;
                    
            }
           
        }
    }
}
