using UnityEngine;

public class UIManager : MonoBehaviour
{
  public GameObject pauseMenu;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    pauseMenu.gameObject.SetActive(false);
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
}
