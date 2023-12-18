using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorButtons : MonoBehaviour
{
    private bool isChangeName = true;
    [SerializeField] private bool changeName;
    [SerializeField] private string _text;
    string _backupText;

    private void OnEnable()
    {
        _backupText = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void ChangeColor()
    {
        isChangeName = !isChangeName;
        if (isChangeName== false)
        {
            gameObject.GetComponent<Button>().colors = new ColorBlock() { normalColor = Color.red, highlightedColor = Color.red, pressedColor = Color.red,selectedColor = Color.red, disabledColor = Color.red, colorMultiplier = 1 } ;
            if (changeName)
            {
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _text ;
            }
        }
        else
        {
            gameObject.GetComponent<Button>().colors = ColorBlock.defaultColorBlock;
            if (changeName)
            {
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _backupText ;
            }
        }
    }
    public bool GetIsChangeName()
    {
        return isChangeName;
    }
}
