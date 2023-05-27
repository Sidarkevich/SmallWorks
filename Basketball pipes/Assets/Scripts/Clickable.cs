using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    public UnityEvent ClickedEvent;

    [SerializeField] private ClickBlock _block;
    
    private Collider2D _collider;

    private void Awake()
    {
        _block.BlockStateChangedEvent.AddListener(ChangeBlock);
        _collider = GetComponent<Collider2D>();
    }

    private void OnDestroy()
    {
        _block.BlockStateChangedEvent.RemoveListener(ChangeBlock);
    }

    private void ChangeBlock(bool block)
    {
        _collider.enabled = !block;
    }

    private void OnMouseUpAsButton()
    {
        ClickedEvent?.Invoke();
    }
}
