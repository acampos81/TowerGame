using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour
{
  public NavMeshAgent agent;

  public List<GameObject> _targets;

  void Start()
  {
    _targets = new List<GameObject>();
  }

  void Update()
  {

  }

  private void OnTriggerEnter(Collider other)
  {
    var targetTag = other.gameObject.tag;
    var targetLocation = other.transform.position;

    if(targetTag == "Tower")
    {

    }
    else if(targetTag == "PlayerUnit")
    {

    }

    
    agent.isStopped = true;
    agent.ResetPath();
    agent.SetDestination(targetLocation);
  }
}
