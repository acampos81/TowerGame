using UnityEngine;

public class PlacementUI : MonoBehaviour
{
  public Transform markerTransform;
  public MeshRenderer markerRenderer;
  public Material greenMaterial;
  public Material redMaterial;
  public LayerMask raycastMask;

  private Camera _camera;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _camera = Camera.main;
  }

  // Update is called once per frame
  void Update()
  {
    var mousePosition = Input.mousePosition;
    mousePosition.z = _camera.farClipPlane;
    var worldPoint = _camera.ScreenToWorldPoint(mousePosition);
    var direction = (worldPoint - _camera.transform.position).normalized;

    if(Physics.Raycast(_camera.transform.position, direction, out RaycastHit hitInfo, _camera.farClipPlane, raycastMask, QueryTriggerInteraction.Collide))
    {
      if(hitInfo.collider.tag == "MeleePlacement" || hitInfo.collider.tag == "RangedPlacement")
      {
        markerRenderer.material = greenMaterial;
      }
      else
      {
        markerRenderer.material = redMaterial;
      }

      markerTransform.position = hitInfo.point;
    }

    Debug.DrawLine(_camera.transform.position, worldPoint, Color.green);
  }
}
