using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;
    
    private float _moveSpeed;
    private float _yDestroyPosition;

    public void Stop()
    {
        _moveSpeed = 0;
    }

    public void Init(float speed, float yDestroy)
    {
        _moveSpeed = speed;
        _yDestroyPosition = yDestroy;
    }

    private void Update()
    {
        if (transform.position.y > _yDestroyPosition)
        {
            Destroy(gameObject);
        }

        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
