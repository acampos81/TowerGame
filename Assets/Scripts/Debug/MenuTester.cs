using UnityEngine;

public class MenuTester : MonoBehaviour
{
  public UIManager uiManager;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      uiManager.UpdateUIState("Default");
    }

    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      uiManager.UpdateUIState("UnitSelection");
    }

    if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      uiManager.UpdateUIState("UnitPlacement");
    }

    // GameOver
    if (Input.GetKeyDown(KeyCode.Alpha4))
    {
      uiManager.UpdateUIState("GameOver");
    }

    // Victory
    if(Input.GetKeyDown(KeyCode.Alpha5))
    {
      uiManager.UpdateUIState("Victory");
    }


    /*
    if(Input.GetKeyDown(KeyCode.Alpha3))
    {
      PlayerPrefs.SetInt(Constants.LEVEL_1_KEY, 1);
    }

    if(Input.GetKeyDown(KeyCode.Alpha4))
    {
      PlayerPrefs.DeleteKey(Constants.LEVEL_1_KEY);
    }
    */
  }
}
