using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
  [Tooltip("How often enemies will spawn in seconds.")]
  public float spawnInterval;

  public List<Spawner> allSpawners;
  public List<Transform> spawnPoints;

  private List<Spawner> _activeSpawners;
  private float _elapsedSpawnTime;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _activeSpawners = new List<Spawner>();
    _activeSpawners.AddRange(allSpawners);
  }

  // Update is called once per frame
  void Update()
  {
    if(_activeSpawners.Count > 0)
    {
      CheckSpawnInterval(Time.deltaTime);
    }
  }

  private void CheckSpawnInterval(float deltaTime)
  {
    _elapsedSpawnTime += deltaTime;
    if (_elapsedSpawnTime >= spawnInterval)
    {
      _elapsedSpawnTime = 0.0f;
      
      var randomSpawnPointIndex = Random.Range(0, spawnPoints.Count);
      var spawnPoint = spawnPoints[randomSpawnPointIndex];

      var randomSpawnerIndex = Random.Range(0, _activeSpawners.Count);
      var spawner = _activeSpawners[randomSpawnerIndex];
      spawner.SpawnEnemy(spawnPoint);
      
      if(spawner.AllEnemiesSpawned())
      {
        _activeSpawners.Remove(spawner);
      }
    }
  }
}
