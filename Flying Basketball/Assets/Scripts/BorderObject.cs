using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var handler = collider.GetComponent<ScoreHandler>();

        if (handler)
        {
            handler.Loss();
        }
    }
}
