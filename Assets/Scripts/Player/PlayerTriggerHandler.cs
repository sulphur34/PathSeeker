using UnityEngine;

[RequireComponent (typeof(Player))]
public class PlayerTriggerHandler : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player.Die();
    }
}
