using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private ScoreHandler _handler;
    [SerializeField] private bool _isBestScoreTracker;
    
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();

        if (_isBestScoreTracker)
        {
            _handler.BestScoreChangedEvent.AddListener((value) => _text.text = value.ToString());
        }
        else
        {
            _handler.ScoreChangedEvent.AddListener((value) => _text.text = value.ToString());
        }
    }

    private void OnEnable()
    {
        if (_isBestScoreTracker)
        {
            _text.text = _handler.BestScore.ToString();
        }
        else
        {
            _text.text = _handler.Score.ToString();
        }
    }
}