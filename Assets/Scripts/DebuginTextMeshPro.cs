using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DebuginTextMeshPro : MonoBehaviour
{
    public TextMeshPro textDebugContainer;
    public TextMeshProUGUI textDebug;

    private void Start()
    {
        textDebug = GetComponent<TextMeshProUGUI>();
    }

    public void tryFirstNote()
    {
        //textDebugContainer.text = "Do ";
        textDebug.text = "C";
    }
    public void trySecondNote()
    {
        textDebugContainer.text = "Re ";
    }
    public void tryThirdNote()
    {
        textDebugContainer.text = "Mi ";
    }
    public void tryFourthNote()
    {
        textDebugContainer.text = "Fa ";
    }
    public void tryFithNote()
    {
        textDebugContainer.text = "Sol ";
    }
    public void tryDrumRock()
    {
        textDebugContainer.text = "punio ";
    }
    public void tryDrumPalm()
    {
        textDebugContainer.text = "palma ";
    }
    public void clean()
    {
        textDebugContainer.text = " ";
    }
}
