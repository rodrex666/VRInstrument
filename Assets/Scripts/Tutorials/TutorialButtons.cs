using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtons : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tutorials1;
    [SerializeField] private List<GameObject> _tutorials2;

    private void OnEnable()
    {
        foreach (var tutorial in _tutorials1)
        {
            tutorial.SetActive(true);
        }
        foreach (var tutorial in _tutorials2)
        {
            tutorial.SetActive(false);
        }
    }

    public void ChangeTutorial()
    {
        foreach (var tutorial in _tutorials1)
        {
            tutorial.SetActive(false);
        }
        foreach (var tutorial in _tutorials2)
        {
            tutorial.SetActive(true);
        }
    }
}
