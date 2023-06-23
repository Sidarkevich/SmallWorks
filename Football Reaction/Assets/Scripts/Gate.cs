using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{
    public UnityEvent GoalEvent;

    [SerializeField] private ScoreHandler _score;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var ball = collider.GetComponent<Ball>();

        if (ball)
        {
            _score.IncreaseScore(1);
            GoalEvent?.Invoke();

            Destroy(ball.gameObject);
        }
    }
}
