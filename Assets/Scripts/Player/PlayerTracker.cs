using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _offsetsX;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x - _offsetsX, transform.position.y, transform.position.z);
    }
}
