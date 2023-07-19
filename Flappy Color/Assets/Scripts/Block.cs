using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private ColorHandler _color;
    [SerializeField] private int _increaseValue;

    public ColorHandler Color => _color;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.GetComponent<Ball>();

        if (ball)
        {
            if (ball.Color.ColorIndex == _color.ColorIndex)
            {
                ball.Score.IncreaseScore(_increaseValue);
            }
            else
            {
                ball.Score.Loss();
            }
        }
    }
}
