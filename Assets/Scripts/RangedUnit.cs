using System.Collections.Generic;
using UnityEngine;

public class RangedUnit : MonoBehaviour
{
  public GameObject spearPrefab;
  public Transform spearPoint;
  public Animator animator;

  private HittableObject _target;
  private List<HittableObject> _targetList;
  private Vector3 _aimDirection;
  private float _throwInterval;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _targetList = new List<HittableObject>();
  }

  // Update is called once per frame
  void Update()
  {
    if(_target != null)
    {
      // Does the target still have hit points?
      CheckTargetHitPoints();

      // Aim at current target
      CheckAimDirection();

      // Check spear throw time
      CheckThrowInterval();
    }
    else
    {
      TryNextTarget();
    }
  }

  private void TryNextTarget()
  {
    if(_targetList.Count > 0)
    {
      var hittableObject = _targetList[0];
      _targetList.Remove(hittableObject);

      if(hittableObject != null && hittableObject.GetHitPointsPercentage() > 0f)
      {
        _target = hittableObject;
      }
    }
  }

  private void CheckTargetHitPoints()
  {
    if(_target.GetHitPointsPercentage() <= 0f)
    {
      _target = null;
    }
  }

  private void CheckThrowInterval()
  {
    _throwInterval += Time.deltaTime;
    if(_throwInterval > 1f)
    {
      _throwInterval = 0f;

      animator.Play("SpearThrow", 0, 0f);
    }
  }

  private void CheckAimDirection()
  {
    if(_target != null)
    {
      // what is the target direction?
      var bodyDirection = _target.transform.position - transform.position;
      // ensure there's no pitch in the look direction
      bodyDirection.y = 0f;

      // what is the aim direction?
      _aimDirection = _target.transform.position - spearPoint.position;
      _aimDirection += Vector3.up;

      // rotate the body in that direction
      transform.rotation = Quaternion.LookRotation(bodyDirection);
    }
  }

  public void LaunchSpear()
  {
    // create copy of spear
    var spearInstance = GameObject.Instantiate(spearPrefab);
    spearInstance.transform.position = spearPoint.position;
    spearInstance.transform.rotation = Quaternion.LookRotation(_aimDirection);

    // use physics to throw it at target
    var spear = spearInstance.GetComponent<Spear>();
    spear.Throw();

  }

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Enemy")
    {
      if(_target == null)
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