using UnityEngine;
using UnityEngine.Events;

public class PlacementUI : MonoBehaviour
{
  public GoldManager goldManager;
  public Transform markerTransform;
  public MeshRenderer markerRenderer;
  public Material greenMaterial;
  public Material redMaterial;
  public LayerMask raycastMask;

  private Camera _camera;
  private int _unitType;
  private string _triggerTag;
  private GameObject _unitPrefab;
  private bool _placementValid;

  public UnityEvent OnUnitSpawned;
  public UnityEvent OnSpawnCancelled;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _camera = Camera.main;
  }

  public void SetUnitType(int unitType)
  {
    _unitType = unitType;

    switch(unitType)
    {
      case 0:
        _triggerTag = "MeleePlacement";
        _unitPrefab = Resources.Load("MeleeUnit") as GameObject;
        break;
      case 1:
        _triggerTag = "RangedPlacement";
        _unitPrefab = Resources.Load("RangedUnit") as GameObject;
        break;
    }
  }

  // Update is called once per frame
  void Update()
  {
    var mousePosition = Input.mousePosition;
    mousePosition.z = _camera.farClipPlane;
    var worldPoint = _camera.ScreenToWorldPoint(mousePosition);
    var direction = (worldPoint - _camera.transform.position).normalized;

    _placementValid = false;

    if(Physics.Raycast(_camera.transform.position, direction, out RaycastHit hitInfo, _camera.farClipPlane, raycastMask, QueryTriggerInteraction.Collide))
    {
      if(hitInfo.collider.tag == _triggerTag)
      {
        markerRenderer.material = greenMaterial;
        _placementValid = true;
      }
      else
      {
        markerRenderer.material = redMaterial;
      }

      markerTransform.position = hitInfo.point;
    }

    if(Input.GetMouseButtonDown(0) && _placementValid)
    {
      var unitInstance = GameObject.Instantiate(_unitPrefab);
      unitInstance.transform.position = markerTransform.position;
      OnUnitSpawned.Invoke();
      goldManager.UnitPurchased(_unitType);
    }

    if(Input.GetMouseButtonDown(1))
    {
      OnSpawnCancelled.Invoke();
    }

    Debug.DrawLine(_camera.transform.position, worldPoint, Color.green);
  }
}
