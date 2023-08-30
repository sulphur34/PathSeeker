using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private float _upperSpawnBoundY;
    [SerializeField] private float _lowerSpawnBoundY;
    [SerializeField] private float _spawnOffsetX;
    [SerializeField] private float _spawnDelay;

    private float _spawnTimer;
    private Vector3 _spawnPosition;
    private float _spawnOffsetZ;

    private void Start()
    {
        _spawnOffsetZ = 20;
        _spawnTimer = 0;
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        if (_spawnTimer > _spawnDelay)
        {
            SpawnEnemy();
            _spawnTimer = 0;
        }

        _spawnTimer += Time.deltaTime;
        DisableObjectAbroadScreen();
    }

    private void SpawnEnemy()
    {
        if (TryGetObject(out GameObject enemy))
        {
            float spawnPositionY = Random.Range(_lowerSpawnBoundY, _upperSpawnBoundY);
            _spawnPosition =
            new Vector3(_spawnOffsetX + _camera.transform.position.x,
            spawnPositionY, _spawnOffsetZ);
            enemy.SetActive(true);
            enemy.transform.position = _spawnPosition;
        }
    }
}
