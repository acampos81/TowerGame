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
    // GameOver
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      uiManager.ShowGameOver(true);
    }

    // Victory
    if(Input.GetKeyDown(KeyCode.Alpha2))
    {
      uiManager.ShowVictoryScreen(true);
    }

    if(Input.GetKeyDown(KeyCode.Alpha3))
    {
      PlayerPrefs.SetInt(Constants.LEVEL_1_KEY, 1);
    }

    if(Input.GetKeyDown(KeyCode.Alpha4))
    {
      PlayerPrefs.DeleteKey(Constants.LEVEL_1_KEY);
    }
  }
}
