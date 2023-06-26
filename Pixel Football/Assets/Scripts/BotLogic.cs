using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLogic : MonoBehaviour
{
    [SerializeField] private MoveZone _zone;
    [SerializeField] private CharacterMovement _movement;

    private bool _needUpdate;
    private Transform _target;

    private void SetBallTarget(Transform targetTransform)
    {
        _needUpdate = true;
        _target = targetTransform;
    }

    private void SetCenterTarget()
    {
        _needUpdate = false;
        _movement.SetTarget(_zone.Center.position);
    }

    private void OnEnable()
    {
        _zone.BallEnteredEvent.AddListener(SetBallTarget);
        _zone.BallOutEvent.AddListener(SetCenterTarget);

        SetCenterTarget();
    }

    private void OnDisable()
    {
        _zone.BallEnteredEvent.RemoveListener(SetBallTarget);
        _zone.BallOutEvent.RemoveListener(SetCenterTarget);
    }

    private void Update()
    {
        if (_needUpdate)
        {
            _movement.SetTarget(_target.position);
        }
    }
}
