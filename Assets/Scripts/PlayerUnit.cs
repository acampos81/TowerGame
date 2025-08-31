using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
  protected HittableObject _target;
  protected List<HittableObject> _targetList;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _targetList = new List<HittableObject>();
  }

  protected void TryNextTarget()
  {
    if (_targetList.Count > 0)
    {
      var hittableObject = _targetList[0];
      _targetList.Remove(hittableObject);

      if (hittableObject != null && hittableObject.GetHitPointsPercentage() > 0f)
      {
        _target = hittableObject;
      }
    }
  }

  protected void CheckTargetHitPoints()
  {
    if (_target.GetHitPointsPercentage() <= 0f)
    {
      _target = null;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      if (_target == null)
      {
        _target = other.gameObject.GetComponent<HittableObject>();
      }
      else
      {
        _targetList.Add(other.gameObject.GetComponent<HittableObject>());
      }
    }
  }
}
