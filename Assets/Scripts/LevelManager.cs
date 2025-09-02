using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  public int levelNumber;
  public UIManager uiManager;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
  }

  public void RestartLevel()
  {
    var scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
  }

  public void TowerDestroyed()
  {
    uiManager.UpdateUIState("GameOver");
  }

  public void AllEnemiesDestroyed()
  {
    uiManager.UpdateUIState("Victory");

    switch(levelNumber)
    {
      case 1:
        PlayerPrefs.SetInt(Constants.LEVEL_1_KEY, 1);
        break;
      case 2:
        PlayerPrefs.SetInt(Constants.LEVEL_2_KEY, 1);
        break;
    }
  }
}
