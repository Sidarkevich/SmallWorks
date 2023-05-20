using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public static float Speed = 2.0f;
    private const float startSpeed = 2.0f;
    private const float minXValue = -6.0f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.fixedDeltaTime * Speed);

        if (transform.position.x < minXValue)
        {
            Destroy(gameObject);
        }
    }
}
