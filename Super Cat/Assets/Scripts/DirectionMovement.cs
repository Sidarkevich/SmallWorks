using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DirectionMovement : MonoBehaviour
{
    private UnityEvent<DirectionMovement> ReleasedEvent = new UnityEvent<DirectionMovement>();

    [SerializeField] private bool _needRandomSpeed;
    [SerializeField] private Vector2 _speedRange;
    [SerializeField] private Vector3 _moveDirection;
    
    private float _speed;
    private float _destroyValue;

    public void AddReleaseListener(UnityAction<DirectionMovement> callback)
    {
        ReleasedEvent.AddListener(callback);
    }

    private void Start()
    {
        _destroyValue = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10f;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);

        if (transform.position.x < _destroyValue)
        {
            ReleasedEvent?.Invoke(this);
        }
    }

    private void OnEnable()
    {
        if (_needRandomSpeed)
        {
            _speed = Random.Range(_speedRange.x, _speedRange.y);
        }
        else
        {
            _speed = _speedRange.x;
        }
    }

    private void Awake()
    {
        if (_needRandomSpeed)
        {
            return;
        }

        var score = FindObjectOfType<ScoreHandler>();
        score.ScoreChangedEvent.AddListener(UpdateSpeed);
    }

    private void UpdateSpeed(int score)
    {
        _speed = _speedRange.x + ((score / 5) * 0.1f);
    }
}