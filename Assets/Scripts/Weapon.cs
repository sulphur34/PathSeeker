using UnityEngine;

public class Weapon : ObjectPool
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _firePosition;
    [SerializeField] float _fireDelay;
    [SerializeField] float _fireForce;

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
            GetOrientation();
            bullet.SetActive(true);
            bullet.transform.position = _firePosition.position;
            var velocity = _fireDirection * _fireForce;
            bullet.GetComponent<Rigidbody2D>().AddForce(velocity);
            _shootTimer = 0f;
        }
    }

    private void GetOrientation()
    {
        float rotationAngle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        float directionX = Mathf.Cos(rotationAngle);
        float directionY = Mathf.Sin(rotationAngle);
        _fireDirection = new Vector2(directionX, directionY).normalized;
    }
}
