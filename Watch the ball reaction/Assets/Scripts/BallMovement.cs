using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public void SetBorder(float borderX)
    {
        _minXValue = borderX;
    }

    private float _minXValue;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left*Time.fixedDeltaTime*2);

        if (transform.position.x < _minXValue)
        {
            Destroy(gameObject);
        }
    }
}
