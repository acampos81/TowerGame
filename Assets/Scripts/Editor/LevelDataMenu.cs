using UnityEditor;
using UnityEngine;

public class LevelDataMenu : Editor
{
  [MenuItem("Level Data/Clear Saved Data")]
  public static void ClearAllLevelData()
  {
    PlayerPrefs.DeleteAll();
    Debug.Log("All Data Deleted");
  }

  [MenuItem("Level Data/Level 1 Cheat")]
  public static void Level1Cheat()
  {
    PlayerPrefs.SetInt(Constants.LEVEL_1_KEY, 1);
    Debug.Log("Level 1 Cheat Added");
  }
}
