using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private ColorHandler _color;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.GetComponent<Ball>();

        if (ball)
        {
            ball.Color.ChangeColor(_color.ColorIndex);
        }
    }

    private void OnEnable()
    {
        _color.SetRandomColor();
    }
}
