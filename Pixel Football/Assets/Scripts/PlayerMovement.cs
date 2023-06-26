using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rb;

    private Vector3 _target;
    private bool _needMove;

    public void SetTarget(Vector3 target)
    {
        _target = target;
        _target.z = transform.position.z;
        _needMove = true;
    }

    private void Update()
    {
        if (_needMove)
        {
            _rb.MovePosition(_target);
        }

        // if (_needMove)
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime * _moveSpeed);
        // }

        if (Vector3.Distance(transform.position, _target) < 0.001f)
        {
            _needMove = false;
        }
    }
}
