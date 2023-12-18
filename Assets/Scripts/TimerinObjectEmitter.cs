   using System;
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   using TMPro;

   public class TimerinObjectEmitter : MonoBehaviour
   {
      
      [SerializeField] private TextMeshPro _text;
      [SerializeField] private SoundBallEmitter _soundBallEmitter;

      private void Update()
      {
         
         _text.text = _soundBallEmitter.GetTime().ToString("##:##.##");
      }
   }
