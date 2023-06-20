using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _moveDirection;

    private float _minPosition;

    private void Start()
    {
        _minPosition = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5f;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);

        if (transform.position.x < _minPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
