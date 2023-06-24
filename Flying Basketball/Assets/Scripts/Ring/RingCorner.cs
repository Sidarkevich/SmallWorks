using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCorner : MonoBehaviour
{
    [SerializeField] private float _scaleSign;

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        var scaler = collision2D.gameObject.GetComponent<SpeedScaler>();
        if (scaler)
        {
            scaler.Scale(_scaleSign);
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        var scaler = collision2D.gameObject.GetComponent<SpeedScaler>();
        if (scaler)
        {
            scaler.CancelScale();
        }
    }
}
