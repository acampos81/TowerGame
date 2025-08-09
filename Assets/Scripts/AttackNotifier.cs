using UnityEngine;

public class AttackNotifier : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Enemy")
    {
      var enemyLogic = other.gameObject.GetComponent<EnemyLogic>();
      enemyLogic.BeginAttack();
    }
  }
}
