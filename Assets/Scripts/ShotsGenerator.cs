using System.Collections;
using UnityEngine;

public class ShotsGenerator : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _shootingDelay;

    private WaitForSeconds _delayBeforeNextShot;

    private void Start()
    {
        _delayBeforeNextShot = new WaitForSeconds(_shootingDelay);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_bullet.gameObject, transform.position + direction, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _bulletSpeed;
            yield return _delayBeforeNextShot;
        }
    }
}