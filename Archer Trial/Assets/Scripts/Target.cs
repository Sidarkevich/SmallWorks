using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var arrow = collision.GetComponent<Arrow>();

        if (arrow)
        {
            arrow.Hit();
        }
    }
}
