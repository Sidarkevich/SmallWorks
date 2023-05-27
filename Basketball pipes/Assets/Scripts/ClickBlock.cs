using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickBlock : MonoBehaviour
{
    [HideInInspector] public UnityEvent<bool> BlockStateChangedEvent;

    private bool _isBlocked;

    public void BlockClick()
    {
        _isBlocked = true;
        BlockStateChangedEvent?.Invoke(_isBlocked);
    }

    public void UnblockClick()
    {
        _isBlocked = false;
        BlockStateChangedEvent?.Invoke(_isBlocked);
    }
}
