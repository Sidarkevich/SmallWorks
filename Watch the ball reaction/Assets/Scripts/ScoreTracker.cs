using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Score _score;

    public void OnScoreUpdated(int value)
    {
        _text.text = value.ToString();
    }

    private void OnEnable()
    {
        _text.text = _score.ScoreValue.ToString();
    }
}
