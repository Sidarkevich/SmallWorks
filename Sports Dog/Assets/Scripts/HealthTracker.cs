using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    [SerializeField] private HealthHandler _handler;
    [SerializeField] private List<GameObject> _hearts;

    private void Start()
    {
        _handler.HealthChangedEvent.AddListener(Setup);
    }

    public void Setup(int current, int max)
    {
        var proportion = _hearts.Count / max;

        for (int i = 0; i < _hearts.Count; i++)
        {
            _hearts[i].SetActive((i+1)*proportion <= current);
        }
    }
}
