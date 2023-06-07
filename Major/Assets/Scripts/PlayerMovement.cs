using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform[] _targets;
    private int _currentIndex;

    private void Start()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        _player.DOMoveX(_targets[_currentIndex].position.x, 1).OnComplete(() => {_currentIndex++; MoveToTarget(); });
    }
}
