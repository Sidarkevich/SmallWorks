using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreTracker _tracker;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _text.text = _tracker.Score.ToString();
    }

    private void Start()
    {
        _tracker.ScoreUpdatedEvent.AddListener(OnScoreUpdated);
    }

    private void OnScoreUpdated(int value)
    {
        _text.text = value.ToString();
    }
}
