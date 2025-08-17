using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  public HittableObject hittableObject;
  public Slider slider;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    transform.rotation = Quaternion.identity;
    slider.value = hittableObject.GetHitPointsPercentage();
  }
}
