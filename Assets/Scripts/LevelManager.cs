using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  public int enemy1Count;
  public int enemy2Count;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    var enemy1 = Resources.Load("Enemy1") as GameObject;
    var enemy2 = Resources.Load("Enemy2") as GameObject;

    SpawnEnemies(enemy1Count, enemy1);
    SpawnEnemies(enemy2Count, enemy2);
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

  private void SpawnEnemies(int count, GameObject enemyPrefab)
  {
    for(int i=0; i < count; i++)
    {
      var enemyInstance = GameObject.Instantiate(enemyPrefab);
      var randomX = Random.Range(-20f, 20f);
      var randomZ = Random.Range(-20f, 20f);
      enemyInstance.transform.position = new Vector3(randomX, 0f, randomZ);
    }
  }
}
