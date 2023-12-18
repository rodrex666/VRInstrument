using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionObjects : MonoBehaviour
{
   [SerializeField] private GameObject _camera;
   [SerializeField] private List<GameObject> _objects;

   private void OnEnable()
   {
      foreach (var objectToReset in _objects)
      {
         objectToReset.transform.position = _camera.transform.position;
      }
   }
}
