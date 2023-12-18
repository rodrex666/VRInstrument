using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHandPoses : MonoBehaviour
{
  [SerializeField] private GameObject _handPoseRight1;
  [SerializeField] private GameObject _handPoseLeft1;
  [SerializeField] private GameObject _handPoseRight2;
  [SerializeField] private GameObject _handPoseLeft2;
  [SerializeField] private GameObject _handPoseRight3;
  [SerializeField] private GameObject _handPoseLeft3;
 
  

  private void OnEnable()
  {
    _handPoseRight1.SetActive(true);
    _handPoseLeft1.SetActive(true);
    _handPoseRight2.SetActive(false);
    _handPoseLeft2.SetActive(false);
    _handPoseRight3.SetActive(false);
    _handPoseLeft3.SetActive(false);
  }

  public void ChangeHandPose(int _value)
  {
    switch (_value)
    {
      case 0:
        _handPoseRight1.SetActive(true);
        _handPoseLeft1.SetActive(true);
        _handPoseRight2.SetActive(false);
        _handPoseLeft2.SetActive(false);
        _handPoseRight3.SetActive(false);
        _handPoseLeft3.SetActive(false);
        break;
      case 1:
        _handPoseRight1.SetActive(false);
        _handPoseLeft1.SetActive(false);
        _handPoseRight2.SetActive(true);
        _handPoseLeft2.SetActive(true);
        _handPoseRight3.SetActive(false);
        _handPoseLeft3.SetActive(false);
        break;
      case 2:
        _handPoseRight1.SetActive(false);
        _handPoseLeft1.SetActive(false);
        _handPoseRight2.SetActive(false);
        _handPoseLeft2.SetActive(false);
        _handPoseRight3.SetActive(true);
        _handPoseLeft3.SetActive(true);
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(_value), _value, null);
    }
  }
}
