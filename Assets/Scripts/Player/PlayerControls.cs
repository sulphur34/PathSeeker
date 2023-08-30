using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerControls : MonoBehaviour
{
    private Weapon _weapon;
    private PlayerMover _mover;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mover.AddVerticalVelocity();
            }

            if (Input.GetMouseButtonDown(1))
            {
                _weapon.Shoot();
            }
        }
    }
}
