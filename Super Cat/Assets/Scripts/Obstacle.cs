using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var cat = collision.gameObject.GetComponent<Cat>();

        if (cat)
        {
            cat.Hit();
        }
    }
}
