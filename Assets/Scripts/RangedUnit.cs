using UnityEngine;

public class RangedUnit : PlayerUnit
{
  public GameObject spearPrefab;
  public Transform spearPoint;
  public Animator animator;

  private Vector3 _aimDirection;
  private float _throwInterval;

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

  private void OnTriggerExit(Collider other)
  {
    if(other.gameObject.tag == "Enemy")
    {
      var hittableObject = other.gameObject.GetComponent<HittableObject>();
      if(_targetList.Contains(hittableObject))
      {
        _targetList.Remove(hittableObject);
      }
    }
  }
}