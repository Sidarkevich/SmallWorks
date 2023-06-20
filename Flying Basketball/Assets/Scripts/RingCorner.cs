using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCorner : MonoBehaviour
{
    [SerializeField] private float strength;
    private float _timeScale;

    private void Start()
    {
        _timeScale = Time.timeScale;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        var ball = collision2D.gameObject.GetComponent<Ball>();
        if (ball)
        {
            //ball.Kick(strength);
            Time.timeScale = _timeScale / 4;
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        var ball = collision2D.gameObject.GetComponent<Ball>();

        if (ball)
        {
            Time.timeScale = _timeScale;
        }
    }
}
