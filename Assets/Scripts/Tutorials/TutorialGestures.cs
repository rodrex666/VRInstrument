using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGestures : MonoBehaviour
{
    [SerializeField] private GameObject _buttonStart;
    [SerializeField] private GameObject _buttonPose1;
    [SerializeField] private GameObject _buttonPose2;
    [SerializeField] private GameObject _buttonPose3;

    [SerializeField] private List<GameObject> _object1;
    [SerializeField] private List<GameObject> _object2;
    [SerializeField] private List<GameObject> _object3;
    [SerializeField] private List<GameObject> _object4;
    public void CheckButtons ()
    {
        if (_buttonStart.GetComponent<ChangeColorButtons>().GetIsChangeName()==false)
        {
            foreach (var gameObject in _object1)
            {
                gameObject.SetActive(true);
            }
            foreach (var gameObject in _object2)
            {
                gameObject.SetActive(false);
            }
            foreach (var gameObject in _object3)
            {
                gameObject.SetActive(false);
            }

            foreach (var gameObject in _object4)
            {
                gameObject.SetActive(false);
            }
        }
        if (_buttonPose1.GetComponent<ChangeColorButtons>().GetIsChangeName() == false)
        {
            foreach (var gameObject in _object2)
            {
                gameObject.SetActive(true);
            }
            foreach (var gameObject in _object3)
            {
                gameObject.SetActive(false);
            }
            foreach (var gameObject in _object4)
            {
                gameObject.SetActive(false);
            }
            foreach (var gameObject in _object1)
            {
                gameObject.SetActive(false);
            }
            _buttonPose2.GetComponent<Button>().interactable = false;
            _buttonPose3.GetComponent<Button>().interactable = false;
        }
        else if (_buttonPose2.GetComponent<ChangeColorButtons>().GetIsChangeName() == false)
        {
            foreach (var gameObject in _object2)
            {
                gameObject.SetActive(false);
            }
            foreach (var gameObject in _object3)
            {
                gameObject.SetActive(true);
            }
            foreach (var gameObject in _object4)
            {
                gameObject.SetActive(false);
            }
            foreach (var gameObject in _object1)
            {
                gameObject.SetActive(false);
            }
            _buttonPose3.GetComponent<Button>().interactable = false;
            _buttonPose1.GetComponent<Button>().interactable = false;
        }
        else if (_buttonPose3.GetComponent<ChangeColorButtons>().GetIsChangeName() == false)
        {
            foreach (var gameObject in _object2)
            {
                gameObject.SetActive(false);
            }
            foreach (var gameObject in _object3)
            {
                gameObject.SetActive(false);
            }
            foreach (var gameObject in _object4)
            {
                gameObject.SetActive(true);
            }
            foreach (var gameObject in _object1)
            {
                gameObject.SetActive(false);
            }
            _buttonPose2.GetComponent<Button>().interactable = false;
            _buttonPose1.GetComponent<Button>().interactable = false;
        }
        else
        {
            _buttonPose1.GetComponent<Button>().interactable = true;
            _buttonPose2.GetComponent<Button>().interactable = true;
            _buttonPose3.GetComponent<Button>().interactable = true;
        }
    } 
}
