using UnityEngine;
[RequireComponent (typeof(Collider2D))]
[RequireComponent (typeof (Rigidbody2D))]
public class EnemyBullet : MonoBehaviour
{
    private Vector2 _velocity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            gameObject.SetActive (false);
    }

    public void Initialize()
    {
        _velocity = transform.localScale;
    }
}
