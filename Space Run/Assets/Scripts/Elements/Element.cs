using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    protected ScoreHandler _score;
    protected ObjectPool _pool;

    public void Init(ScoreHandler score, ObjectPool pool)
    {
        _score = score;
        _pool = pool;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var rocket = collider.GetComponent<RocketInput>();

        if (rocket)
        {
            Effect();
        }
    }

    protected abstract void Effect();
}
