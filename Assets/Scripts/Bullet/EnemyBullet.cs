using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void OnTriggerEnterEvent(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            gameObject.SetActive(false);
    }
}
