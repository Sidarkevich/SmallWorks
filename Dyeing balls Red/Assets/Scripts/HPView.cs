using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Ball _ball;

    private void Start()
    {
        _ball.BallGotHitEvent.AddListener(OnBallGotHit);
    }

    private void OnBallGotHit(int value, int delta)
    {
        _animator.SetInteger("_hp", value);
    }
}
