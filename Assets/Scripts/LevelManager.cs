using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
  public int enemy1Count;
  public int enemy2Count;

  [Tooltip("How often enemies will spawn in seconds.")]
  public float spawnInterval;
  
  public List<Transform> spawnPoints;


  private GameObject _enemy1Prefab;
  private GameObject _enemy2Prefab;
  private float _elapsedSpawnTime;
  private int _spawnIndex;
  private int _enemy1Spawned;
  private int _enemy2Spawned;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _enemy1Prefab = Resources.Load("Enemy1") as GameObject;
    _enemy2Prefab = Resources.Load("Enemy2") as GameObject;
  }

  // Update is called once per frame
  void Update()
  {
    if(_enemy1Spawned < enemy1Count)
    {
      var intervalElapsed = CheckSpawnInterval(Time.deltaTime, _enemy1Prefab);
      if(intervalElapsed)
      {
        _enemy1Spawned++;
      }
    }
    else if(_enemy2Spawned < enemy2Count)
    {
      var intervalElapsed = CheckSpawnInterval(Time.deltaTime, _enemy2Prefab);
      if (intervalElapsed)
      {
        _enemy2Spawned++;
      }
    }
  }

  public void RestartLevel()
  {
    var scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
  }

  private bool CheckSpawnInterval(float deltaTime, GameObject enemyPrefab)
  {
    _elapsedSpawnTime += deltaTime;
    if(_elapsedSpawnTime >= spawnInterval)
    {

      var spawnPoint = spawnPoints[_spawnIndex];

      SpawnEnemy(enemyPrefab, spawnPoint);

      _elapsedSpawnTime = 0.0f;

      _spawnIndex++;

      if(_spawnIndex == spawnPoints.Count)
      {
        _spawnIndex = 0;
      }

      return true;
    }

    return false;
  }

  private void SpawnEnemy(GameObject enemyPrefab, Transform spawnPoint)
  {
    var enemyInstance = GameObject.Instantiate(enemyPrefab);
    enemyInstance.transform.position = spawnPoint.position;
      
    var agentLocation = spawnPoint.position;
    agentLocation.x = 30f;
      
    var agent = enemyInstance.GetComponent<NavMeshAgent>();
    agent.SetDestination(agentLocation);
  }
}
