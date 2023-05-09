using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private TMP_Text _text;

    private int _score;

    private void Start()
    {
        _ball.BallFullOfBuffEvent.AddListener(OnFullOfBuffEvent);

        _score = 0;
        _text.text = _score.ToString();
    }

    private void OnFullOfBuffEvent()
    {
        _score++;
        _text.text = _score.ToString();
    }
}
