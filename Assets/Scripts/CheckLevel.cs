using UnityEngine;
using UnityEngine.UI;

public class CheckLevel : MonoBehaviour
{
  public Button level2Button;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    if(PlayerPrefs.HasKey(Constants.LEVEL_1_KEY))
    {
      level2Button.interactable = true;
    }
  }
}
