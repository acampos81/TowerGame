using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PropGenerator : MonoBehaviour
{
  public int objectCount;
  public List<GameObject> props;
  public Transform propParent;

  public void GenerateProps()
  {
    var sphereCollider = gameObject.GetComponent<SphereCollider>();
    var radius = gameObject.transform.localScale.x * sphereCollider.radius;
    var center = gameObject.transform.position;


    for(int i=0; i<objectCount; i++)
    {
      var randomIndex = Random.Range(0, props.Count);
      var randomProp = props[randomIndex];
      var propInstance = GameObject.Instantiate(randomProp);


      var randomRotationAngle = Random.Range(0f, 360f);
      transform.rotation = Quaternion.Euler(new Vector3(0f, randomRotationAngle, 0f));

      var randomRadius = Random.Range(0f, radius);
      var propPosition = center + transform.forward * randomRadius;

      propInstance.transform.position = propPosition;
      propInstance.transform.SetParent(propParent);
    }
  }
}
