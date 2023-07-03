using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private ScoreHandler _handler;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        _handler.ScoreChangedEvent.AddListener((value) => _text.text = value.ToString());
    }

    private void OnEnable()
    {
        _text.text = _handler.Score.ToString();
    }
}
