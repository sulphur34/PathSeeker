using UnityEngine;

public class CurrentScore : Score
{
    [SerializeField] private Player _player;

    private void Update()
    {
        SetScoreView(_player.HighScore.ToString());
    }
}
