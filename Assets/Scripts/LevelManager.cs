using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
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
    uiManager.ShowGameOver(true);
  }

  public void AllEnemiesDestroyed()
  {
    Debug.Log("Game Is Over, Player Won.");
  }
}
