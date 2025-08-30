using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour
{
  public NavMeshAgent agent;
  public Animator animator;
  public Transform capsuleTransform;
  public LayerMask raycastMask;
  public int damageAmount;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void BeginAttack()
  {
    // play attack animation and subtract hit points from what is being hit

    agent.isStopped = true;
    agent.ResetPath();

    animator.SetBool("IsAttacking", true);
  }

  public void PerformAttack()
  {
    bool hitDetected = Physics.Raycast(capsuleTransform.position, capsuleTransform.forward, out RaycastHit hitInfo, 5f,  raycastMask, QueryTriggerInteraction.Ignore);
    if(hitDetected)
    {
      var towerHittableObject = hitInfo.collider.gameObject.GetComponent<HittableObject>();
      towerHittableObject.TakeDamage(damageAmount);
    }
  }

  public void HandleDeath()
  {
    animator.SetBool("IsDead", true);
  }

  public void RemoveFromLevel()
  {
    GameObject.Destroy(this.gameObject);
  }
}
