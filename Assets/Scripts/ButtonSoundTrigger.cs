using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ButtonSoundTrigger : MonoBehaviour
{
   private StudioEventEmitter _emitter;

   private void Start()
   {
      _emitter = AudioManager.Instance.InitializeEventEmitter(FMODEvents.Instance.ButtonClick, this.gameObject);
   }

   public void TriggerSound()
   {
      _emitter.Play();
   }
   public void UntriggerSound()
   {
      _emitter.Stop();
   }
}
