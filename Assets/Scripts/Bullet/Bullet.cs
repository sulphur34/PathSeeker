using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour
{
    private Vector2 _velocity;
    private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnterEvent(collision);
    }

    protected abstract void OnTriggerEnterEvent(Collider2D collision);

    public void Initialize()
    {
        _velocity = transform.localScale;
    }

    public void SetImpact(Vector2 impact)
    {
        _rigidbody.AddForce(impact);
    }
}
