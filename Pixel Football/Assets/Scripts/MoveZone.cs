using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveZone : MonoBehaviour
{
    [HideInInspector] public UnityEvent<Transform> BallEnteredEvent;
    [HideInInspector] public UnityEvent BallOutEvent;

    public Transform Center => _center;

    [SerializeField] private Transform _ball;
    [SerializeField] private Transform _bottomLeft;
    [SerializeField] private Transform _topRight;
    [SerializeField] private Transform _center;

    private bool _ballInZone;

    private void Update()
    {
        if ((_ball.position.x > _bottomLeft.transform.position.x) && (_ball.position.y > _bottomLeft.position.y))
        {   
            if ((_ball.position.x < _topRight.position.x) && (_ball.position.y < _topRight.position.y))
            {
                if (!_ballInZone)
                {
                    BallEnteredEvent?.Invoke(_ball);
                    _ballInZone = true;
                }

                return;
            }
        }

        if (_ballInZone)
        {
            BallOutEvent?.Invoke();
            _ballInZone = false;
        }
    }
}
