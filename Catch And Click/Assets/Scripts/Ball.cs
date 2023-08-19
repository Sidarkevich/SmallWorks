using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private SpeedHandler _speedHandler;

    private void FixedUpdate()
    {
        transform.parent.Rotate(Vector3.back, _speedHandler.Speed * Time.deltaTime);
    }
}
