using UnityEngine;
using UnityEngine.AI;

public class MeleeUnit : MonoBehaviour
{
  public NavMeshAgent agent;
  public Animator animator;
  public float targetDistance;

  private HittableObject _target;
  private float _destinationCheckInterval;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

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
      CheckTargetDestination();


      // Play attack animation
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

  private void OnTriggerEnter(Collider other)
  {
    if(_target == null)
    {
      _target = other.gameObject.GetComponent<HittableObject>();
    }
  }
}
