using UnityEngine;
using UnityEngine.Events;

public class HittableObject : MonoBehaviour
{
  public int maxHitPoints;

  private int _currentHitPoints;

  public UnityEvent OnHitPointsZero;

  private void Start()
  {
    _currentHitPoints = maxHitPoints;
  }

  public void TakeDamage(int damage)
  {
    _currentHitPoints -= damage;
    if(_currentHitPoints <= 0)
    {
      OnHitPointsZero.Invoke();
    }
  }
}
