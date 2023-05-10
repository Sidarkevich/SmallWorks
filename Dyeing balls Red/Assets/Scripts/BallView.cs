using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Ball _ball;

    private void Start()
    {
        _ball.BallGotBuffEvent.AddListener(OnBallGetBuff);
    }

    private void OnBallGetBuff(int value, int buff)
    {
        _animator.SetInteger("_stage", value);
    }
}
