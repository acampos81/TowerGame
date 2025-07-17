using UnityEngine;

public class UIManager : MonoBehaviour
{
  public GameObject pauseMenu;
  public GameObject gameOver;
  public GameObject victoryScreen;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    pauseMenu.gameObject.SetActive(false);
    gameOver.gameObject.SetActive(false);
    victoryScreen.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.Escape))
    {
      if(pauseMenu.activeInHierarchy)
      {
        pauseMenu.gameObject.SetActive(false);
      }
      else
      {
        pauseMenu.gameObject.SetActive(true);
      }
    }
  }

  public void ShowGameOver(bool isVisible)
  {
    pauseMenu.gameObject.SetActive(false);
    gameOver.gameObject.SetActive(isVisible);
    victoryScreen.gameObject.SetActive(false);
  }

  public void ShowVictoryScreen(bool isVisible)
  {
    pauseMenu.gameObject.SetActive(false);
    gameOver.gameObject.SetActive(false);
    victoryScreen.gameObject.SetActive(isVisible);
  }
}
