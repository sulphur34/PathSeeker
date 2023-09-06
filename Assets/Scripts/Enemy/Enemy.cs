using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class Enemy : MonoBehaviour
{
    private Weapon _weapon;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        _weapon.Shoot();
    }

    private void OnDisable()
    {
        _weapon?.Reset();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyBullet bullet) == false)
        {
            Ammunition ammunition = GetComponentInChildren<Ammunition>();
            _weapon.Reset();
            gameObject.SetActive(false);            
            ammunition?.gameObject.SetActive(true);
        }
    }
}
