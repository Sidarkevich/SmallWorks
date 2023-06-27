using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _maxVelocity;
    [SerializeField] private Rigidbody2D _rb;

    public void SetPosition(Transform newTransform)
    {
        transform.position = newTransform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var score = collider.GetComponent<ScoreHandler>();

        if (score)
        {
            score.Increase(1);
        }
    }
}
