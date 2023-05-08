using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUI : MonoBehaviour
{
    [SerializeField] private Sprite[] _visualStates;

    [SerializeField] private Ball _ball;

    private void Start()
    {
        _ball.BallGetBuffEvent.AddListener(OnBallGetBuffEvent);
    }

    private void OnBallGetBuffEvent(int value, int buff)
    {
        GetComponent<SpriteRenderer>().sprite = _visualStates[value];
    }
}
