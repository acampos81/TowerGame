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

  public void SpawnEnemy(Transform spawnPoint, BoxCollider attackArea)
  {
    var enemyInstance = GameObject.Instantiate(_enemyPrefab);
    
    var agent = enemyInstance.GetComponent<NavMeshAgent>();
    agent.enabled = false;

    enemyInstance.transform.position = spawnPoint.position;

    var agentLocation = GetAttackLocation(attackArea);

    agent.enabled = true;
    agent.SetDestination(agentLocation);

    _spawnCount++;
  }

  private Vector3 GetAttackLocation(BoxCollider attackArea)
  {
    var center = attackArea.transform.position;
    var randomZ = Random.Range(0f, attackArea.size.z * 0.5f);
    var randomSign = Random.Range(0,2);
    if(randomSign == 1)
    {
      randomZ *= -1;
    }

    return center + attackArea.transform.forward * randomZ;
  }

  public bool AllEnemiesSpawned()
  {
    return _spawnCount == enemyCount;
  }
}
