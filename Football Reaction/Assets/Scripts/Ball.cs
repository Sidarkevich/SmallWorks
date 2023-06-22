using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;
    
    private float _moveSpeed;
    private float _yDestroyPosition;

    public void Init(float speed, float yDestroy)
    {
        _moveSpeed = speed;
        _yDestroyPosition = yDestroy;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.y > _yDestroyPosition)
        {
            Destroy();
        }

        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }
}
