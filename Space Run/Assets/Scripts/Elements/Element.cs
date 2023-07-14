using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    protected ScoreHandler _score;

    public void Init()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var rocket = collision.gameObject.GetComponent<RocketInput>();

        if (rocket)
        {
            Effect();
        }
    }

    protected abstract void Effect();
}
