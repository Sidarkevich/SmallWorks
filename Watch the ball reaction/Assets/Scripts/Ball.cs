using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int TypeIndex => _typeIndex;

    [SerializeField] private int _typeIndex;
    [SerializeField] private BallMovement _movement;

    private Example _example;
    private Score _score;

    public void Init(Example example, Score score, float xBorder)
    {
        _example = example;
        _score = score;

        _movement.SetBorder(xBorder);
    }

    private void OnMouseUpAsButton()
    {
        if (_example.CurrentExample == _typeIndex)
        {
            _score.ScoreValue++;
            _example.SetNewExample();
        }
        else
        {
            _score.ScoreValue = 0;
        }
    }
}
