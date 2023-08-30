using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    private int _scoreLineLength = 10;
    private char _filler = '0';

    protected void SetScoreView(string score)
    {
        string stringFiller = new string(_filler, _scoreLineLength - score.Length);
        _score.text = stringFiller + score;
    }
}
