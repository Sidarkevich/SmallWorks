using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    public bool IsBallInside => _isBallInside;

    private bool _isBallInside;

    public void Setup()
    {
        transform.parent.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    private void Awake()
    {
        transform.parent.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.GetComponent<Ball>();

        if (ball)
        {
            _isBallInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var ball = collision.GetComponent<Ball>();

        if (ball)
        {
            _isBallInside = false;
        }
    }
}
