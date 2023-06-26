using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var score = collider.GetComponent<ScoreHandler>();

        if (score)
        {
            score.Increase(1);
        }
    }
}
