using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelData : ScriptableObject
{
    public int ActiveCount => _activeCount;
    public AnimationClip MovementClip => _movementClip;

    [SerializeField] private int _activeCount;
    [SerializeField] private AnimationClip _movementClip;
}
