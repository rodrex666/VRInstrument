using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
   public void QuitGame()
   {
      Application.Quit();
   }
   //Convert a float to a time string
   //function takes a float and writes it in a string in the format of minutes:seconds:milliseconds
   public string FloatToTimeString(float _time)
   {
      int _minutes = (int) _time / 60;
      int _seconds = (int) _time % 60;
      int _milliseconds = (int) (_time * 1000) % 1000;
      return string.Format("{0:00}:{1:00}:{2:000}", _minutes, _seconds, _milliseconds);
   }

 
}
