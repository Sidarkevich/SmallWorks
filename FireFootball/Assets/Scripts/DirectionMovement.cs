using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMovement : MonoBehaviour
{
    public static int AliveValue = 1;

    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _moveDirection;

    private float _destroyValue;

    private void Start()
    {
        _destroyValue = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5f;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * AliveValue * Time.deltaTime);

        if (transform.position.x < _destroyValue)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
