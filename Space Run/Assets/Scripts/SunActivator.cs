using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunActivator : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private int _activeCount;
    [SerializeField] private ScoreHandler _score;

    public void SunWasCollected()
    {
        ActivateSun();
    }

    public void Activate()
    {
        for (int i = 0; i < _activeCount; i++)
        {
            ActivateSun();
        }
    }

    private void ActivateSun()
    {
        var sun = _pool.ActivateObject();
        sun.Element.Init(_score);
    }
}
