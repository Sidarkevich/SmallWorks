using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Ball _ball;

    private void Start()
    {
        _ball.BallGetBuffEvent.AddListener(OnBallGetBuffEvent);
    }

    private void OnBallGetBuffEvent(int value, int buff)
    {
        _animator.SetInteger("_stage", value);
    }
}
