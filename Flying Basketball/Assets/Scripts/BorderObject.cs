using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("there");

        var handler = collider.gameObject.GetComponent<ScoreHandler>();

        if (handler)
        {
            handler.Loss();
        }
    }
}
