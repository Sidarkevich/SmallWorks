using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private ScoreHandler _handler;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _handler.ScoreChangedEvent.AddListener((value) => _text.text = value.ToString());
    }

    private void OnEnable()
    {
        _text.text = _handler.Score.ToString();
    }
}