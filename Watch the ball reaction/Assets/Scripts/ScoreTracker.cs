using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    private enum ScoreType
    {
        CurrentScore,
        BestScore
    }

    [SerializeField] private TMP_Text _text;
    [SerializeField] private ScoreKeeper _score;
    [SerializeField] private ScoreType _type;
    [SerializeField] private string _format;

    public void OnScoreUpdated(int value)
    {
        if (_type == ScoreType.CurrentScore)
        {
            _text.text = value.ToString();
        }
    }

    private void OnEnable()
    {
        if (_type == ScoreType.CurrentScore)
        {
            _text.text = _score.ScoreValue.ToString(_format);
        }
        else
        {
            _text.text = PlayerPrefs.GetInt("BestScore", 0).ToString(_format);
        }
    }
}
