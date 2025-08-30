using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeUnit : MonoBehaviour
{
  public NavMeshAgent agent;
  public Animator animator;
  public float targetDistance;
  public int damageAmount;

  private HittableObject _target;
  private List<HittableObject> _targetList;
  private float _destinationCheckInterval;

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

      // Is the target still at the destination?
      // Is the target at the right distance?
      // Play attack animation
      CheckTargetDestination();
    }
    else
    {
      TryNextTarget();
    }
  }

  private void TryNextTarget()
  {
    animator.SetBool("Attack", false);

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

  private void CheckTargetDestination()
  {
    _destinationCheckInterval += Time.deltaTime;
    if(_destinationCheckInterval > 0.25f)
    {
      _destinationCheckInterval = 0f;

      if(_target != null)
      {
        var destination = agent.destination;
        var targetPosition = _target.transform.position;
        var destinationDistance = Vector3.Distance(destination, targetPosition);
        var agentDistance = Vector3.Distance(agent.transform.position, targetPosition);

        if(destinationDistance > targetDistance)
        {
          agent.SetDestination(targetPosition);
        }
        else if(agentDistance <= targetDistance)
        {
          animator.SetBool("Attack", true);
        }
      }
    }
  }

  public void PerformAttack()
  {
    if(_target != null)
    {
      _target.TakeDamage(damageAmount);
    }
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
