using UnityEngine;

public class AnimationEventListener : MonoBehaviour
{
  public EnemyLogic enemyLogic;

  public void OnAttackEvent()
  {
    enemyLogic.PerformAttack();
  }
}
