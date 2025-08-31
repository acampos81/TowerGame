using UnityEngine;

public class UIManager : MonoBehaviour
{
  public GameObject pauseMenu;
  public GameObject gameOver;
  public GameObject victoryScreen;
  public GameObject buyUnitsButton;
  public GameObject unitPanel;

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

  public void UpdateUIState(string uiState)
  {
    switch(uiState)
    {
      case "Default":
        ShowDefaultUI();
        break;
      case "UnitSelection":
        ShowUnitSelectionUI();
        break;
      case "UnitPlacement":
        ShowUnitPlacementUI();
        break;
      case "GameOver":
        ShowGameOverUI();
        break;
      case "Victory":
        ShowVictoryScreenUI();
        break;
    }
  }

  private void ShowDefaultUI()
  {
    pauseMenu.SetActive(false);
    gameOver.SetActive(false);
    victoryScreen.SetActive(false);
    buyUnitsButton.SetActive(true);
    unitPanel.SetActive(false);
  }

  private void ShowUnitSelectionUI()
  {
    pauseMenu.SetActive(false);
    gameOver.SetActive(false);
    victoryScreen.SetActive(false);
    buyUnitsButton.SetActive(false);
    unitPanel.SetActive(true);
  }

  private void ShowUnitPlacementUI()
  {
    pauseMenu.SetActive(false);
    gameOver.SetActive(false);
    victoryScreen.SetActive(false);
    buyUnitsButton.SetActive(false);
    unitPanel.SetActive(false);
  }

  private void ShowGameOverUI()
  {
    pauseMenu.SetActive(false);
    gameOver.SetActive(true);
    victoryScreen.SetActive(false);
    buyUnitsButton.SetActive(false);
    unitPanel.SetActive(false);
  }

  private void ShowVictoryScreenUI()
  {
    pauseMenu.SetActive(false);
    gameOver.SetActive(false);
    victoryScreen.SetActive(true);
    buyUnitsButton.SetActive(false);
    unitPanel.SetActive(false);
  }
}
