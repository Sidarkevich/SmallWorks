using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collider)
    {
        var handler = collider.gameObject.GetComponent<ScoreHandler>();

        if (handler)
        {
            handler.Loss();
        }
    }
}
