using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private int _score;
    private int _highScore;

    public int Score => _score;
    public int HighScore => _highScore;

    public event UnityAction GameOver;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _score = 0;
    }

    private void Update()
    {
        if(transform.position.x > 0)
        {
            _score = Mathf.RoundToInt(transform.position.x);
            _highScore = _score > _highScore ? _score : _highScore;
        }
    }

    public void Die()
    {
        GameOver?.Invoke();
        _mover.Reset();
        GetComponent<Weapon>().Reset();
        _score = 0;
    }

    public void Reset()
    {
        _mover.Reset();
        _score = 0;
    }
}
