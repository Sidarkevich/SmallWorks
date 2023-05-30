using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private MoveTracker _tracker;

    private void Start()
    {
        _tracker.PlayerMovedEvent.AddListener((value) => _text.text = value.ToString());
    }
}
