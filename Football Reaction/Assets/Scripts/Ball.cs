using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static float MoveSpeedCoeff = 1;

    [SerializeField] private Vector3 _moveDirection;
    
    private float _moveSpeed;
    private float _yDestroyPosition;

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

        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime * MoveSpeedCoeff);
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
