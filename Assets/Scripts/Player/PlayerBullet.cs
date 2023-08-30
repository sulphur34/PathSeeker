using UnityEngine;
[RequireComponent (typeof(Collider2D))]
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerBullet : MonoBehaviour
{
    private Vector2 _velocity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            gameObject.SetActive (false);
    }

    public void Initialize()
    {
        _velocity = transform.localScale;
    }
}
