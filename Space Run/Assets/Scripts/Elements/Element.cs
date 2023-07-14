using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Element : MonoBehaviour
{
    [SerializeField] private UnityEvent _effectedEvent;

    protected ScoreHandler _score;
    protected ObjectPool _pool;
    protected SpeedHandler _speed;

    public void Init(ScoreHandler score, ObjectPool pool, SpeedHandler speed)
    {
        _score = score;
        _pool = pool;
        _speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var rocket = collider.GetComponent<RocketInput>();

        if (rocket)
        {
            Effect();
            _effectedEvent?.Invoke();
        }
    }

    protected abstract void Effect();
}
