using UnityEngine;

public class Spear : MonoBehaviour
{
  public Rigidbody rigidBody;

  private float _removalTime;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _removalTime = 3f;
  }

  // Update is called once per frame
  void Update()
  {
    if(_removalTime > 0f)
    {
      _removalTime -= Time.deltaTime;
      if(_removalTime < 0f)
      {
        GameObject.Destroy(this.gameObject);
      }
    }
  }

  public void Throw()
  {
    rigidBody.AddForce(transform.forward * 50f, ForceMode.Impulse);
  }
}
