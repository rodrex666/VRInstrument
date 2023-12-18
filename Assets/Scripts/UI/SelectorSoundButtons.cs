using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorSoundButtons : MonoBehaviour
{
   [SerializeField] private GameObject _buttonSound1;
   [SerializeField] private GameObject _buttonSound2;
   [SerializeField] private GameObject _buttonSound3;
   [SerializeField] private GameObject _buttonSound4;
   [SerializeField] private GameObject _buttonSound5;
   [SerializeField] private GameObject _buttonSound6;

   public void CheckButtons()
   {
      if (_buttonSound1.GetComponent<ChangeColorButtons>().GetIsChangeName() == false)
      {
         _buttonSound2.GetComponent<Button>().interactable = false;
         _buttonSound3.GetComponent<Button>().interactable = false;
         _buttonSound4.GetComponent<Button>().interactable = false;
         _buttonSound5.GetComponent<Button>().interactable = false;
         _buttonSound6.GetComponent<Button>().interactable = false;
      }
      else if(_buttonSound2.GetComponent<ChangeColorButtons>().GetIsChangeName() == false)
      {
         _buttonSound1.GetComponent<Button>().interactable = false;
         _buttonSound3.GetComponent<Button>().interactable = false;
         _buttonSound4.GetComponent<Button>().interactable = false;
         _buttonSound5.GetComponent<Button>().interactable = false;
         _buttonSound6.GetComponent<Button>().interactable = false;
      }
      else if (_buttonSound3.GetComponent<ChangeColorButtons>().GetIsChangeName() == false)
      {
         _buttonSound1.GetComponent<Button>().interactable = false;
         _buttonSound2.GetComponent<Button>().interactable = false;
         _buttonSound4.GetComponent<Button>().interactable = false;
         _buttonSound5.GetComponent<Button>().interactable = false;
         _buttonSound6.GetComponent<Button>().interactable = false;
      }
      else if (_buttonSound4.GetComponent<ChangeColorButtons>().GetIsChangeName() == false)
      {
         _buttonSound1.GetComponent<Button>().interactable = false;
         _buttonSound2.GetComponent<Button>().interactable = false;
         _buttonSound3.GetComponent<Button>().interactable = false;
         _buttonSound5.GetComponent<Button>().interactable = false;
         _buttonSound6.GetComponent<Button>().interactable = false;
      }
      else if (_buttonSound5.GetComponent<ChangeColorButtons>().GetIsChangeName() == false)
      {
         _buttonSound1.GetComponent<Button>().interactable = false;
         _buttonSound2.GetComponent<Button>().interactable = false;
         _buttonSound3.GetComponent<Button>().interactable = false;
         _buttonSound4.GetComponent<Button>().interactable = false;
         _buttonSound6.GetComponent<Button>().interactable = false;
      }
      else if (_buttonSound6.GetComponent<ChangeColorButtons>().GetIsChangeName() == false)
      {
         _buttonSound1.GetComponent<Button>().interactable = false;
         _buttonSound2.GetComponent<Button>().interactable = false;
         _buttonSound3.GetComponent<Button>().interactable = false;
         _buttonSound4.GetComponent<Button>().interactable = false;
         _buttonSound5.GetComponent<Button>().interactable = false;
      }
      else
      {
         _buttonSound1.GetComponent<Button>().interactable = true;
         _buttonSound2.GetComponent<Button>().interactable = true;
         _buttonSound3.GetComponent<Button>().interactable = true;
         _buttonSound4.GetComponent<Button>().interactable = true;
         _buttonSound5.GetComponent<Button>().interactable = true;
         _buttonSound6.GetComponent<Button>().interactable = true;
      }
   }
}
