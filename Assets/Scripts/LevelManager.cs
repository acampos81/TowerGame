using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  public int enemy1Count;
  public int enemy2Count;
  public Transform spawnPoint1;
  public Transform spawnPoint2;
  public Transform spawnPoint3;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    var enemy1 = Resources.Load("Enemy1") as GameObject;

    SpawnEnemies(enemy1Count, enemy1, spawnPoint1);
    SpawnEnemies(enemy1Count, enemy1, spawnPoint2);
    SpawnEnemies(enemy1Count, enemy1, spawnPoint3);
  }

  // Update is called once per frame
  void Update()
  {
  }

  public void RestartLevel()
  {
    var scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
  }

  private void SpawnEnemies(int count, GameObject enemyPrefab, Transform spawnPoint)
  {
    for(int i=0; i < count; i++)
    {
      var enemyInstance = GameObject.Instantiate(enemyPrefab);
      enemyInstance.transform.position = spawnPoint.position;
    }
  }
}
