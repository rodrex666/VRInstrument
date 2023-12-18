using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNameButton : MonoBehaviour
{
    public bool isChangeName = true;
    [SerializeField] private TextMeshProUGUI _text;
   public void ChangeName()
   {
       
       isChangeName = !isChangeName;
       if (isChangeName== false)
       {
           gameObject.GetComponent<Button>().colors = new ColorBlock() { normalColor = Color.red, highlightedColor = Color.red, pressedColor = Color.red,selectedColor = Color.red, disabledColor = Color.red, colorMultiplier = 1 } ;
           gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _text.text ;
       }
       else
       {
           gameObject.GetComponent<Button>().colors = ColorBlock.defaultColorBlock;
       }
       
   }
}
