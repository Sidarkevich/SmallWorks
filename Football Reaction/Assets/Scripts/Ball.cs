using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;
    
    private float _moveSpeed;

    public void Stop()
    {
        _moveSpeed = 0;
    }

    public void Init(float speed)
    {
        _moveSpeed = speed;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
