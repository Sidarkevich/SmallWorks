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
        _tracker.ScoreUpdateEvent.AddListener(OnScoreUpdateEvent);
    }

    private void OnScoreUpdateEvent(int value)
    {
        _text.text = value.ToString();
    }
}
