using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private Enemy[] _enemyPrefab;
    [SerializeField] private Vector2 _upperSpawnBound;
    [SerializeField] private Vector2 _lowerSpawnBound;
    [SerializeField] private float _spawnDelay;

    
    private Vector3 _spawnPosition;
    private float _spawnOffsetZ;
    private bool _isSpawnActive;
    private WaitForSeconds _spawnTimer;
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _isSpawnActive = true;
        _spawnTimer = new WaitForSeconds(_spawnDelay);
        _spawnOffsetZ = 20;
        Initialize(_enemyPrefab);
        _spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        DisableObjectAbroadScreen();
    }

    private void OnDisable()
    {
        StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnEnemy()
    {
        while (_isSpawnActive)
        {
            if (TryGetObject(out GameObject enemy))
            {
                float spawnPositionY = Random.Range(_lowerSpawnBound.y, _upperSpawnBound.y);
                _spawnPosition =
                new Vector3(_lowerSpawnBound.x + _camera.transform.position.x,
                spawnPositionY, _spawnOffsetZ);
                enemy.SetActive(true);
                enemy.transform.position = _spawnPosition;
            }

            yield return _spawnTimer;
        }
    }
}
