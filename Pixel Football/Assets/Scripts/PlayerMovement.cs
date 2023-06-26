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

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _target) < 0.1f)
        {
            _needMove = false;
        }

        if (_needMove)
        {
            var direction = _target - transform.position;

            Vector3 step = direction.normalized * 30f * Time.fixedDeltaTime;

            if (direction.magnitude < step.magnitude)
            {
                step = direction;
            }
            _rb.MovePosition(transform.position + step);
        }
    }
}
