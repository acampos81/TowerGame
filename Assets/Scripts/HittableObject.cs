using UnityEngine;

public class HittableObject : MonoBehaviour
{
  public int maxHitPoints;

  private int _currentHitPoints;

  private void Start()
  {
    _currentHitPoints = maxHitPoints;
  }

  public void TakeDamage(int damage)
  {
    _currentHitPoints -= damage;
    if(_currentHitPoints <= 0)
    {
      // respond to no more hit points.
    }
  }
}
