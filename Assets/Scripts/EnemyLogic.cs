using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour
{
  public NavMeshAgent agent;
  public Animator animator;

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
}
