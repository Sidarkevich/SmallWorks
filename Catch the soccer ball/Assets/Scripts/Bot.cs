using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bot : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnMovedEvent; 

    public void Move(int moves)
    {
        OnMovedEvent?.Invoke();
    }
}
