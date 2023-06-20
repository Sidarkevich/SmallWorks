using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _forceValue;

    private Vector3 _direction;


    public void Kick()
    {
        _body.AddForce(Vector2.up*_forceValue, ForceMode2D.Impulse);
    }

    private void Update()
    {

    }
}
