using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelCondition : MonoBehaviour
{
    public UnityEvent PassedEvent;
    public UnityEvent LostEvent;

    public void Goal()
    {
        PassedEvent?.Invoke();
    }

    public void Hit()
    {
        LostEvent?.Invoke();
    }
}
