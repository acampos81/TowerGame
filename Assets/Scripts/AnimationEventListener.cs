using UnityEngine;
using UnityEngine.Events;

public class AnimationEventListener : MonoBehaviour
{
  public UnityEvent OnAttackRedispatch;
  public UnityEvent OnDeathCompleteRedispatch;

  public void OnAttackEvent()
  {
    OnAttackRedispatch.Invoke();
  }

  public void OnDeathCompleteEvent()
  {
    OnDeathCompleteRedispatch.Invoke();
  }
}
