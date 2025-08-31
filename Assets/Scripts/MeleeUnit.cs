using UnityEngine;
using UnityEngine.AI;

public class MeleeUnit : PlayerUnit
{
  public NavMeshAgent agent;
  public Animator animator;
  public float targetDistance;
  public int damageAmount;

  private float _destinationCheckInterval;

  // Update is called once per frame
  void Update()
  {
    if (_target != null)
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
      animator.SetBool("Attack", false);
      TryNextTarget();
    }
  }

  private void CheckTargetDestination()
  {
    _destinationCheckInterval += Time.deltaTime;
    if (_destinationCheckInterval > 0.25f)
    {
      _destinationCheckInterval = 0f;

      if (_target != null)
      {
        var destination = agent.destination;
        var targetPosition = _target.transform.position;
        var destinationDistance = Vector3.Distance(destination, targetPosition);
        var agentDistance = Vector3.Distance(agent.transform.position, targetPosition);

        if (destinationDistance > targetDistance)
        {
          agent.SetDestination(targetPosition);
        }
        else if (agentDistance <= targetDistance)
        {
          animator.SetBool("Attack", true);
        }
      }
    }
  }

  public void PerformAttack()
  {
    if (_target != null)
    {
      _target.TakeDamage(damageAmount);
    }
  }
}
