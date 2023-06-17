using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _moveDirection;

    private void Update()
    {
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var goalkeeper = collider.GetComponent<Goalkeeper>();
        if (goalkeeper)
        {
            // score++
        }

        var goal = collider.GetComponent<GoalHandler>();
        if (goal)
        {
            goal.Goal();
        }

        Destroy(gameObject);
    }
}
