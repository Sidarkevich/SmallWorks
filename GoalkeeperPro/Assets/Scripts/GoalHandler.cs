using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalHandler : MonoBehaviour
{
    public UnityEvent GoalEvent;

    public void Goal()
    {
        GoalEvent?.Invoke();
    }
}
