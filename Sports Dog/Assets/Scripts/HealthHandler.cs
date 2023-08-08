using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    [HideInInspector] public UnityEvent<int, int> HealthChangedEvent;

    private int _currentHealth;

    public void Damage(int value)
    {
        _currentHealth -= value;
        HealthChangedEvent?.Invoke(_currentHealth, _maxHealth);
    }

    public bool IsAlive()
    {
        return (_currentHealth > 0);
    }

    public void Reset()
    {
        _currentHealth = _maxHealth;
        HealthChangedEvent?.Invoke(_currentHealth, _maxHealth);
    }
}
