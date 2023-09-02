using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnTriggerEnterEvent(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
