using UnityEngine;

public class Weapon : ObjectPool
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePosition;
    [SerializeField] private float _fireDelay;
    [SerializeField] private float _fireForce;

    private Vector2 _fireDirection;
    private float _shootTimer;

    private void Start()
    {
        _shootTimer = 0f;
        Initialize(_bulletPrefab);
    }

    private void Update()
    {
        _shootTimer += Time.deltaTime;
        DisableObjectAbroadScreen();
    }    

    public void Shoot()
    {
        if (_shootTimer >= _fireDelay && TryGetObject(out GameObject bullet))
        {
            SetFireDirection();
            bullet.SetActive(true);
            bullet.transform.position = _firePosition.position;
            var velocity = _fireDirection * _fireForce;
            bullet.GetComponent<Bullet>().SetImpact(velocity);
            _shootTimer = 0f;
        }
    }

    private void SetFireDirection()
    {
        float rotationAngle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        float directionX = Mathf.Cos(rotationAngle);
        float directionY = Mathf.Sin(rotationAngle);
        _fireDirection = new Vector2(directionX, directionY).normalized;
    }
}
