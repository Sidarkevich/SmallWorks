using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    private enum TrackerType
    {
        Score,
        BestResult
    }

    [SerializeField] private TrackerType _type;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private MoveTracker _tracker;

    private void Start()
    {
        if (_type == TrackerType.Score)
        {
            _tracker.PlayerMovedEvent.AddListener((value) => _text.text = value.ToString());
        }
    }

    private void OnEnable()
    {
        if (_type == TrackerType.BestResult)
        {
            _text.text = (PlayerPrefs.GetInt("BestResult", 0)).ToString();
        }
        else
        {
            _text.text = _tracker.Moves.ToString();
        }
    }

    public void SaveResult()
    {
        var bestResult = PlayerPrefs.GetInt("BestResult", 0);

        if (_tracker.Moves < bestResult)
        {
            PlayerPrefs.SetInt("BestResult", _tracker.Moves);
            PlayerPrefs.Save();
        }
    }
}
