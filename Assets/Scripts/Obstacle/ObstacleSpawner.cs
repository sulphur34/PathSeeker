using UnityEngine;

public class ObstacleSpawner : ObjectPool
{
    [SerializeField] private GameObject[] _obstacles;
    [SerializeField] private float _upperSpawnPositionY;
    [SerializeField] private float _lowerSpawnPositionY;
    [SerializeField] private float _spawnOffsetX;

    private Vector3 _upperSpawnPoint;
    private Vector3 _lowerSpawnPoint;
    private Vector3 _lastCameraPosition;
    private float _distanceToSpawnNext;
    private float _spawnOffsetZ;

    private void Start()
    {
        _spawnOffsetZ = 20;
        _distanceToSpawnNext = 0.6f;
        Initialize(_obstacles);
        _lastCameraPosition = _camera.transform.position;
        
    }

    private void Update()
    {
        _upperSpawnPoint = 
            new Vector3(_spawnOffsetX + _camera.transform.position.x, 
            _upperSpawnPositionY, _spawnOffsetZ);
        _lowerSpawnPoint = 
            new Vector3(_spawnOffsetX + _camera.transform.position.x, 
            _lowerSpawnPositionY, _spawnOffsetZ);

        if (Time.timeSinceLevelLoad > 1f && 
            Vector3.Distance(_camera.transform.position, _lastCameraPosition) >= _distanceToSpawnNext) 
        {
            _lastCameraPosition = _camera.transform.position;
            SpawnObstacle(_lowerSpawnPoint, out GameObject obstacle);
            SpawnUpperObstacle(_upperSpawnPoint);
        }

        DisableObjectAbroadScreen();
    }

    private void SpawnObstacle(Vector3 _position, out GameObject result)
    {
        if (TryGetObject(out GameObject obstacle))
        {
            obstacle.SetActive(true);
            obstacle.transform.position = _position;
        }

        result = obstacle;
    }
    private void SpawnUpperObstacle(Vector3 _position)
    {
        SpawnObstacle(_position, out GameObject obstacle);

        if(obstacle != null)
            obstacle.transform.rotation = Quaternion.Euler(0, 0, 180);
    }

}
