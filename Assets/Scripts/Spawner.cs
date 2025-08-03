using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
  public int enemyCount;
  public string prefabName;

  private GameObject _enemyPrefab;
  private int _spawnCount;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _enemyPrefab = Resources.Load(prefabName) as GameObject;
  }

  public void SpawnEnemy(Transform spawnPoint)
  {
    var enemyInstance = GameObject.Instantiate(_enemyPrefab);
    enemyInstance.transform.position = spawnPoint.position;

    var agentLocation = spawnPoint.position;
    agentLocation.x = 30f;

    var agent = enemyInstance.GetComponent<NavMeshAgent>();
    agent.SetDestination(agentLocation);

    _spawnCount++;
  }

  public bool AllEnemiesSpawned()
  {
    return _spawnCount == enemyCount;
  }
}
