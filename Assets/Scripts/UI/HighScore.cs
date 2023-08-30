using UnityEngine;

public class HighScore : Score
{
    [SerializeField] private Player _player;
        
    private void Update()
    {
        SetScoreView(_player.HighScore.ToString());
    }
}
